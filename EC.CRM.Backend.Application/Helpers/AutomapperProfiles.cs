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
            CreateMap<Student, StudentResponse>();

            CreateMap<StudentResponse, Student>();

            CreateMap<StudentRequest, Student>();

            CreateMap<Mentor, MentorResponse>();

            CreateMap<MentorResponse, Mentor>();

            CreateMap<MentorRequest, Mentor>();
        }
    }
}
