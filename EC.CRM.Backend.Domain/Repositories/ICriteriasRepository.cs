using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface ICriteriasRepository
    {
        Task<List<Alternative>> GetCriteriasAsync();
        Task<int> GetCriteriasCountAsync();
        Task<List<MentorValuation>> GetMentorsValuations(Guid studentId);
        Task AddAlternative(Alternative alternative);
    }
}
