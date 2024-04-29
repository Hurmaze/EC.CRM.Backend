using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class MentorService : IMentorService
    {
        public Task CreateAsync(Guid userInfoUid)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<List<MentorResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MentorResponse> GetAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResponse>> GetMentorStudents(Guid mentorUid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid uid, MentorResponse mentor)
        {
            throw new NotImplementedException();
        }
    }
}