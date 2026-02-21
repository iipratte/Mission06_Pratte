using Microsoft.AspNetCore.Mvc;
using Mission06_Pratte.Models;
using SQLitePCL;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Pratte.Controllers
{
    public class HomeController : Controller

    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        // Home Page view
        public IActionResult Index()
        {
            return View();
        }

        // Get To Know Joel View
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Get route for adding a movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("AddMovie", new Movie());
        }

        // Post route for submitting a new movie to the databsae
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            // Validate movie before submission
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
                return View(response);
            }
        }

        // Get route for displaying movie database
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList(); // Gets the list of movies from the db

            return View("MovieList", movies); // Passes the list of movies to the view
        }

        // Get route for editing a movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("AddMovie", movieToEdit);
        }

        // Post route for submitting the edited movie to the database
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // Get route for the deletion confirmation screen
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View("Delete", recordToDelete);
        }

        // Post route for the request to delete a movie from the database
        [HttpPost]
        public IActionResult Delete(Movie deletingMovie)
        {
            _context.Remove(deletingMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}