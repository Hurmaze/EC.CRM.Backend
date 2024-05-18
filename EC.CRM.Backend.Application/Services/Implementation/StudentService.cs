using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly IUserRepository userRepository;
        private readonly IStateRepository stateRepository;
        private readonly IRoleRepository roleRepository;
        private readonly ISkillRepository skillRepository;
        private readonly INonProffesionalInterestRepository interestsRepository;
        private readonly IStudyFieldRepository studyFieldRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        public StudentService(
            IStudentRepository studentRepository,
            IMentorRepository mentorRepository,
            IMapper mapper,
            IUserRepository userRepository,
            IStateRepository stateRepository,
            IRoleRepository roleRepository,
            ISkillRepository skillRepository,
            INonProffesionalInterestRepository interestsRepository,
            IStudyFieldRepository studyFieldRepository,
            ILocationRepository locationRepository)
        {
            this.studentRepository = studentRepository;
            this.mentorRepository = mentorRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.stateRepository = stateRepository;
            this.roleRepository = roleRepository;
            this.skillRepository = skillRepository;
            this.interestsRepository = interestsRepository;
            this.studyFieldRepository = studyFieldRepository;
            this.locationRepository = locationRepository;
        }

        public async Task AssignMentorAsync(Guid studentUid, Guid mentorUid)
        {
            var student = await studentRepository.GetAsync(studentUid);

            var mentor = await mentorRepository.GetAsync(mentorUid);

            student.Mentor = mentor;

            await studentRepository.UpdateAsync(student);
        }

        public async Task<StudentResponse> CreateAsync(StudentApplicationRequest studentApplicationRequest)
        {
            var user = mapper.Map<UserInfo>(studentApplicationRequest);

            if (await IsEmailTakenAsync(user.Email))
            {
                throw new ApplicationException("Email is already taken");
            }

            var roles = await roleRepository.GetAllAsync();

            user.Role = roles.Single(r => r.Name == Roles.Student);
            if (studentApplicationRequest.NonProffesionalInterestsUids != null)
            {
                var interests = await interestsRepository.GetAllAsync(r => studentApplicationRequest.NonProffesionalInterestsUids.Contains(r.Uid));
                user.NonProfessionalInterests = interests;
            }

            if (studentApplicationRequest.SkillsUids != null)
            {
                var skills = await skillRepository.GetAllAsync(r => studentApplicationRequest.SkillsUids.Contains(r.Uid));
                user.Skills = skills;
            }
            var studyFields = await studyFieldRepository.GetAllAsync(r => studentApplicationRequest.DesiredStudyFieldUid == r.Uid);
            user.StudyFields = studyFields;
            var location = await locationRepository.GetAsync(studentApplicationRequest.LocationUid);
            if (location == null)
            {
                throw new NotFoundException("Location", studentApplicationRequest.LocationUid);
            }
            user.Locations = new List<Location> { location };

            var createdUser = await userRepository.CreateAsync(user);
            var studentToCreate = new Student
            {
                UserInfoUid = createdUser.Uid,
                State = (await stateRepository.GetAllAsync()).Single(s => s.Name == States.DoingTestTask),
                UserInfo = createdUser,
            };
            var createdStudent = await studentRepository.CreateAsync(studentToCreate);

            return mapper.Map<StudentResponse>(createdUser);
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentResponse>> GetAllAsync()
        {
            var mentors = await userRepository.GetAllAsync(u => u.Role.Name == Roles.Student);

            return mapper.Map<List<StudentResponse>>(mentors);
        }

        public async Task<List<StudentResponse>> GetAllApplicationAsync()
        {
            var mentors = await userRepository.GetAllAsync(u => u.Role.Name == Roles.Student && u.StudentProperties!.State.Name == States.DoingTestTask);

            return mapper.Map<List<StudentResponse>>(mentors);
        }

        public Task<List<State>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> GetAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<MentorResponse> GetStudentMentor(Guid studentUid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid uid, StudentResponse student)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> IsEmailTakenAsync(string email)
        {
            try
            {
                var user = await userRepository.GetAsync(email);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }
    }
}
