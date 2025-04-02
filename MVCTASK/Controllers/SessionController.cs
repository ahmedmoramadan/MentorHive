using Microsoft.AspNetCore.Mvc;

namespace MVCTASK.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetInt32("age", 22);
            int? myAge = HttpContext.Session.GetInt32("age"); 

            return Content($"Age is added");
        }
        public IActionResult GetSession()
        {
            int? myAge = HttpContext.Session.GetInt32("age");

            if (myAge.HasValue)
            {
                return Content($"Age from session is {myAge}");
            }
            else
            {
                return Content("No age found in session.");
            }
        }


    }
}
