using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult CheckExistEmployeeNo(string EmployeeNo)
        {
            var dsNV = new string[] { "admin", "guest", "employee", "mr777", "NV77777" };
            if (dsNV.Contains(EmployeeNo))
            {
                return Json($"Mã {EmployeeNo} đã có");
            }
            return Json(true);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            return View();
        }
    }
}
