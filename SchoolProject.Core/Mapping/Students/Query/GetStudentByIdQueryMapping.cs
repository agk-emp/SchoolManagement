﻿using AutoMapper;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping : Profile
    {
        public void GetStudentByIdQueryMapping()
        {
            CreateMap<Student, GetStudentById>()
                .ForMember(dst => dst.DepartmentName, opt =>
                {
                    opt.MapFrom(src => src.Department.DName);
                });
        }
    }
}