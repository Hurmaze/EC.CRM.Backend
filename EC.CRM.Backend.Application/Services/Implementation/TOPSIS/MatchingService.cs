/*using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities.TOPSIS;
using EC.CRM.Backend.Domain.Repositories;
using MathNet.Numerics.LinearAlgebra;

namespace EC.CRM.Backend.Application.Services.Implementation.TOPSIS
{
    public class MatchingService : IMatchingService
    {
        private readonly ICriteriasRepository criteriasRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly IStudentRepository studentRepository;

        public MatchingService(
            IStudentRepository studentRepository,
            IMentorRepository mentorRepository,
            ICriteriasRepository criteriasRepository)
        {
            this.studentRepository = studentRepository;
            this.mentorRepository = mentorRepository;
            this.criteriasRepository = criteriasRepository;
        }

        public async Task AddOrUpdateAlternativeAsync(Alternative alternative)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchingResponse> ChooseMentorAsync(Guid studentUid)
        {
            var student = await studentRepository.GetAsync(studentUid);

            var alternatives = GetAlternativesAsync(
                student.UserInfo.StudyFields.First().Uid,
                student.UserInfo.Locations.First().Uid);
        }

        private async Task<List<Matrix<double>>> GetAlternativesAsync(Guid studyFieldUid, Guid locationUid)
        {
            var alternatives = await criteriasRepository.GetAlternativesAsync();

            if (alternatives.Sum(a => a.Weight) != 1)
            {
                // normalize weight values
            }

            var mentors = await mentorRepository.GetAllAsync(
                m => m.UserInfo.StudyFields.Select(sf => sf.Uid).Contains(studyFieldUid)
                  && m.UserInfo.Locations.Select(sf => sf.Uid).Contains(locationUid));

            var alternativeMatrix = new double[alternatives.Count, mentors.Count];

            for (var i = 0; i < alternatives.Count; i++)
            {
                var alternativeValues =

                for (var j = 0; j < mentors.Count; j++)
                {

                }
            }
        }

        private double NormalizeValuation(double value, List<double> allAlternativeValues) => value / allAlternativeValues.Sum();

        private double[] GetCriteriaAlternatives(string criteriaName)
        {

        }
        // private async Task<()>
    }
}
*/