using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
    }
}
