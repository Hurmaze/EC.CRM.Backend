using AutoMapper;
using EC.CRM.Backend.Application.Models;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Helpers
{
    internal class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Mentor, MentorModel>().ReverseMap();
        }
    }
}
