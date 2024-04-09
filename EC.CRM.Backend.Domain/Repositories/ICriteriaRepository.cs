using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface ICriteriaRepository
    {
        Task<List<Criteria>> GetCriteriasAsync();
        Task<int> GetCriteriasCountAsync();
        Task<List<MentorValuation>> GetMentorsValuations(Guid studentId);
        Task AddOrUpdateCriteriaAsync(Criteria alternative);
    }
}
