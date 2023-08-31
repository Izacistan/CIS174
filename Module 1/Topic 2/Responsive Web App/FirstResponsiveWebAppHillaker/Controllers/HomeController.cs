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
                ViewBag.CurrentAge = model.CalcCurrentAge();
                ViewBag.Age = model.CalcAge();
            }
            else
            {
                ViewBag.CurrentAge = 0;
            }
            return View(model);
        }
    }
}
