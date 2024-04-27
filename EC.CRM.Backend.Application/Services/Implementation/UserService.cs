using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class UserService : IUserInfoService
    {
        public Task AddUserJob(Guid userUid, Job job)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetJobs(Guid userUid)
        {
            throw new NotImplementedException();
        }
    }
}
