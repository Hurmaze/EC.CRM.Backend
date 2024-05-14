using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IMatchingService
    {
        Task SetMentorValuationAsync(Guid studentUid, List<MentorValuationRequest> valuations);
        Task<List<MentorValuationResponse>> GetStudentValuationsAsync(Guid studentUid);
        Task<MatchingResponse> ChooseMentorAsync(Guid studentUid);
    }
}
