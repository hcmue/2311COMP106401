using Microsoft.AspNetCore.Mvc;

namespace MyLayout.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CumtomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
