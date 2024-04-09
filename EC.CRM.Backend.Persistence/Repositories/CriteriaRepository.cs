using EC.CRM.Backend.Domain.Entities.TOPSIS;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class CriteriaRepository : ICriteriaRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public CriteriaRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Criteria>> GetCriteriasAsync()
        {
            return await _dbContext
                .Criterias
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetCriteriasCountAsync()
        {
            return await _dbContext
                .Criterias
                .CountAsync();
        }

        public async Task<List<MentorValuation>> GetMentorsValuations(Guid studentId)
        {
            return await _dbContext
                .MentorValuations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddOrUpdateCriteriaAsync(Criteria criteria)
        {
            if (await _dbContext.Criterias.FindAsync(criteria.Name) is Criteria found)
            {
                _dbContext.Criterias.Entry(found).CurrentValues.SetValues(criteria);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(criteria), criteria.Name);
            }
        }
    }
}
