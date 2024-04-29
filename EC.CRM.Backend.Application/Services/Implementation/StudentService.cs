using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class StudentService : IStudentService
    {
        public Task AssignMentorAsync(Guid studentUid, Guid mentorUid)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> CreateAsync(StudentApplicationRequest studentApplicationRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> GetAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<MentorResponse> GetStudentMentor(Guid studentUid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid uid, StudentResponse student)
        {
            throw new NotImplementedException();
        }
    }
}
