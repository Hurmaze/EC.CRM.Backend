using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IMentorRepository mentorRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mentorRepository = mentorRepository;
            this.mapper = mapper;
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
            var student = mapper.Map<Student>(studentApplicationRequest);

            var createdStudent = await studentRepository.CreateAsync(student);

            return mapper.Map<StudentResponse>(createdStudent);
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
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
