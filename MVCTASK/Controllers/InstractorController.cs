using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using MVCTASK.Data;
using System.Data;

namespace MVCTASK.Controllers
{
    public class InstractorController : Controller
    {
        AppDbContext _db= new AppDbContext();
        public IActionResult Index(int num)
        {
            //var n = num*4;
            var len =  _db.instractores.Count();
            if ((len <= (num -1) * 4)|| (num <= 0)) { 
                num = 1;
            }
            ViewBag.number = num;

            var listinst = _db.instractores.Skip((num - 1) * 4).Take(4);
            return View(listinst);
        }
        public IActionResult Details(int id)
        {
            var instructor = _db.instractores
                     .Include(i => i.Department).Include(c=>c.Course)
                     .FirstOrDefault(x => x.Id == id);
            return View(instructor);
        }
    }
}
