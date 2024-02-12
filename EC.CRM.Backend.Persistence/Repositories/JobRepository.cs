using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public JobRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Job> CreateAsync(Guid userUid, Job job)
        {
            if (await _dbContext.UserInfos.FindAsync(userUid) is UserInfo found)
            {
                found.Jobs!.Add(job);
                await _dbContext.SaveChangesAsync();

                return job;
            }
            else
            {
                throw new NotFoundException(job.Uid);
            }
        }

        public async Task DeleteAsync(Guid uid)
        {
            var job = await _dbContext.Jobs.FindAsync(uid);

            if (job == null)
            {
                throw new NotFoundException(uid);
            }

            _dbContext.Jobs.Entry(job).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllAsync(Expression<Func<Job, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
                .Jobs
                .AsNoTracking()
                .Where(predicate)
                .OrderByDescending(x => x.StartTime)
                .ToListAsync();
        }

        public async Task<Job?> GetAsync(Guid uid)
        {
            return await _dbContext
                .Jobs
                .FindAsync(uid);
        }

        public async Task UpdateAsync(Job job)
        {
            if (await _dbContext.Jobs.FindAsync(job.Uid) is Job found)
            {
                _dbContext.Jobs.Entry(found).CurrentValues.SetValues(job);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(job.Uid);
            }
        }
    }
}
