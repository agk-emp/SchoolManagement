using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentMapping
    {
        private void GetStudetsListQueryMapped()
        {
            CreateMap<Student, GetStudentList>()
                .ForMember(des=>des.DepartmentName,
                opt=>opt.MapFrom(src=>src.Department.DName));
        }
    }
}
