using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler :ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;

        public StudentCommandHandler(IStudentService studentService, 
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student= _mapper.Map<Student>(request);

            var result= await _studentService.AddStudent(student);
            if(result == "Already exists")
            {
                return UnprocessableEntity<string>();
            }
            return Created<string>();
        }
    }
}
