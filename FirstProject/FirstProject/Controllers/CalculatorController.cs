using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double a, double b, string op)
        {
            double kq = 0;
            switch (op)
            {
                case "+": kq = a + b; break;
                case "-": kq = a - b; break;
                case "*": kq = a * b; break;
                case "/": kq = a / b; break;
            }

            ViewBag.KetQua = kq;
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.PhepToan = op;
            return View("Index");
        }
    }
}
