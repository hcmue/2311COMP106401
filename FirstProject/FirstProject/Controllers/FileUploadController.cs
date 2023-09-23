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
            if (MyFile != null)
            {
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
                catch (Exception ex)
                {
                    TempData["ThongBao"] = $"Lỗi Upload file: {ex.Message}";
                }
            }
            return Redirect("Index");
        }

        public IActionResult HandleUploadFiles(List<IFormFile> MyFiles)
        {
            foreach(var MyFile in MyFiles)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", MyFile.FileName);
                using (var file = new FileStream(filePath, FileMode.CreateNew))
                {
                    MyFile.CopyTo(file);
                }
            }
            return Redirect("Index");
        }
    }
}
