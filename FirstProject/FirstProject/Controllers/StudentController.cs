using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student sv)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }
    }
}
