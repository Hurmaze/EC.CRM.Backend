using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, StudentResponse>().PreserveReferences();
            CreateMap<UserInfo, StudentResponse>()
                .ForMember(x => x.State, opt => opt.MapFrom(ui => ui.StudentProperties!.State))
                .PreserveReferences();
            CreateMap<StudentResponse, Student>().PreserveReferences();
            CreateMap<CreateUserRequest, Student>().PreserveReferences();
            CreateMap<StudentApplicationRequest, UserInfo>().PreserveReferences();

            CreateMap<Mentor, MentorResponse>().PreserveReferences();
            CreateMap<MentorResponse, Mentor>().PreserveReferences();
            CreateMap<UserInfo, MentorResponse>().PreserveReferences();

            CreateMap<State, StateResponse>().PreserveReferences();
            CreateMap<Role, RoleResponse>().PreserveReferences();
            CreateMap<Job, JobResponse>().PreserveReferences();
            CreateMap<Location, LocationResponse>().PreserveReferences();
            CreateMap<Skill, SkillResponse>().PreserveReferences();
            CreateMap<NonProfessionalInterest, NonProfessionalInterestResponse>().PreserveReferences();
            CreateMap<StudyField, StudyFieldResponse>().PreserveReferences();

            CreateMap<UserInfo, UserInfoResponse>()
                .PreserveReferences();
        }
    }
}
