﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    public class StudentController : AppControllerBase
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Routing.StudentRouting.GetAll)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(response);
        }

        [HttpGet(Routing.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Routing.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent(AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}