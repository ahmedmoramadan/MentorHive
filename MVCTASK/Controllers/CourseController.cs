using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVCTASK.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICoursesService _coursesService;
        private readonly IDepartmentsService _departmentsService;
        //private readonly AppDbContext _context;
        public CourseController(ICoursesService coursesService , IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
            _coursesService = coursesService;
            //_context = context;
        }
        public IActionResult Search(string Name, int? DepartmentId)
        {
            var courses = _coursesService.Search(Name);
            return View("Index", courses);
        }
      
        public IActionResult Index()
        {
            var Courses = _coursesService.GetAll();
            return View(Courses);
        }
        public IActionResult Result(int id)
        {
            //IEnumerable<CrsReselt> CR = _context.crsReselts.AsNoTracking().Include(c => c.Course).Include(t => t.Trainee).Where(c => c.CourseId == id);

            //List<CourseResultVM> CRVM = new List<CourseResultVM>();
            //foreach (var c in CR)
            //{
            //    CourseResultVM cVM = new CourseResultVM()
            //    {
            //        trainee = c.Trainee.Name,
            //        Course = c.Course.Name,
            //        color = c.Course.MinDegree > c.Gredee ? "red" : "blue"
            //    };
            //    CRVM.Add(cVM);
            //}
            //return View(CRVM);
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCourseVM addCourseVM = new AddCourseVM()
            {
                Departments = _departmentsService.GetDepartments()
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
                    Departments = _departmentsService.GetDepartments()
                };
                return View(addCourseVM);
            }
            _coursesService.Add(model);
            int c=  _coursesService.save();

            //Course CRS = new Course()
            //{
            //    Name = model.Name,
            //    MinDegree = model.MinDegree,
            //    DepartmentId = model.DepartmentId,
            //    Degree = model.Degree,
            //    Hour = (int)model.Hour,

            //};
            //_context.Add(CRS);
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CheckDegree(int Degree ,int MinDegree) 
        {
            if (Degree <= 100 && Degree >= 50 && MinDegree <Degree)
            {
                
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Edit(int id)
        {
            var c = _coursesService.GetbyId(id);
            EditCourseVM editCourseVM = new EditCourseVM()
            {
                id = id,
                Name = c!.Name,
                MinDegree = c!.MinDegree,
                DepartmentId = c!.DepartmentId,
                Degree = c!.Degree,
                Hour = (int)c!.Hour,
                Departments = _departmentsService.GetDepartments()
            };
            return View(editCourseVM);
        }
        [HttpPost]
        public IActionResult Edit(EditCourseVM model)
        {
            if (!ModelState.IsValid)
            {
                EditCourseVM editCourseVM = new EditCourseVM()
                {
                    id = model.id,
                    Name = model.Name,
                    MinDegree = model.MinDegree,
                    DepartmentId = model.DepartmentId,
                    Degree = model.Degree,
                    Hour = (int)model.Hour,
                    Departments = _departmentsService.GetDepartments()
                };
                return View(editCourseVM);
            }
            _coursesService.Edit(model);
            _coursesService.save();
            //var c = _context.courses.FirstOrDefault(x=>x.Id == model.id);
            //c.Degree=model.Degree;
            //c.Hour=model.Hour;
            //c.DepartmentId=model.DepartmentId;
            //c.MinDegree =model.MinDegree;
            //c.Name=model.Name;
            //_context.Update(c);
            //_context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Remove(int id)
        {
            _coursesService.delete(id);
            _coursesService.save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ValidateHour(int hour)
        {
            if (hour % 3 == 0 && hour != 0) 
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
