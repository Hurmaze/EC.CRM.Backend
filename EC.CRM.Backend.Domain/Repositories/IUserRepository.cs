using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserInfo> GetAsync(Guid uid);
        Task<List<UserInfo>> GetAllAsync();
        Task<UserInfo> CreateAsync(UserInfo user);
        Task UpdateAsync(Guid uid, UserInfo user);
        Task DeleteAsync(Guid uid);
    }
}
