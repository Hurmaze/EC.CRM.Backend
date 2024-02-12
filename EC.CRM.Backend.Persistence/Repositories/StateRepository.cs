using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public StateRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<State> CreateAsync(State state)
        {
            await _dbContext.AddAsync(state);

            await _dbContext.SaveChangesAsync();

            return state;
        }

        public async Task DeleteAsync(Guid uid)
        {
            var state = await _dbContext.States.FindAsync(uid);

            if (state == null)
            {
                throw new NotFoundException("state", uid);
            }

            _dbContext.States.Entry(state).State = EntityState.Deleted;
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _dbContext
                .States
                .AsNoTracking()
                .OrderBy(x => x.OrderId)
                .ToListAsync();
        }

        public async Task<State?> GetAsync(Guid uid)
        {
            return await _dbContext
                .States
                .FindAsync(uid);
        }

        public async Task UpdateAsync(State state)
        {
            if (await _dbContext.States.FindAsync(state.Uid) is State found)
            {
                _dbContext.States.Entry(found).CurrentValues.SetValues(state);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(state), state.Uid);
            }
        }
    }
}
