using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResponse<GetStudentsPaginated>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
