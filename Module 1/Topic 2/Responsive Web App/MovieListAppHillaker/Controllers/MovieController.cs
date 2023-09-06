using Microsoft.AspNetCore.Mvc;
using MovieListAppHillaker.Models;

namespace MovieListAppHillaker.Controllers
{
    public class MovieController : Controller
    {

        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Movie());
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                    context.Movies.Add(movie);
                else
                    context.Movies.Update(movie);
                    context.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete( int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
