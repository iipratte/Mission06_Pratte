using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Pratte.Models;
using SQLitePCL;
//using Mission06_Pratte.Models;

namespace Mission06_Pratte.Controllers
{
    public class HomeController : Controller

    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response); // Adds record to the db
            _context.SaveChanges(); // Saves the record to the db

            return View("Index");
        }
    }
}