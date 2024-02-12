using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync(Expression<Func<Job, bool>>? predicate = null);
        Task<Job> CreateAsync(Guid userUid, Job job);
        Task UpdateAsync(Job job);
        Task DeleteAsync(Guid uid);
    }
}
