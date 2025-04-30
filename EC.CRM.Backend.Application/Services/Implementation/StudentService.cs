using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Domain.Repositories.Specifications;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMatchingService matchingService;

        public StudentService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMatchingService matchingService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.matchingService = matchingService;
        }

        public async Task AssignMentorAsync(Guid studentUid, Guid mentorUid)
        {
            var student = await unitOfWork.StudentRepository.GetAsync(studentUid);

            var mentor = await unitOfWork.MentorRepository.GetAsync(mentorUid);

            student.Mentor = mentor;

            student.State = (await unitOfWork.StateRepository.GetAllAsync(s => s.Name == States.Probation)).Single();

            await unitOfWork.StudentRepository.UpdateAsync(student);
            await unitOfWork.CommitAsync();
        }

        public async Task<StudentResponse> CreateAsync(StudentApplicationRequest studentApplicationRequest)
        {
            var user = mapper.Map<UserInfo>(studentApplicationRequest);

            if (await IsEmailTakenAsync(user.Email))
            {
                throw new ApplicationException("Email is already taken");
            }

            var roles = await unitOfWork.RoleRepository.GetAllAsync();

            user.Role = roles.Single(r => r.Name == Roles.Student);
            if (studentApplicationRequest.NonProffesionalInterestsUids != null)
            {
                var interests = await unitOfWork.InterestRepository.GetAllAsync(r => studentApplicationRequest.NonProffesionalInterestsUids.Contains(r.Uid));
                user.NonProfessionalInterests = interests;
            }

            if (studentApplicationRequest.SkillsUids != null)
            {
                var skills = await unitOfWork.SkillRepository.GetAllAsync(r => studentApplicationRequest.SkillsUids.Contains(r.Uid));
                user.Skills = skills;
            }
            var studyFields = await unitOfWork.StudyFieldRepository.GetAllAsync(r => studentApplicationRequest.DesiredStudyFieldUid == r.Uid);
            user.StudyFields = studyFields;
            var location = await unitOfWork.LocationRepository.GetAsync(studentApplicationRequest.LocationUid);
            if (location == null)
            {
                throw new NotFoundException("Location", studentApplicationRequest.LocationUid);
            }
            user.Locations = new List<Location> { location };

            var createdUser = await unitOfWork.UserRepository.CreateAsync(user);
            var studentToCreate = new Student
            {
                UserInfoUid = createdUser.Uid,
                State = (await unitOfWork.StateRepository.GetAllAsync()).Single(s => s.Name == States.DoingTestTask),
                UserInfo = createdUser,
            };
            var createdStudent = await unitOfWork.StudentRepository.CreateAsync(studentToCreate);
            await unitOfWork.CommitAsync();

            return mapper.Map<StudentResponse>(createdUser);
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentResponse>> GetAllAsync()
        {
            var students = await unitOfWork.UserRepository.GetAllAsync(u => u.Role.Name == Roles.Student);

            return mapper.Map<List<StudentResponse>>(students);
        }

        public async Task<List<StudentResponse>> GetAllApplicationAsync()
        {
            var students = await unitOfWork.UserRepository.GetAsync(new GetAllApplicationsSpecification());

            var studentResponses = mapper.Map<List<StudentResponse>>(students);

            return studentResponses;
        }

        public Task<List<State>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentResponse> GetAsync(Guid uid)
        {
            var students = await unitOfWork.UserRepository.GetAsync(uid);

            var studentResponse = mapper.Map<StudentResponse>(students);

            var val = await matchingService.GetStudentValuationsAsync(uid);
            studentResponse.MentorValuations = val;

            return studentResponse;
        }

        public Task<MentorResponse> GetStudentMentor(Guid studentUid)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid uid, UpdateUserRequest studentPatch)
        {
            var studentEntity = await unitOfWork.UserRepository.GetAsync(uid);

            mapper.Map(studentPatch, studentEntity);

            if (studentPatch.NonProffesionalInterestsUids != null)
            {
                var interests = await unitOfWork.InterestRepository.GetAllAsync(r => studentPatch.NonProffesionalInterestsUids.Contains(r.Uid));
                studentEntity.NonProfessionalInterests = interests;
            }
            if (studentPatch.SkillsUids != null)
            {
                var skills = await unitOfWork.SkillRepository.GetAllAsync(r => studentPatch.SkillsUids.Contains(r.Uid));
                studentEntity.Skills = skills;
            }
            if (studentPatch.LocationUid != default)
            {
                var locations = await unitOfWork.LocationRepository.GetAllAsync();
                studentEntity.Locations = locations.Where(x => x.Uid == studentPatch.LocationUid).ToList();
            }

            await unitOfWork.UserRepository.UpdateAsync(studentEntity);
            await unitOfWork.CommitAsync();
        }

        private async Task<bool> IsEmailTakenAsync(string email)
        {
            var entity = await unitOfWork.UserRepository.GetAsync(email);

            return entity is null ? false : true;
        }
    }
}
