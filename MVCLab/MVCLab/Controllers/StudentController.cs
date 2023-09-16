using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;
using System.Text.Json;

namespace MVCLab.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(Student sinhVien, string LuuButton)
        {
            if (LuuButton == "Ghi file JSON")
            {
                //chuyển đổi object sang json
                var jsonString = JsonSerializer.Serialize(sinhVien);
                System.IO.File.WriteAllText(myPathFile, jsonString);
            }
            return View("Index");
        }

        string myPathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student.json");

        public IActionResult OpenData(string type)
        {
            var student = new Student();
            if (type == "JSON")
            {
                var content = System.IO.File.ReadAllText(myPathFile);
                student = JsonSerializer.Deserialize<Student>(content);
            }

            return View("Index", student);
        }
    }
}
