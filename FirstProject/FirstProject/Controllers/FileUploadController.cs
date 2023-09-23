using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleUploadFile(IFormFile MyFile)
        {
            ViewBag.FileName = MyFile.FileName;
            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var filePath = Path.Combine(folderPath, MyFile.FileName);
                using (var file = new FileStream(filePath, FileMode.CreateNew))
                {
                    MyFile.CopyTo(file);
                }
                TempData["ThongBao"] = "Upload file thành công";
            }
            catch(Exception ex)
            {
                TempData["ThongBao"] = $"Lỗi Upload file: {ex.Message}";
            }
            return Redirect("Index");
        }
    }
}
