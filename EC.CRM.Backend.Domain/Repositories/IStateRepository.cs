using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IStateRepository
    {
        Task<State?> GetAsync(Guid uid);
        Task<List<State>> GetAllAsync(Expression<Func<State, bool>>? predicate = null);
        Task UpdateAsync(State state);
        Task DeleteAsync(Guid uid);
    }
}
