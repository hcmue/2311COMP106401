using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.ValueContentAnalysis;
using MyStoreLab.Data;
using MyStoreLab.Models;
using System.Security.Claims;

namespace MyStoreLab.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public KhachHangController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }

        [AllowAnonymous, HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var khachHang = _ctx.KhachHangs.SingleOrDefault(p => p.MaKh == model.Username && p.MatKhau == model.Password);
                if (khachHang == null)
                {
                    ViewBag.ThongBao = "Sai thông tin đăng nhập";
                    return View();
                }

                //Tạo các claim
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, khachHang.HoTen),
                    new Claim(ClaimTypes.Email, khachHang.Email),
                    new Claim("MaKH", khachHang.MaKh),

                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Role, "Accountant"),
                };

                var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("/");
            }
            ViewBag.ThongBao = "Chưa hợp lệ";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
