using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MVCTASK.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVCTASK.ViewModels.CourseVM
{
    public class CourseVM
    {
        [MinLength(3)]
        [UniqueCourseName]
        public string Name { get; set; } = default!;
        [Remote("CheckDegree", "Course", AdditionalFields = "MinDegree", ErrorMessage = "Degree must be more than or equal 50 and less than or equal 100!")]
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [Remote("ValidateHour", "Course", ErrorMessage = "Hour must be divisible by 3.")]
        public int Hour { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
