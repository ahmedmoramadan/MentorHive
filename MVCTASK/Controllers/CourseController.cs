using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTASK.Data;
using MVCTASK.Models;
using MVCTASK.ViewModels.CourseVM;
using MVCTASK.ViewModels.instractorVM;

namespace MVCTASK.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Courses = _context.courses.Include(d=>d.Department);
            return View(Courses);
        }
        public IActionResult Result(int id)
        {
            IEnumerable<CrsReselt> CR = _context.crsReselts.AsNoTracking().Include(c => c.Course).Include(t => t.Trainee).Where(c => c.CourseId == id);

            List<CourseResultVM> CRVM = new List<CourseResultVM>();
            foreach (var c in CR)
            {
                CourseResultVM cVM = new CourseResultVM()
                {
                    trainee = c.Trainee.Name,
                    Course = c.Course.Name,
                    color = c.Course.MinDegree > c.Gredee ? "red" : "blue"
                };
                CRVM.Add(cVM);
            }
            return View(CRVM);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCourseVM addCourseVM = new AddCourseVM()
            {
                Departments = _context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList(),
            };
            return View(addCourseVM);
        }
        [HttpPost]
        public IActionResult Add(AddCourseVM model)
        {
            if (!ModelState.IsValid)
            {
                AddCourseVM addCourseVM = new AddCourseVM()
                {
                    Degree = model.Degree,
                    Hour = model.Hour,
                    DepartmentId = model.DepartmentId,
                    MinDegree = model.MinDegree,
                    Name = model.Name,
                    Departments = _context.departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList(),
                };
                return View(addCourseVM);
            }
            Course CRS = new Course()
            {
                Name = model.Name,
                MinDegree = model.MinDegree,
                DepartmentId = model.DepartmentId,
                Degree = model.Degree,
                Hour = (int)model.Hour,

            };
            _context.Add(CRS);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
