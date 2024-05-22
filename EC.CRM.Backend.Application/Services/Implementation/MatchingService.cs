using AutoMapper;
using EC.CRM.Backend.Application.Common;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Implementation.TOPSIS;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class MatchingService : IMatchingService
    {
        private readonly ICriteriaRepository criteriasRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly IUserRepository userRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITopsisAlgorithm topsisAlgorithm;
        private readonly IMapper mapper;

        private Student? student;
        private List<Mentor>? mentors;

        public MatchingService(
            IStudentRepository studentRepository,
            IMentorRepository mentorRepository,
            ICriteriaRepository criteriasRepository,
            ITopsisAlgorithm topsisAlgorithm,
            IMapper mapper,
            IUserRepository userRepository)
        {
            this.studentRepository = studentRepository;
            this.mentorRepository = mentorRepository;
            this.criteriasRepository = criteriasRepository;
            this.topsisAlgorithm = topsisAlgorithm;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task SetMentorValuationAsync(Guid studentUid, List<MentorValuationRequest> valuations)
        {
            foreach (var valuation in valuations)
            {
                var mentorValuation = new Domain.Entities.TOPSIS.MentorValuation
                {
                    MentorUid = valuation.MentorUid,
                    StudentUid = studentUid,
                    Valuation = valuation.Valuation
                };

                await criteriasRepository.AddOrUpdateMentorsValuationsAsync(mentorValuation);
            }
        }

        public async Task<List<MentorValuationResponse>> GetStudentValuationsAsync(Guid studentUid)
        {
            var student = await userRepository.GetAsync(studentUid);

            var valuations = await criteriasRepository.GetMentorsValuations(studentUid);

            var allMentors = await mentorRepository.GetAllAsync(m => m.UserInfo.Locations
            .Any(l => student.Locations.Contains(l)) &&
            m.UserInfo.StudyFields.Any(s => student.StudyFields.Contains(s)));

            var result = allMentors.GroupJoin(
                valuations,
                m => m.UserInfoUid,
                v => v.MentorUid,
                (m, v) => new MentorValuationResponse(m.UserInfoUid, m.UserInfo.Name, v.FirstOrDefault()?.Valuation));

            return result.ToList();
        }

        public async Task<MatchingResponse> ChooseMentorAsync(Guid studentUid)
        {
            var criterias = await criteriasRepository.GetCriteriasAsync();

            if (criterias.Where(c => c.Weight is null || c.Weight == 0).Any())
            {
                throw new ApplicationException("Criterias are not initialized!");
            }

            student = await studentRepository.GetAsync(studentUid);

            var alternatives = await GetAlternativesAsync(
                student.UserInfo.StudyFields.First().Uid,
                student.UserInfo.Locations.First().Uid);

            // TODO: Make sure it indexes are right
            var topsisResult = topsisAlgorithm.Calculate(
                alternatives,
                criterias.Select(c => c.Weight!.Value).ToArray(),
                criterias.Select(c => c.IsBeneficial).ToArray());

            return new MatchingResponse
            {
                MenthorUid = mentors![topsisResult.Keys.First()].UserInfoUid,
                MatchingCoefficient = topsisResult.First().Value,
                OtherResults = topsisResult.ToDictionary(tr => mentors[tr.Key].UserInfoUid, tr => tr.Value).Skip(1).ToDictionary()
            };
        }

        #region private
        private async Task<double[,]> GetAlternativesAsync(Guid studyFieldUid, Guid locationUid)
        {
            var criteriasCount = await criteriasRepository.GetCriteriasCountAsync();

            mentors = await mentorRepository.GetAllAsync(
                m => m.UserInfo.StudyFields.Select(sf => sf.Uid).Contains(studyFieldUid)
                  && m.UserInfo.Locations.Select(sf => sf.Uid).Contains(locationUid));

            var mentorsValuations = await criteriasRepository.GetMentorsValuations(student!.UserInfoUid);

            if (mentorsValuations.Count != mentors.Count)
            {
                throw new Exception("Mentors valuations count is not equal to mentors count. Someone has not voted.");
            }

            var alternativeMatrix = new double[criteriasCount, mentors.Count];

            alternativeMatrix.SetRow(0, mentorsValuations.Select(mv => mv.Valuation)!);
            alternativeMatrix.SetRow(1, GetSkillsMatchingValuations(mentors));
            alternativeMatrix.SetRow(2, GetMentorsWorkloadEstimations(mentors));
            alternativeMatrix.SetRow(3, GetMentorSuccessEstimations(mentors));
            alternativeMatrix.SetRow(4, GetNonProffesionalInterestsMatching(mentors));

            return alternativeMatrix;
        }

        private double[] GetSkillsMatchingValuations(List<Mentor> mentors)
        {
            double[] skillsMatchingCount = new double[mentors.Count];
            var studentSkills = student!.UserInfo.Skills;
            for (int i = 0; i < mentors.Count; i++)
            {
                skillsMatchingCount[i] = mentors[i].UserInfo.Skills.Join(
                    studentSkills,
                    mSkill => mSkill.Uid,
                    sSkill => sSkill.Uid,
                    (mSkill, sSkill) => mSkill.Uid == sSkill.Uid).Count();
            }

            return skillsMatchingCount;
        }

        private double[] GetMentorsWorkloadEstimations(List<Mentor> mentors)
        {
            const double workloadWeightCoefficient = 1.2;
            double[] skillsMatchingCount = new double[mentors.Count];

            for (int i = 0; i < mentors.Count; i++)
            {
                skillsMatchingCount[i] = mentors[i].Students.IsNullOrEmpty() ? 0 : mentors[i].Students!.Count * workloadWeightCoefficient;
            }

            return skillsMatchingCount;
        }

        private double[] GetMentorSuccessEstimations(List<Mentor> mentors)
        {
            double[] studentsWithWorkCount = new double[mentors.Count];

            for (int i = 0; i < mentors.Count; i++)
            {
                studentsWithWorkCount[i] = mentors[i].Students.IsNullOrEmpty() ? 0 : mentors[i].Students!.Where(s => s.UserInfo.CurrentSalary is not null).Count();
            }

            return studentsWithWorkCount;
        }

        private double[] GetNonProffesionalInterestsMatching(List<Mentor> mentors)
        {
            double[] interestsMatchingCount = new double[mentors.Count];
            var studentInterests = student!.UserInfo.NonProfessionalInterests is null ? new() : student.UserInfo.NonProfessionalInterests;
            for (int i = 0; i < mentors.Count; i++)
            {
                interestsMatchingCount[i] = mentors[i].UserInfo.NonProfessionalInterests.IsNullOrEmpty() ? 0 :
                    mentors[i].UserInfo!.NonProfessionalInterests!.Join(
                    studentInterests,
                    mSkill => mSkill.Uid,
                    sSkill => sSkill.Uid,
                    (mSkill, sSkill) => mSkill.Uid == sSkill.Uid).Count();
            }

            return interestsMatchingCount;
        }
    }
    #endregion private
}
