using AutoMapper;
using EC.CRM.Backend.Application.Common;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Implementation.TOPSIS;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class MatchingService : IMatchingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITopsisAlgorithm topsisAlgorithm;
        private readonly IMapper mapper;

        private Student? student;
        private List<Mentor>? mentors;

        public MatchingService(
            IUnitOfWork unitOfWork,
            ITopsisAlgorithm topsisAlgorithm,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.topsisAlgorithm = topsisAlgorithm;
            this.mapper = mapper;
        }

        public async Task SetMentorValuationAsync(Guid studentUid, List<MentorValuationRequest> valuations, bool wasSetByMentor)
        {
            foreach (var valuation in valuations)
            {
                var mentorValuation = new Domain.Entities.TOPSIS.MentorValuation
                {
                    MentorUid = valuation.MentorUid,
                    StudentUid = studentUid,
                    Valuation = valuation.Valuation,
                    WasSetByMentor = wasSetByMentor,
                };

                await unitOfWork.CriteriaRepository.AddOrUpdateMentorsValuationsAsync(mentorValuation);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<List<MentorValuationResponse>> GetStudentValuationsAsync(Guid studentUid)
        {
            var student = await unitOfWork.UserRepository.GetAsync(studentUid);

            var valuations = await unitOfWork.CriteriaRepository.GetMentorsValuations(studentUid);

            mentors = await unitOfWork.MentorRepository.GetAllAsync(
                m => m.UserInfo.Locations.Any(l => student.Locations.Contains(l))
                && m.UserInfo.StudyFields.Select(sf => sf.Uid).Contains(student.StudyFields.First().Uid));

            var result = mentors.GroupJoin(
                valuations,
                m => m.UserInfoUid,
                v => v.MentorUid,
                (m, v) => new MentorValuationResponse(
                    m.UserInfoUid,
                    m.UserInfo.Name,
                    v.FirstOrDefault()?.Valuation,
                    v.FirstOrDefault()?.WasSetByMentor));

            return result.ToList();
        }

        public async Task<MatchingResponse> ChooseMentorAsync(Guid studentUid)
        {
            var criterias = await unitOfWork.CriteriaRepository.GetCriteriasAsync();

            if (criterias.Where(c => c.Weight is null || c.Weight == 0).Any())
            {
                throw new ApplicationException("Criterias are not initialized!");
            }

            student = await unitOfWork.StudentRepository.GetAsync(studentUid);

            var alternatives = await GetAlternativesAsync();

            // TODO: Make sure it indexes are right
            var topsisResult = topsisAlgorithm.Calculate(
                alternatives,
                criterias.Select(c => c.Weight!.Value).ToArray(),
                criterias.Select(c => c.IsBeneficial).ToArray());

            var bestMentor = mentors![topsisResult.Keys.First()];
            return new MatchingResponse
            (
                bestMentor.UserInfoUid,
                bestMentor.UserInfo.Name,
                topsisResult.First().Value,
                mentors.Count == 1 ? null : topsisResult.ToDictionary(tr => mentors[tr.Key].UserInfoUid, tr => tr.Value).Skip(1).ToDictionary()
            );
        }

        #region private
        private async Task<double[,]> GetAlternativesAsync()
        {
            var criteriasCount = await unitOfWork.CriteriaRepository.GetCriteriasCountAsync();

            var mentorsValuations = await GetStudentValuationsAsync(student!.UserInfoUid);

            if (mentorsValuations.Any(x => x.Valuation == default))
            {
                throw new ApplicationException("Mentors valuations count is not equal to mentors count. Someone has not voted.");
            }

            var alternativeMatrix = new double[mentors!.Count, criteriasCount];

            alternativeMatrix.SetColumn(0, mentorsValuations.Select(mv => mv.Valuation!.Value)!);
            alternativeMatrix.SetColumn(1, GetSkillsMatchingValuations(mentors));
            alternativeMatrix.SetColumn(2, GetMentorsWorkloadEstimations(mentors));
            alternativeMatrix.SetColumn(3, await GetMentorSuccessEstimationsAsync(mentors));
            alternativeMatrix.SetColumn(4, GetNonProffesionalInterestsMatching(mentors));

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
            double[] skillsMatchingCount = new double[mentors.Count];

            for (int i = 0; i < mentors.Count; i++)
            {
                skillsMatchingCount[i] = mentors[i].Students.IsNullOrEmpty() ? 0 : mentors[i].Students!.Count;
            }

            return skillsMatchingCount;
        }

        private async Task<double[]> GetMentorSuccessEstimationsAsync(List<Mentor> mentors)
        {
            double[] studentsWithWorkCount = new double[mentors.Count];

            for (int i = 0; i < mentors.Count; i++)
            {
                var mentorStudents = await unitOfWork.StudentRepository.GetAllAsync(s => s.Mentor.UserInfoUid == mentors[i].UserInfoUid);

                studentsWithWorkCount[i] = mentorStudents.IsNullOrEmpty() ? 0 : mentorStudents.Where(s => s.UserInfo.CurrentSalary is not null && s.UserInfo.CurrentSalary != 0).Count();
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
