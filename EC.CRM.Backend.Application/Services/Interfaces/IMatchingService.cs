using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMatchingService
    {
        Task<MatchingResponse> ChooseMentorAsync(Guid studentUid);
        Task UpdateCriteriaAsync(Criteria alternative);
    }
}
