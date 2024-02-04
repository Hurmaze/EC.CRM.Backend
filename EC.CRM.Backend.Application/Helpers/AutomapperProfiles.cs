using AutoMapper;
using EC.CRM.Backend.Application.DTOs;
using EC.CRM.Backend.Application.Models;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Helpers
{
    internal class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Student, StudentResponse>()
                .ForMember(sm => sm.Name, x => x.MapFrom(s => s.Name + " " + s.Surname));

            CreateMap<StudentResponse, Student>()
                .ForMember(s => s.Name, x => x.MapFrom(sm => sm.Name!.Split(' ', StringSplitOptions.None)[0]))
                .ForMember(s => s.Surname, x => x.MapFrom(sm => sm.Name!.Split(' ', StringSplitOptions.None)[1]));

            CreateMap<StudentResponse, Student>();

            CreateMap<Mentor, MentorResponse>();

            CreateMap<MentorResponse, Mentor>()
                .ForMember(m => m.Name, x => x.MapFrom(mm => mm.Name!.Split(' ', StringSplitOptions.None)[0]))
                .ForMember(m => m.Surname, x => x.MapFrom(mm => mm.Name!.Split(' ', StringSplitOptions.None)[1]));

            CreateMap<MentorRequest, Mentor>();
        }
    }
}
