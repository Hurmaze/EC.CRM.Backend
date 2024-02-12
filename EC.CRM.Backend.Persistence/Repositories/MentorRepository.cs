using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public MentorRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Mentor> CreateAsync(Mentor mentor)
        {
            await _dbContext.AddAsync(mentor);

            await _dbContext.SaveChangesAsync();

            return mentor;
        }

        public async Task DeleteAsync(Guid uid)
        {
            var location = await _dbContext.Mentors.FindAsync(uid);

            if (location == null)
            {
                throw new NotFoundException("mentor", uid);
            }

            _dbContext.Mentors.Entry(location).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Mentor>> GetAllAsync(Expression<Func<Mentor, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
               .Mentors
               .Include(x => x.UserInfo)
               .AsNoTracking()
               .Where(predicate)
               .ToListAsync();
        }

        public async Task<Mentor> GetAsync(Guid uid)
        {
            return await _dbContext
               .Mentors
               .Include(x => x.UserInfo)
               .ThenInclude(x => x.Jobs)
               .SingleAsync(x => x.UserInfoUid == uid);
        }

        public async Task UpdateAsync(Mentor mentor)
        {
            if (await _dbContext.Mentors.FindAsync(mentor.Id) is Mentor found)
            {
                _dbContext.Mentors.Entry(found).CurrentValues.SetValues(mentor);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(mentor), mentor.UserInfoUid);
            }
        }
    }
}
