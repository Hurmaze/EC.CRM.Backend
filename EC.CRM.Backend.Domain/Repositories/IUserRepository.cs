using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserInfo> GetAsync(Guid uid);
        Task<List<UserInfo>> GetAllAsync(Expression<Func<UserInfo, bool>>? predicate = null);
        Task<UserInfo> CreateAsync(UserInfo user);
        Task UpdateAsync(UserInfo user);
        Task DeleteAsync(Guid uid);
    }
}
