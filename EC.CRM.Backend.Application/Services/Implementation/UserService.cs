using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Helpers;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly AuthHelper authHelper;
        private readonly IMapper mapper;

        public UserService(IMapper mapper, IUserRepository userRepository, AuthHelper authHelper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.authHelper = authHelper;
        }

        public Task AddUserJobAsync(Guid userUid, Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfoResponse> CreateUserAsync(CreateUserRequest user)
        {
            if (user == null)
            {
                throw new ApplicationException($"{nameof(user)} is null");
            }
            if ((await userRepository.GetAsync(user.Email)) is not null)
            {
                throw new AlreadyExistsException(nameof(user), user.Email);
            }

            var userEntity = mapper.Map<UserInfo>(user);

            var passwordhash = authHelper.CreatePasswordHash(user.Password);

            userEntity.Credentials = new Credentials
            {
                PasswordHash = passwordhash.passwordHash,
                PasswordSalt = passwordhash.passwordSalt
            };

            var createdUser = userRepository.CreateAsync(userEntity);

            return mapper.Map<UserInfoResponse>(createdUser);
        }

        public async Task<UserInfoResponse> GetAsync(Guid uid)
        {
            var mentor = await userRepository.GetAsync(uid);

            return mapper.Map<UserInfoResponse>(mentor);
        }

        public Task<List<Job>> GetJobsAsync(Guid userUid)
        {
            throw new NotImplementedException();
        }
    }
}
