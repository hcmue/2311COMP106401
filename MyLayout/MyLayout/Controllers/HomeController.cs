using Microsoft.AspNetCore.Mvc;
using MyLayout.Models;
using System.Diagnostics;

namespace MyLayout.Controllers
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
            return View();
        }

        public IActionResult NoLayout()
        {
            return View();
        }

        public IActionResult Demo()
        {
            var dsLoai = new List<Loai>
            {
                new Loai{MaLoai=1, TenLoai="Bia"},
                new Loai{MaLoai=2, TenLoai="Xe hơi"},
            };
            return PartialView("_Category", dsLoai);
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