using FirstResponsiveWebAppHillaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppHillaker.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CalcAgeModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.Age = model.CalcAge();
            }
            else
            {
                ViewBag.Age = 0;
            }
            return View(model);
        }
    }
}
