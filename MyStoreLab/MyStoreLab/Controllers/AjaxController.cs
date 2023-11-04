using Microsoft.AspNetCore.Mvc;
using MyStoreLab.Data;
using MyStoreLab.Models;

namespace MyStoreLab.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public AjaxController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult DongHo()
        {
            return View();
        }

        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"));
        }

        #region Search
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var data = _ctx.HangHoas
                .Where(hh => hh.TenHh.Contains(keyword))
                .Select(hh => new HangHoaVM
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia ?? 0,
                    Hinh = hh.Hinh ?? string.Empty,
                    Loai = hh.MaLoaiNavigation.TenLoai
                }).ToList();
            return PartialView("HangHoaView", data);
        }
        #endregion
    }
}
