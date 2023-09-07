using Microsoft.AspNetCore.Mvc;
using ContactsHillaker.Models;

namespace ContactsHillaker.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var contacts = context.contacts.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(contacts);
        }
    }
}
