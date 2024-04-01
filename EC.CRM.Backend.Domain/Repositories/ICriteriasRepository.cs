using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface ICriteriasRepository
    {
        Task<List<Alternative>> GetAlternativesAsync();
        Task AddAlternative(Alternative alternative);
    }
}
