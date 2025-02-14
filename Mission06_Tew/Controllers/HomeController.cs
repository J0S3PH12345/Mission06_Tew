using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Tew.Models;

namespace Mission06_Tew.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp) //Constructor
        { 
            _context= temp;
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
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response); //Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }

    }
}
