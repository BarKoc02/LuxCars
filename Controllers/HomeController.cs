using System.Diagnostics;
using LuxCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuxCars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!Request.Cookies.ContainsKey("LastVisit"))
            {
                Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd-MM-yyyy"), new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    HttpOnly = true
                });
            }

            HttpContext.Session.SetString("UserSession", "ActiveUserSession");

            ViewData["LastVisit"] = Request.Cookies["LastVisit"] ?? "No prior visits";
            ViewData["UserSession"] = HttpContext.Session.GetString("UserSession") ?? "Session unactive";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateLastVisit()
        {
            Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd-MM-yyyy"), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true
            });

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
