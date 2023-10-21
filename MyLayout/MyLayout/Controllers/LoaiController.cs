using Microsoft.AspNetCore.Mvc;
using MyLayout.Data;

namespace MyLayout.Controllers
{
    public class LoaiController : Controller
    {
        private readonly MyDbContext _ctx;
        public LoaiController(MyDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View(_ctx.Loais.ToList());
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Loai model)
        {
            try
            {
                _ctx.Add(model);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
