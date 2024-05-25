using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request.Students;
using EC.CRM.Backend.Application.DTOs.Request.Users;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Entities.TOPSIS;

namespace EC.CRM.Backend.Application.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, StudentResponse>().PreserveReferences();
            CreateMap<UserInfo, StudentResponse>()
                .ForMember(x => x.State, opt => opt.MapFrom(ui => ui.StudentProperties!.State))
                .ForMember(x => x.MentorValuations,
                opt => opt.MapFrom(src => src.StudentProperties != null ? src.StudentProperties.MentorValuations : null));
            //.PreserveReferences();
            CreateMap<StudentResponse, Student>().PreserveReferences();
            CreateMap<CreateUserRequest, Student>().PreserveReferences();
            CreateMap<StudentApplicationRequest, UserInfo>().PreserveReferences();
            CreateMap<UserInfoResponse, UserInfo>().PreserveReferences();

            CreateMap<Mentor, MentorResponse>().PreserveReferences();
            CreateMap<MentorResponse, Mentor>().PreserveReferences();
            CreateMap<UserInfo, MentorResponse>().PreserveReferences();
            //CreateMap<MentorResponse, MentorValuationResponse>().PreserveReferences();
            CreateMap<MentorValuation, MentorValuationResponse>()
                .ForMember(dest => dest.MentorName, opt => opt.MapFrom(src => src.Mentor.UserInfo.Name)).PreserveReferences();

            CreateMap<State, StateResponse>().ReverseMap().PreserveReferences();
            CreateMap<Role, RoleResponse>().ReverseMap().PreserveReferences();
            CreateMap<Job, JobResponse>().ReverseMap().PreserveReferences();
            CreateMap<Location, LocationResponse>().ReverseMap().PreserveReferences();
            CreateMap<Skill, SkillResponse>().ReverseMap().PreserveReferences();
            CreateMap<NonProfessionalInterest, NonProfessionalInterestResponse>().ReverseMap().PreserveReferences();
            CreateMap<StudyField, StudyFieldResponse>().ReverseMap().PreserveReferences();

            CreateMap<UserInfo, UserInfoResponse>()
                .PreserveReferences();
        }
    }
}
