using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        public Task AddUserJobAsync(Guid userUid, Job job)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetJobsAsync(Guid userUid)
        {
            throw new NotImplementedException();
        }
    }
}
