using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public LocationRepository(EngineeringClubDbContext engineeringClubDbContext)
        {
            _dbContext = engineeringClubDbContext;
        }
        public async Task<Location> CreateAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);

            await _dbContext.SaveChangesAsync();

            return location;
        }

        public async Task DeleteAsync(Guid uid)
        {
            var location = await _dbContext.Locations.FindAsync(uid);

            if (location == null)
            {
                throw new NotFoundException("location", uid);
            }

            _dbContext.Locations.Entry(location).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _dbContext
                .Locations
                .OrderBy(x => x.City)
                .ToListAsync();
        }

        public async Task<Location?> GetAsync(Guid uid)
        {
            return await _dbContext
                .Locations
                .FindAsync(uid);
        }

        public async Task UpdateAsync(Location location)
        {
            if (await _dbContext.Locations.FindAsync(location.Uid) is Location found)
            {
                _dbContext.Locations.Entry(found).CurrentValues.SetValues(location);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(location), location.Uid);
            }
        }
    }
}
