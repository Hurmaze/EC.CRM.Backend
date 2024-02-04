using EC.CRM.Backend.Application.Models;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel> GetAsync(Guid uid);
        Task<List<StudentModel>> GetAllAsync();
        Task<StudentModel> CreateAsync(StudentModel student);
        Task UpdateAsync(Guid uid, StudentModel student);
        Task DeleteAsync(Guid uid);
        Task<MentorModel> GetStudentMentor(Guid studentUid);
        Task<List<Job>> GetJobs(Guid studentUid);
    }
}
