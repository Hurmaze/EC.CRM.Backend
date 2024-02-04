using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IMentorRepository
    {
        Task<Mentor> GetAsync(Guid uid);
        Task<List<Mentor>> GetAllAsync();
        Task<Mentor> CreateAsync(Mentor mentor);
        Task UpdateAsync(Guid uid, Mentor mentor);
        Task DeleteAsync(Guid uid);
    }
}
