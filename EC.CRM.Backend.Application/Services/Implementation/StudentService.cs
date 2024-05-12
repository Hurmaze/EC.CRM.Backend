using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Entities;
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
        private readonly IMapper mapper;

        public StudentService(
            IStudentRepository studentRepository,
            IMentorRepository mentorRepository,
            IMapper mapper,
            IUserRepository userRepository,
            IStateRepository stateRepository,
            IRoleRepository roleRepository)
        {
            this.studentRepository = studentRepository;
            this.mentorRepository = mentorRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.stateRepository = stateRepository;
            this.roleRepository = roleRepository;
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

            var roles = await roleRepository.GetAllAsync();

            user.Role = roles.Single(r => r.Name == Roles.Student);

            var createdUser = await userRepository.CreateAsync(user);
            var studentToCreate = new Student
            {
                UserInfoUid = createdUser.Uid,
                State = (await stateRepository.GetAllAsync()).Single(s => s.Name == States.DoingTestTask),
                UserInfo = createdUser,
            };
            var createdStudent = await studentRepository.CreateAsync(studentToCreate);

            return mapper.Map<StudentResponse>(createdStudent);
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
    }
}
