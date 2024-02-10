using EC.CRM.Backend.Application.DTOs;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponse> GetAsync(Guid uid);
        Task<List<StudentResponse>> GetAllAsync();
        Task<StudentResponse> CreateAsync(StudentRequest student);
        Task UpdateAsync(Guid uid, StudentResponse student);
        Task DeleteAsync(Guid uid);
        Task<MentorResponse> GetStudentMentor(Guid studentUid);
        Task<List<State>> GetAllStates();
    }
}
