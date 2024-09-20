using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentList>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetStudentById>>,
        IRequestHandler<GetStudentsPaginatedQuery, PaginatedResponse<GetStudentsPaginated>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentList>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var mappedStudents = _mapper.Map<List<GetStudentList>>(students);
            return Success(mappedStudents);
        }

        public async Task<Response<GetStudentById>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(request.Id);
            if (student is null)
            {
                return NotFound<GetStudentById>("The object was not found");
            }
            var mappedStudent = _mapper.Map<GetStudentById>(student);
            return Success(mappedStudent);
        }

        public async Task<PaginatedResponse<GetStudentsPaginated>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentsPaginated>> mappingSql = e => new GetStudentsPaginated(
                e.StudID, e.Name, e.Address, e.Department.DName);

            var query = await _studentService.FilterStudents(request.Search)
                .Select(mappingSql)
                .ToPaginatedResult(request.PageNumber,
                request.PageSize);

            return query;
        }
    }
}
