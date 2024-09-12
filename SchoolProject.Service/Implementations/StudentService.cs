using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
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
            await _studentRepository.AddAsync(student);
            return "The student was added successfully";
        }

        public async Task<string> EditStudent(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "The student was updated successfully";
        }

        public async Task<bool> DoesExistWithName(string name)
        {
            var studentChecker = await _studentRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(stud => stud.Name == name);

            if (studentChecker is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DoesExistWithNameExcludeSelf(string name, int id)
        {
            var studentChecker = await _studentRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(stud => stud.Name == name &&
                stud.StudID != id);

            if (studentChecker is null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                .Include(s => s.Department)
                .Where(s => s.StudID == id)
                .FirstOrDefaultAsync();

            return student;
        }
    }
}
