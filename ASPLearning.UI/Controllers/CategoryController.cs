using ASPLearning.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace ASPLearning.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var cList = new List<CategoryViewModel>();
            cList.Add(new CategoryViewModel
            {
                Description = "Açıklama1",
                Name = "Kategori1",
            });

            cList.Add(new CategoryViewModel
            {
                Description = "Açıklama2",
                Name = "Kategori2",
            });

            return View(cList);
        }

        [HttpGet("kategori-ekle")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost("kategori-ekle", Name = "kategoriEkle")]
        public IActionResult AddCategory(CategoryCreateInputModel category)
        {
            if (ModelState.IsValid)
            {
                bool isExist = true;
                if (isExist)
                {
                    ModelState.AddModelError("Name", "Aynı");
                }
                else
                {
                    //dbden aynı isimden kategori var mı yokmu kontrolu
                }
            }
            else
            {
                ModelState.AddModelError("Name", "Bilinmeyen bir hata oluştu");
            }
            return View();
        }
    }
}
