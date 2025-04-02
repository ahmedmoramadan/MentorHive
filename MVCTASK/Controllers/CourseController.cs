using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTASK.Data;
using MVCTASK.Models;
using MVCTASK.ViewModels;

namespace MVCTASK.Controllers
{
    public class CourseController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result(int id)
        {
            IEnumerable<CrsReselt> CR = _context.crsReselts.AsNoTracking().Include(c => c.Course).Include(t => t.Trainee).Where(c => c.CourseId == id);
            
            List<CourseResultVM> CRVM = new List<CourseResultVM>();
            foreach (var c in CR) {
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
    }
}
