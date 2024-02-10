using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task<Location?> GetAsync(Guid uid);
        Task<List<Location>> GetAllAsync();
        Task<Location> CreateAsync(Location location);
        Task UpdateAsync(Guid uid, Location location);
        Task DeleteAsync(Guid uid);
    }
}
