using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IMentorRepository
    {
        Task<Mentor> GetAsync(Guid uid);
        Task<List<Mentor>> GetAllAsync(Expression<Func<Mentor, bool>>? predicate = null);
        Task<Mentor> CreateAsync(Mentor mentor);
        Task UpdateAsync(Mentor mentor);
        Task DeleteAsync(Guid uid);
    }
}
