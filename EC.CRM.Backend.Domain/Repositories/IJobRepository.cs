using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync(Guid userUid);
        Task<Job> CreateAsync(Guid userId, Job job);
        Task UpdateAsync(Guid userId, Job job);
        Task DeleteAsync(Guid uid);
    }
}
