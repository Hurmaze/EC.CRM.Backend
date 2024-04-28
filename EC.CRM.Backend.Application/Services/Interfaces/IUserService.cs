using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Job>> GetJobsAsync(Guid userUid);
        Task AddUserJobAsync(Guid userUid, Job job);
        Task<UserInfoResponse> CreateUserAsync(CreateUserRequest user);
    }
}
