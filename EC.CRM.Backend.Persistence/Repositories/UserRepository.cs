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
            await _dbContext.UserInfos.AddAsync(user);

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

        // TODO: Add pagination, Add sorting
        public async Task<List<UserInfo>> GetAllAsync(Expression<Func<UserInfo, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
               .UserInfos
               .Include(x => x.Locations)
               .Include(x => x.Role)
               .Include(x => x.Skills)
               .Include(x => x.NonProfessionalInterests)
               .Include(x => x.Locations)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.MentorValuations)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.State)
               .Include(x => x.MentorProperties)
               .Include(x => x.StudyFields)
               .AsNoTracking()
               .Where(predicate)
               .OrderByDescending(x => x.JoinDate)
               .ToListAsync();
        }

        public async Task<UserInfo> GetAsync(Guid uid)
        {
            var user = await _dbContext
               .UserInfos
               .Include(x => x.MentorProperties)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.State)
               .Include(x => x.Skills)
               .Include(x => x.NonProfessionalInterests)
               .Include(x => x.Credentials)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.MentorValuations)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.State)
               .Include(x => x.MentorProperties)
               .Include(x => x.Jobs)
               .Include(x => x.Role)
               .Include(x => x.Locations)
               .Include(x => x.StudyFields)
               .SingleOrDefaultAsync(x => x.Uid == uid);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), uid);
            }

            return user;
        }

        public async Task<UserInfo> GetAsync(string email)
        {
            var user = await _dbContext
               .UserInfos
               .Include(x => x.MentorProperties)
               .Include(x => x.Skills)
               .Include(x => x.NonProfessionalInterests)
               .Include(x => x.Credentials)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.MentorValuations)
               .Include(x => x.StudentProperties)
               .ThenInclude(s => s.State)
               .Include(x => x.MentorProperties)
               .Include(x => x.Jobs)
               .Include(x => x.Role)
               .Include(x => x.Locations)
               .Include(x => x.StudyFields)
               .SingleOrDefaultAsync(x => x.Email == email);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), email);
            }

            return user;
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
