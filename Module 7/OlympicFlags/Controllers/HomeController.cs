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
            // store selected Category and Games IDs in view bag
            ViewBag.ActiveCategory = activeCategory;
            ViewBag.ActiveGame = activeGame;

            // get list of Categories and Games from database
            List<Category> categories = context.Categories.ToList();
            List<Games> games = context.Game.ToList();

            // insert default "All" value at front of each list
            categories.Insert(0, new Category { CategoryID = "all", CategoryName = "All" });
            games.Insert(0, new Games { GamesID = "all", GamesName = "All" });

            // store lists in view bag
            ViewBag.Categories = categories;
            ViewBag.Games = games;

            // get Countries - filter by Category and Games
            IQueryable<Country> query = context.Countries;
            if (activeCategory != "all")
                query = query.Where(
                    t => t.Category.CategoryID.ToLower() == activeCategory.ToLower());
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GamesID.ToLower() == activeGame.ToLower());

            // pass Countries to view as model
            var countries = query.ToList();
            return View(countries);
        }
    }
}