using Microsoft.AspNetCore.Mvc;
using OlympicFlags.Models;

namespace OlympicFlags.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveCategory = session.GetActiveCategory(),
                ActiveGame = session.GetActiveGames(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(CountryListViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveCategory = session.GetActiveCategory(),
                ActiveGame = session.GetActiveGames()
            });
        }
    }
}
