using AssignmentsHillaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentsHillaker.Controllers
{
    public class _6_1_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/6_1_Controller/AccessLevel")]
        public IActionResult AccessLevel(int level)
        {
            var students = new List<StudentModel>
            {
                new StudentModel { FirstName = "Finley", LastName = "Fisher", Grade = 85 },
                new StudentModel { FirstName = "Gillian", LastName = "Streamson", Grade = 83 },
                new StudentModel { FirstName = "Coralie", LastName = "Swimmer", Grade = 78 },
                new StudentModel { FirstName = "Salmonella ", LastName = "Troutman", Grade = 96 },
                new StudentModel { FirstName = "Nemo", LastName = "Oceanberg", Grade = 92 }
            };

            var viewModel = new StudentListViewModel
            {
                Students = students,
                AccessLevel = level
            };

            return View("/Views/6_1_Controller/6-1.cshtml", viewModel);
        }
    }
}
