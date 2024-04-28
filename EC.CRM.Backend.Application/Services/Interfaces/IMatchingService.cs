using EC.CRM.Backend.Application.DTOs.Response;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMatchingService
    {
        Task SetMentorValuation(Guid studentUid, Dictionary<Guid, double> valuations);
        Task GetStudentValuations(Guid studentUid);
        Task<MatchingResponse> ChooseMentorAsync(Guid studentUid);
    }
}
