using Microsoft.AspNetCore.Mvc;

namespace Ch02FutureValueHillaker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Mary";
            ViewBag.FV = 9999.99;
            return View();
        }
    }
}
