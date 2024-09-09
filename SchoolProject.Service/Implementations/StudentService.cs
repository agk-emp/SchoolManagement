using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> AddStudent(Student student)
        {
            var studentChecker=await _studentRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(stud=>stud.Name == student.Name);

            if (studentChecker is not null)
            {
                return $"Already exists";
            }

            await _studentRepository.AddAsync(student);
            return "The student was added successfully";
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student=await _studentRepository.GetTableNoTracking()
                .Include(s=>s.Department)
                .Where(s=>s.StudID==id)
                .FirstOrDefaultAsync();

            return student;
        }
    }
}
