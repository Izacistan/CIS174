using AssignmentsHillaker.Models.Data_Transfer_Olympics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssignmentsHillaker.Controllers.Data_Transfer_Olympics_Controllers
{
    public class OlympicController : Controller
    {
        public ActionResult OlympicHome(string selectedGame = "ALL", string selectedCategory = "ALL")
        {
            List<Country> countries = GetCountries();

            ViewBag.GameOptions = GetGameOptions();
            ViewBag.CategoryOptions = GetCategoryOptions();

            if (selectedGame != "ALL")
            {
                countries = countries.Where(c => c.Game == selectedGame).ToList();
            }

            if (selectedCategory != "ALL")
            {
                countries = countries.Where(c => c.Category == selectedCategory).ToList();
            }



            // Sort countries alphabetically
            countries = countries.OrderBy(c => c.Name).ToList();

            return View("~/Views/Data_Transfer_Olympics/OlympicHome.cshtml", countries);
        }

        [HttpPost]
        public ActionResult OlympicHome()
        {
            string selectedGame = Request.Form["selectedGame"];
            string selectedCategory = Request.Form["selectedCategory"];

            return RedirectToAction("OlympicHome", new { selectedGame, selectedCategory });
        }

        private List<SelectListItem> GetGameOptions()
        {
            List<string> distinctGames = GetCountries().Select(c => c.Game).Distinct().ToList();

            var gameOptions = distinctGames.Select(game => new SelectListItem { Value = game, Text = game }).ToList();
            gameOptions.Insert(0, new SelectListItem { Value = "ALL", Text = "ALL" });

            return gameOptions;
        }

        private List<SelectListItem> GetCategoryOptions()
        {
            List<string> distinctCategories = GetCountries().Select(c => c.Category).Distinct().ToList();

            var categoryOptions = distinctCategories.Select(category => new SelectListItem { Value = category, Text = category }).ToList();
            categoryOptions.Insert(0, new SelectListItem { Value = "ALL", Text = "ALL" });

            return categoryOptions;
        }

        private List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>
        {
            new Country { Name = "Canada", Game = "Winter Olympics", Category = "Curling/Indoor", FlagImagePath = "/content/flags/canada.jpg" },
            new Country { Name = "Sweden", Game = "Winter Olympics", Category = "Curling/Indoors", FlagImagePath = "/content/flags/sweden.jpg" },
            new Country { Name = "Great Britain", Game = "Winter Olympics", Category = "Curling/Indoor", FlagImagePath = "/content/flags/great_britain.jpg" },
            new Country { Name = "Jamaica", Game = "Winter Olympics", Category = "Bobsleigh/Outdoor", FlagImagePath = "/content/flags/jamaica.jpg" },
            new Country { Name = "Italy", Game = "Winter Olympics", Category = "Bobsleigh/Outdoor", FlagImagePath = "/content/flags/italy.jpg" },
            new Country { Name = "Japan", Game = "Winter Olympics", Category = "Bobsleigh/Outdoor", FlagImagePath = "/content/flags/japan.jpg" },
            new Country { Name = "Germany", Game = "Summer Olympics", Category = "Diving/Indoor", FlagImagePath = "/content/flags/germany.jpg" },
            new Country { Name = "China", Game = "Summer Olympics", Category = "Diving/Indoor", FlagImagePath = "/content/flags/china.jpg" },
            new Country { Name = "Mexico", Game = "Summer Olympics", Category = "Diving/Indoor", FlagImagePath = "/content/flags/mexico.jpg" },
            new Country { Name = "Brazil", Game = "Summer Olympics", Category = "Road Cycling/Outdoor", FlagImagePath = "/content/flags/brazil.jpg" },
            new Country { Name = "Netherlands", Game = "Summer Olympics", Category = "Cycling/Outdoor", FlagImagePath = "/content/flags/netherlands.jpg" },
            new Country { Name = "United States", Game = "Summer Olympics", Category = "Road Cycling/Outdoor", FlagImagePath = "/content/flags/united_states.jpg" },
            new Country { Name = "Thailand", Game = "Paralympics", Category = "Archery/Indoor", FlagImagePath = "/content/flags/thailand.jpg" },
            new Country { Name = "Ukraine", Game = "Paralympics", Category = "Archery/Indoor", FlagImagePath = "/content/flags/ukraine.jpg" },
            new Country { Name = "Uruguay", Game = "Paralympics", Category = "Archery/Indoor", FlagImagePath = "/content/flags/uruguay.jpg" },
            new Country { Name = "Austria", Game = "Paralympics", Category = "Canoe Sprint/Outdoor", FlagImagePath = "/content/flags/austria.jpg" },
            new Country { Name = "Pakistan", Game = "Paralympics", Category = "Canoe Sprint/Outdoor", FlagImagePath = "/content/flags/pakistan.jpg" },
            new Country { Name = "Zimbabwe", Game = "Paralympics", Category = "Canoe Sprint/Outdoor", FlagImagePath = "/content/flags/zimbabwe.jpg" },
            new Country { Name = "France", Game = "Youth Olympic Games", Category = "Breakdancing/Indoor", FlagImagePath = "/content/flags/france.jpg" },
            new Country { Name = "Cyprus", Game = "Youth Olympic Games", Category = "Breakdancing/Indoor", FlagImagePath = "/content/flags/cyprus.jpg" },
            new Country { Name = "Russia", Game = "Youth Olympic Games", Category = "Breakdancing/Indoor", FlagImagePath = "/content/flags/russia.jpg" },
            new Country { Name = "Finland", Game = "Youth Olympic Games", Category = "Skateboarding/Outdoor", FlagImagePath = "/content/flags/finland.jpg" },
            new Country { Name = "Slovakia", Game = "Youth Olympic Games", Category = "Skateboarding/Outdoor", FlagImagePath = "/content/flags/slovakia.jpg" },
            new Country { Name = "Portugal", Game = "Youth Olympic Games", Category = "Skateboarding/Outdoor", FlagImagePath = "/content/flags/portugal.jpg" }
        };

            return countries;
        }
    }

}
