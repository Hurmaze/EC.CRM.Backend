﻿using AutoMapper;
using EC.CRM.Backend.Application.DTOs.Request;
using EC.CRM.Backend.Application.DTOs.Response;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.Helpers
{
    internal class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Student, StudentResponse>().PreserveReferences();

            CreateMap<StudentResponse, Student>().PreserveReferences();

            CreateMap<CreateStudentRequest, Student>().PreserveReferences();

            CreateMap<Mentor, MentorResponse>().PreserveReferences();

            CreateMap<MentorResponse, Mentor>().PreserveReferences();

            CreateMap<CreateMentorRequest, Mentor>().PreserveReferences();
        }
    }
}
