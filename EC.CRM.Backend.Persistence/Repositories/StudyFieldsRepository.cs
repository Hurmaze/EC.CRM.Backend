using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class StudyFieldsRepository : IStudyFieldRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public StudyFieldsRepository(EngineeringClubDbContext engineeringClubDbContext)
        {
            _dbContext = engineeringClubDbContext;
        }

        public async Task<List<StudyField>> GetAllAsync(Expression<Func<StudyField, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
                .StudyFields
                .Where(predicate)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
