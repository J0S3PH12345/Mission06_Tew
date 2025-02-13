using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Tew.Models;

namespace Mission06_Tew.Controllers
{
    public class HomeController : Controller
    {
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
            return View("Confirmation", response);
        }

    }
}
