using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCTASK.Models;

namespace MVCTASK.ViewModels.CourseVM
{
    public class SearchCourseVM
    {
        public string Name { get; set; } = default!;
        [Display(Name = "Department")]
        public int Departmentid { get; set; } = default!;
        public List<SelectListItem> SelectDepartment { get; set; } = new List<SelectListItem>();

    }
}
