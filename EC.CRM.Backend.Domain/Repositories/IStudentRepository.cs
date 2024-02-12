using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetAsync(Guid uid);
        Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>>? predicate = null);
        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Guid uid);
    }
}
