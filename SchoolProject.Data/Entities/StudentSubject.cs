using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        public int StudSubID { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}
