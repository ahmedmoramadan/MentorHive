using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTASK.Models
{
    public class Course : BaseEntity
    {
       public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hour { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
    }
}
