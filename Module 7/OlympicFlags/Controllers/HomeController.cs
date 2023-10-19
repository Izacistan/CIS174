using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OlympicFlags.Models;
using System.Diagnostics;

namespace OlympicFlags.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeCategory = "all", string activeGame = "all")
        {

            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveCategory(activeCategory);
            session.SetActiveGames(activeGame);

            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OlympicCookies(HttpContext.Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> myCountries = new List<Country>();
                if (ids.Length > 0)
                    myCountries = context.Countries.Include(t => t.Category)
                        .Include(t => t.Game)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                session.SetMyCountries(myCountries);
            }

            var model = new CountryListViewModel
            {
                ActiveCategory = activeCategory,
                ActiveGame = activeGame,
                Categories = context.Categories.ToList(),
                Games = context.Game.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeCategory != "all")
                query = query.Where(
                    t => t.Category.CategoryID.ToLower() == activeCategory.ToLower());
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GamesID.ToLower() == activeGame.ToLower());
            model.Countries = query.ToList();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Category)
                    .Include(t => t.Game)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveGame = session.GetActiveGames(),
                ActiveCategory = session.GetActiveCategory()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(t => t.Category)
                .Include(t => t.Game)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new OlympicSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new OlympicCookies(HttpContext.Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.CountryName} has added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveCategory = session.GetActiveCategory(),
                    ActiveGame = session.GetActiveGames()
                });
        }
    }
}