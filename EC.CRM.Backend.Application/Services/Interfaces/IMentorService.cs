using EC.CRM.Backend.Application.Models;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMentorService
    {
        Task<MentorModel> GetAsync(Guid uid);
        Task<List<MentorModel>> GetAllAsync();
        Task<MentorModel> CreateAsync(MentorModel mentor);
        Task UpdateAsync(Guid uid, MentorModel mentor);
        Task DeleteAsync(Guid uid);
        Task<List<StudentModel>> GetMentorStudents(Guid mentorUid);
        Task<List<Job>> GetJobs(Guid mentorUid);
    }
}
