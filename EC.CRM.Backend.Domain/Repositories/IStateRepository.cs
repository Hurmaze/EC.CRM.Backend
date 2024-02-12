using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IStateRepository
    {
        Task<State?> GetAsync(Guid uid);
        Task<List<State>> GetAllAsync();
        Task<State> CreateAsync(State state);
        Task UpdateAsync(State state);
        Task DeleteAsync(Guid uid);
    }
}
