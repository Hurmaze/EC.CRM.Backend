using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public UserRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserInfo> CreateAsync(UserInfo user)
        {
            await _dbContext.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(Guid uid)
        {
            var location = await _dbContext.UserInfos.FindAsync(uid);

            if (location == null)
            {
                throw new NotFoundException("user", uid);
            }

            _dbContext.UserInfos.Entry(location).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserInfo>> GetAllAsync(Expression<Func<UserInfo, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
               .UserInfos
               .Include(x => x.Location)
               .AsNoTracking()
               .Where(predicate)
               .ToListAsync();
        }

        public async Task<UserInfo> GetAsync(Guid uid)
        {
            return await _dbContext
               .UserInfos
               .Include(x => x.MentorProperties)
               .Include(x => x.StudentProperties)
               .Include(x => x.Jobs)
               .Include(x => x.Location)
               .SingleAsync(x => x.Uid == uid);
        }

        public async Task UpdateAsync(UserInfo user)
        {
            if (await _dbContext.UserInfos.FindAsync(user.Uid) is UserInfo found)
            {
                _dbContext.UserInfos.Entry(found).CurrentValues.SetValues(user);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(user), user.Uid);
            }
        }
    }
}
