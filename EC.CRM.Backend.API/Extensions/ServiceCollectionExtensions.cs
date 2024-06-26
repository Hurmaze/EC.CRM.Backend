﻿using AutoMapper;
using EC.CRM.Backend.API.Middlewares;
using EC.CRM.Backend.API.Utils;
using EC.CRM.Backend.Application.Helpers;
using EC.CRM.Backend.Application.Services.Implementation;
using EC.CRM.Backend.Application.Services.Implementation.TOPSIS;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Repositories;
using EC.CRM.Backend.Persistence.Repositories;

namespace EC.CRM.Backend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICriteriaRepository, CriteriaRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMentorRepository, MentorRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INonProffesionalInterestRepository, NonProfessionalInterestsRepository>();
            services.AddTransient<ISkillRepository, SkillsRepository>();
            services.AddTransient<IStudyFieldRepository, StudyFieldsRepository>();

            services.AddTransient<AuthHelper>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICriteriaService, CriteriaService>();
            services.AddTransient<IMatchingService, MatchingService>();
            services.AddTransient<IMentorService, MentorService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITopsisAlgorithm, TopsisAlgorithm>();

            services.AddTransient<ClaimsHelper>();

            services.AddTransient<ExceptionMiddleware>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
