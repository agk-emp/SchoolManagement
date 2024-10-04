using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities
{
    public class Department : GenericLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        public int DID { get; set; }
        public string DNameEn { get; set; }
        public string DNameAr { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
    }
}
