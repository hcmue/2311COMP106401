using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Other()
        {
            return View("Index");
        }

        public IActionResult ChuyenTrang()
        {
            return Redirect("/Home/Privacy");
        }

        public IActionResult ChuyenTrangKhac()
        {
            //return RedirectToAction("Privacy", "Home");
            return RedirectToAction(actionName: "Privacy", controllerName: "Home");
        }
    }
}
