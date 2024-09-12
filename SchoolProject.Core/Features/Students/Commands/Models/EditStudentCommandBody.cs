namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentCommandBody
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmentID { get; set; }
    }
}
