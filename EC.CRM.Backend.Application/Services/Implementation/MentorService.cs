using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Application.Services.Interfaces;
using EC.CRM.Backend.Domain;
using EC.CRM.Backend.Domain.Repositories;

namespace EC.CRM.Backend.Application.Services.Implementation
{
    public class MentorService : IMentorService
    {
        private readonly IUserRepository userRepository;
        private readonly IMentorRepository mentorRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public MentorService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository, IMentorRepository mentorRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.roleRepository = roleRepository;
            this.mentorRepository = mentorRepository;
        }

        public async Task CreateAsync(Guid userInfoUid)
        {
            var user = await userRepository.GetAsync(userInfoUid);

            var mentorRole = (await roleRepository.GetAllAsync(r => r.Name == Roles.Mentor)).SingleOrDefault();

            if (mentorRole is null)
            {
                throw new Exception("Mentor role not found");
            }

            user.Role = mentorRole;

            await userRepository.UpdateAsync(user);
        }

        public Task DeleteAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MentorResponse>> GetAllAsync()
        {
            var mentors = await userRepository.GetAllAsync(u => u.Role.Name == Roles.Mentor);

            return mapper.Map<List<MentorResponse>>(mentors);
        }

        public async Task<MentorResponse> GetAsync(Guid uid)
        {
            var mentor = await userRepository.GetAsync(uid);

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