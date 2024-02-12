using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EngineeringClubDbContext _dbContext;
        public StudentRepository(EngineeringClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await _dbContext.AddAsync(student);

            await _dbContext.SaveChangesAsync();

            return student;
        }

        public async Task DeleteAsync(Guid uid)
        {
            var location = await _dbContext.Students.FindAsync(uid);

            if (location == null)
            {
                throw new NotFoundException("student", uid);
            }

            _dbContext.Students.Entry(location).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>>? predicate = null)
        {
            if (predicate == null) predicate = (x) => true;

            return await _dbContext
               .Students
               .Include(x => x.UserInfo)
               .AsNoTracking()
               .Where(predicate)
               .ToListAsync();
        }

        public async Task<Student> GetAsync(Guid uid)
        {
            return await _dbContext
               .Students
               .Include(x => x.UserInfo)
               .ThenInclude(x => x.Jobs)
               .SingleAsync(x => x.UserInfoUid == uid);
        }

        public async Task UpdateAsync(Student student)
        {
            if (await _dbContext.Students.FindAsync(student.Id) is Student found)
            {
                _dbContext.Students.Entry(found).CurrentValues.SetValues(student);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException(nameof(student), student.UserInfoUid);
            }
        }
    }
}
