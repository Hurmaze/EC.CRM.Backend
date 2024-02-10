using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<List<Job>> GetJobs(Guid userUid);
        Task AddUserJob(Guid userUid, Job job);
    }
}
