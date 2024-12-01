using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class MentorService : IMentorService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public MentorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Guid userInfoUid)
        {
            var user = await unitOfWork.UserRepository.GetAsync(userInfoUid);

            var mentorRole = (await unitOfWork.RoleRepository.GetAllAsync(r => r.Name == Roles.Mentor)).SingleOrDefault();

            if (mentorRole is null)
            {
                throw new Exception("Mentor role not found");
            }

            user.Role = mentorRole;

            await unitOfWork.UserRepository.UpdateAsync(user);
            await unitOfWork.CommitAsync();
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MentorResponse>> GetAllAsync()
        {
            var mentors = await unitOfWork.UserRepository.GetAllAsync(u => u.Role.Name == Roles.Mentor);

            return mapper.Map<List<MentorResponse>>(mentors);
        }

        public async Task<MentorResponse> GetAsync(Guid uid)
        {
            var mentor = await unitOfWork.UserRepository.GetAsync(uid);

            return mapper.Map<MentorResponse>(mentor);
        }

        public Task<List<StudentResponse>> GetMentorStudents(Guid mentorUid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid uid, MentorResponse mentor)
        {
            throw new NotImplementedException();
        }
    }
}