using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using EC.CRM.Backend.Application.Common;
using EC.CRM.Backend.Application.Services.Implementation;
using EC.CRM.Backend.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EC.CRM.Backend.Application.Helpers
{
    public class AuthHelper
    {
        private readonly IOptions<JwtOptions> authOptions;
        private readonly ILogger<AuthService> logger;

        public AuthHelper(IOptions<JwtOptions> authOptions, ILogger<AuthService> logger)
        {
            this.authOptions = authOptions;
            this.logger = logger;
        }

        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string newPassword)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword));
            }

            return (passwordHash, passwordSalt);
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns></returns>
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// Generates the JWT token.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public string GenerateToken(UserInfo user)
        {
            var authParams = authOptions.Value;

            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role!.Name),
                new Claim(CustomClaimTypes.Uid, user.Uid.ToString()),
            };

            var key = authParams.GetSymmetricSecurityKey();
            var credantials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credantials);

            logger.LogInformation("JWT token for {email} generated.", user.Email);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
