using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Student()
        {
            var data = new
            {
                MSSV = "4701104404",
                HoTen = "Tèo Nguyễn",
                NamSinh = 2003
            };
            return Json(data);
        }

        public string Hello(string? name)
        {
            return $"Hello ${name}";
        }

        public int LuckyNumber()
        {
            return new Random().Next(1000, 10000);
        } 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}