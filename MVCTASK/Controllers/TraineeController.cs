using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTASK.Data;
using MVCTASK.ViewModels.TraineeVM;

namespace MVCTASK.Controllers
{
    public class TraineeController : Controller
    {
        private readonly AppDbContext _context;
        public TraineeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int Tid , int Cid)
        {
            //var Trainee = _context.trainees.AsNoTracking().FirstOrDefault(x=>x.Id == Tid);
            //var Course = _context.courses.AsNoTracking().FirstOrDefault(c=>c.Id == Cid);
               var CR = _context.crsReselts.AsNoTracking().Include(c=>c.Course).Include(t=>t.Trainee).FirstOrDefault(r=> (r.CourseId == Cid && r.TraineeId == Tid));
            TraineeDataVM TR = new()
            {
                Trainee = CR!.Trainee.Name,
                Course = CR.Course.Name,
                Degree = CR.Gredee,
                Status = (CR.Course!.MinDegree > CR.Gredee) ? "Faied" : "Passed",
                Color = (CR.Course.MinDegree > CR.Gredee) ? "red" : "blue"
            };
            return View(TR);
        }
        
    }
}
