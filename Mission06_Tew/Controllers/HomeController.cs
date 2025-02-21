using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Tew.Models;

namespace Mission06_Tew.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp) //Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GettoKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        //See full collection
        public IActionResult FullCollection()
        {
            var movieList = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movieList);
        }

        //Edit Get Request
        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == movieId);

            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();


            return View("MovieForm", recordToEdit);
        }

        //Edit Post request
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();
            return RedirectToAction("FullCollection");
        }

        //Delete Get Request
        [HttpGet]
        public IActionResult Delete(int movieId)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == movieId);

            return View(recordToDelete);
        }

        //Delete Post request
        [HttpPost]
        public IActionResult Delete(Movie deletedMovie)
        {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();

            return RedirectToAction("FullCollection");
        }
    }

}
