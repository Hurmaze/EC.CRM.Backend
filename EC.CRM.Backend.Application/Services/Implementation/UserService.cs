using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Helpers;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ISkillRepository skillsRepository;
        private readonly INonProffesionalInterestRepository nonProffesinalInterestRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IStudyFieldRepository studyFieldRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStateRepository stateRepository;
        private readonly AuthHelper authHelper;
        private readonly IMapper mapper;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository,
            AuthHelper authHelper,
            ISkillRepository skillsRepository,
            INonProffesionalInterestRepository nonProffesinalInterestRepository,
            ILocationRepository locationRepository,
            IStudyFieldRepository studyFieldRepository,
            IRoleRepository roleRepository,
            IStudentRepository studentRepository,
            IStateRepository stateRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.authHelper = authHelper;
            this.skillsRepository = skillsRepository;
            this.nonProffesinalInterestRepository = nonProffesinalInterestRepository;
            this.locationRepository = locationRepository;
            this.studyFieldRepository = studyFieldRepository;
            this.roleRepository = roleRepository;
            this.studentRepository = studentRepository;
            this.stateRepository = stateRepository;
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

            if (user.Password != null)
            {
                var passwordhash = authHelper.CreatePasswordHash(user.Password);

                userEntity.Credentials = new Credentials
                {
                    PasswordHash = passwordhash.passwordHash,
                    PasswordSalt = passwordhash.passwordSalt
                };
            }

            var role = await roleRepository.GetAllAsync(r => r.Name == Roles.Student);
            userEntity.Role = role.Single();

            if (user.SkillsUids != null)
            {
                var skills = await skillsRepository.GetAllAsync(s => user.SkillsUids.Contains(s.Uid));
                userEntity.Skills = skills;
            }
            if (user.NonProffesionalInterestsUids != null)
            {
                var nonProffesionalInterests = await nonProffesinalInterestRepository.GetAllAsync(n => user.NonProffesionalInterestsUids.Contains(n.Uid));
                userEntity.NonProfessionalInterests = nonProffesionalInterests;
            }
            var studyFields = await studyFieldRepository.GetAllAsync(r => user.DesiredStudyFieldUid == r.Uid);
            userEntity.StudyFields = studyFields;
            var location = await locationRepository.GetAsync(user.LocationUid);
            if (location == null)
            {
                throw new NotFoundException("Location", user.LocationUid);
            }
            userEntity.Locations = new List<Location> { location };

            var createdUser = await userRepository.CreateAsync(userEntity);
            var studentToCreate = new Student
            {
                UserInfoUid = createdUser.Uid,
                State = (await stateRepository.GetAllAsync()).Single(s => s.Name == States.DoingTestTask),
                UserInfo = createdUser,
            };

            await studentRepository.CreateAsync(studentToCreate);

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

        public async Task<List<LocationResponse>> GetLocationsAsync()
        {
            var locations = await locationRepository.GetAllAsync();

            return mapper.Map<List<LocationResponse>>(locations);
        }

        public async Task<List<NonProfessionalInterestResponse>> GetNonProfessionalInterestsAsync()
        {
            var nonProfessionalInterests = await nonProffesinalInterestRepository.GetAllAsync();

            return mapper.Map<List<NonProfessionalInterestResponse>>(nonProfessionalInterests);
        }

        public async Task<List<SkillResponse>> GetSkillsAsync()
        {
            var skills = await skillsRepository.GetAllAsync();

            return mapper.Map<List<SkillResponse>>(skills);
        }

        public async Task<List<StudyFieldResponse>> GetStudyFieldsAsync()
        {
            var studyFields = await studyFieldRepository.GetAllAsync();

            return mapper.Map<List<StudyFieldResponse>>(studyFields);
        }
    }
}
