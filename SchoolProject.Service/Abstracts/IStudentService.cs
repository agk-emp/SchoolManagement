using SchoolProject.Data.Entities;
using SchoolProject.Data.Helper;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentById(int id);
        Task<Student> GetStudentWithoutInclude(int id);
        Task AddStudent(Student student);
        Task EditStudent(Student student);
        Task<bool> DoesExistWithName(string name);
        Task<bool> DoesExistWithNameExcludeSelf(string name, int id);
        Task DeleteStudent(Student student);
        IQueryable<Student> FilterStudents(string? search, StudentOrderingEnum? orderBy);
    }
}
