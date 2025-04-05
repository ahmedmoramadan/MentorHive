using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCTASK.Models;

namespace MVCTASK.ViewModels.CourseVM
{
    public class AddCourseVM
    {
        [MinLength(3)]
        public string Name { get; set; } = default!;
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hour { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
