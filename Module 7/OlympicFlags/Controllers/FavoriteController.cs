using Microsoft.AspNetCore.Mvc;
using OlympicFlags.Models;

namespace OlympicFlags.Controllers
{
    public class FavoriteController : Controller
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
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(HttpContext.Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries removed";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveCategory = session.GetActiveCategory(),
                    ActiveGame = session.GetActiveGames()
                });
        }
    }
}
