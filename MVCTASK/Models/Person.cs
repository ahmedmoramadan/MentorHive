using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTASK.Models
{
    public class Person : BaseEntity
    {
        public string Address { get; set; } = default!;
        public string Img { get; set; } = default!;
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
    }
}
