using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class DepartmetSubject
    {
        public int DeptSubID { get; set; }
        public int DID { get; set; }
        public int SubID { get; set; }
        public virtual Department Department { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
