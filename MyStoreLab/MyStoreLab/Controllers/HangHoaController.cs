using Microsoft.AspNetCore.Mvc;
using MyStoreLab.Data;
using MyStoreLab.Models;

namespace MyStoreLab.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public HangHoaController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var data = _ctx.HangHoas
                .Select(hh => new HangHoaVM
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia ?? 0,
                    Hinh = hh.Hinh ?? string.Empty,
                    Loai = hh.MaLoaiNavigation.TenLoai
                }).ToList();
            return View(data);
        }

        public IActionResult Search(string? keyword, double? priceFrom, double? priceTo)
        {
            var data = _ctx.HangHoas.AsQueryable();

            if (keyword != null)
            {
                data = data.Where(p => p.TenHh.Contains(keyword));
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
            return View("Index", result);
        }
    }
}
