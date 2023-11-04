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

        public IActionResult JsonSearch(string? keyword, double? priceFrom, double? priceTo)
        {
            var data = _ctx.HangHoas.AsQueryable();
            if (keyword != null)
            {
                data = data.Where(h => h.TenHh.Contains(keyword));
            }
            if (priceFrom != null)
            {
                data = data.Where(p => p.DonGia >= priceFrom);
            }
            if (priceTo != null)
            {
                data = data.Where(p => p.DonGia <= priceTo);
            }
            var result = data.Select(hh => new HangHoaVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia ?? 0,
                Hinh = hh.Hinh ?? string.Empty,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return Json(result);
        }


        public IActionResult TimKiem()
        {
            return View();
        }
    }
}
