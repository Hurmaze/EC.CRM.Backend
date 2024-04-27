using AutoMapper;
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

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICriteriaService, CriteriaService>();
            services.AddTransient<IMatchingService, MatchingService>();
            services.AddTransient<IMentorService, MentorService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IUserInfoService, UserService>();
            services.AddTransient<ITopsisAlgorithm, TopsisAlgorithm>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
