using EC.CRM.Backend.Application.DTOs;
using EC.CRM.Backend.Application.Models;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMentorService
    {
        Task<MentorResponse> GetAsync(Guid uid);
        Task<List<MentorResponse>> GetAllAsync();
        Task<MentorResponse> CreateAsync(MentorRequest mentor);
        Task UpdateAsync(Guid uid, MentorResponse mentor);
        Task DeleteAsync(Guid uid);
        Task<List<StudentResponse>> GetMentorStudents(Guid mentorUid);
        Task<List<Job>> GetJobs(Guid mentorUid);
    }
}
