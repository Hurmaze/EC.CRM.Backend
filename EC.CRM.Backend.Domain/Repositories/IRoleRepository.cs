using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync(Expression<Func<Role, bool>>? predicate = null);
    }
}
