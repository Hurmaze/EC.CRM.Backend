using EC.CRM.Backend.Application.DTOs.Request;
using EC.CRM.Backend.Application.DTOs.Response;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMentorService
    {
        Task<MentorResponse> GetAsync(Guid uid);
        Task<List<MentorResponse>> GetAllAsync();
        Task<MentorResponse> CreateAsync(CreateMentorRequest mentor);
        Task UpdateAsync(Guid uid, MentorResponse mentor);
        Task DeleteAsync(Guid uid);
        Task<List<StudentResponse>> GetMentorStudents(Guid mentorUid);
    }
}
