using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVCTASK.ViewModels.instractorVM
{
    public class InstVM
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [MinLength(3)]
        [MaxLength(250)]
        public string Address { get; set; } = default!;
        public decimal Salary { get; set; }
        [Display(Name = "Course")]
        public int CrsId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
