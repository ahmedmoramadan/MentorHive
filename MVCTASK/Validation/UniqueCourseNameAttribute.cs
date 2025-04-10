using System.ComponentModel.DataAnnotations;
using MVCTASK.Data;
using MVCTASK.ViewModels.CourseVM;

namespace MVCTASK.Validation
{
    public class UniqueCourseNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _context = (AppDbContext?)validationContext.GetService(typeof(AppDbContext));
            if (_context == null)
            {
                throw new InvalidOperationException("AppDbContext is not available from the ValidationContext.");
            }
            var editCourseVM = validationContext.ObjectInstance as EditCourseVM;
            var addCourseVM = validationContext.ObjectInstance as AddCourseVM;
            if (editCourseVM == null && addCourseVM == null)
            {
                return new ValidationResult("Invalid course data.");
            }


            string name = value?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("Course name is required.");
            }

            if (addCourseVM != null)
            {
                bool courseExists = _context.courses.Any(x =>
                    x.Name == name && x.DepartmentId == addCourseVM.DepartmentId);

                if (courseExists)
                {
                    return new ValidationResult("This course already exists in this department.");
                }
            }
            // no 
            if (editCourseVM != null)
            {
                bool courseExists = _context.courses.Where(i=>i.Id!= editCourseVM.id).Any(x =>
                    x.Name == name && x.DepartmentId == editCourseVM.DepartmentId);

                if (courseExists)
                {
                    return new ValidationResult("This course already exists in this department.");
                }
            }

            return ValidationResult.Success;
        }
    }

}


