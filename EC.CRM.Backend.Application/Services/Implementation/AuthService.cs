﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request;
using EC.CRM.Backend.Application.Exceptions;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public sealed class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IOptions<JwtOptions> authOptions;
        private readonly ILogger<UserService> logger;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IOptions<JwtOptions> authOptions,
            ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.authOptions = authOptions;
            this.logger = logger;
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
            var user = await userRepository.GetAsync(loginRequest.Email);

            if (user == null)
            {
                throw new NotFoundException(nameof(user), loginRequest.Email);
            }

            if (!VerifyPassword(loginRequest.Password, user.Credentials.PasswordHash, user.Credentials.PasswordSalt))
            {
                throw new WrongPasswordException();
            }

            logger.LogInformation("The user with email {email} has logged into.", loginRequest.Email);
            return GenerateToken(user);
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns></returns>
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
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
        private string GenerateToken(UserInfo user)
        {
            var authParams = authOptions.Value;

            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role!.Name)
            };

            userClaims.Add(new Claim("uid", user.Uid.ToString()));

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