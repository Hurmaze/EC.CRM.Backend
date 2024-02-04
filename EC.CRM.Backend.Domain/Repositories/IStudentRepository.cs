using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetAsync(Guid uid);
        Task<List<Student>> GetAllAsync();
        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(Guid uid, Student student);
        Task DeleteAsync(Guid uid);
    }
}
