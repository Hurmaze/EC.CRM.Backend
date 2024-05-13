using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class NonProfessionalInterestsRepository : INonProffesionalInterestRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public NonProfessionalInterestsRepository(EngineeringClubDbContext engineeringClubDbContext)
        {
            _dbContext = engineeringClubDbContext;
        }

        public async Task<List<NonProfessionalInterest>> GetAllAsync(Expression<Func<NonProfessionalInterest, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            // NOTE: Here we do not Include() List<UserInfo> just because we won't need it.
            // So in that case this property will be null.
            // If it will be a problem in the future consider add DTO for this layer 
            // Similiar to existing one in Domain project. 
            // And then remove from domain entities redundant properties such as List<UserInfo> in this case.
            return await _dbContext
                .NonProfessionalInterests
                .Where(predicate)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
