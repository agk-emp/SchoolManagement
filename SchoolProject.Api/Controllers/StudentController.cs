using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMeatData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routing.StudentRouting.GetAll)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response =await  _mediator.Send(new GetAllStudentsQuery());
            return Ok(response);
        }

        [HttpGet(Routing.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student=await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(student);
        }

        [HttpPost(Routing.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent(AddStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
