using EC.CRM.Backend.Application.DTOs.Request.Auth;
using EC.CRM.Backend.Application.Exceptions;
using EC.CRM.Backend.Application.Helpers;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public sealed class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOptions<JwtOptions> authOptions;
        private readonly ILogger<AuthService> logger;
        private readonly AuthHelper authHelper;

        public AuthService(
            IUnitOfWork unitOfWork,
            IOptions<JwtOptions> authOptions,
            ILogger<AuthService> logger,
            AuthHelper authHelper)
        {
            this.unitOfWork = unitOfWork;
            this.authOptions = authOptions;
            this.logger = logger;
            this.authHelper = authHelper;
        }

        /// <summary>
        /// Generates token
        /// </summary>
        /// <param name="authModel">The authentication model.</param>
        /// <returns>
        /// Task&lt;string&gt; - JWT token
        /// </returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public async Task<string> GetTokenAsync(LoginRequest loginRequest)
        {
            var user = await unitOfWork.UserRepository.GetAsync(loginRequest.Email);

            if (user is null)
            {
                throw new NotFoundException(nameof(user), loginRequest.Email);
            }

            if (!authHelper.VerifyPassword(loginRequest.Password, user.Credentials.PasswordHash, user.Credentials.PasswordSalt))
            {
                throw new WrongPasswordException();
            }

            logger.LogInformation("The user with email {email} has logged into.", loginRequest.Email);
            return authHelper.GenerateToken(user);
        }

        public async Task ChangePasswordAsync(Guid userUid, ChangePasswordRequest changePasswordRequest)
        {
            var hash = authHelper.CreatePasswordHash(changePasswordRequest.NewPassword);

            var user = await unitOfWork.UserRepository.GetAsync(userUid);

            user.Credentials.PasswordHash = hash.passwordHash;
            user.Credentials.PasswordSalt = hash.passwordSalt;

            await unitOfWork.UserRepository.UpdateAsync(user);
            await unitOfWork.CommitAsync();
        }
    }
}
