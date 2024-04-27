using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface ICriteriaService
    {
        Task RegisterCriteriasAsync(int criteriasCount, Stream criteriasStream);
        Task<List<Criteria>> GetCriteriasAsync();
    }
}
