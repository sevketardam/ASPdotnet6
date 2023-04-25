using ASPdotNetEfCoreCrud.Entities;
using ASPdotNetEfCoreCrud.Models.IM;
using ASPdotNetEfCoreCrud.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ASPdotNetEfCoreCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly northwindContext context;

        public CategoryController(northwindContext context)
        {
            this.context = context;
        }

        [HttpGet("kategoriler", Name = "ListCategory")]
        public IActionResult Index()
        {
            var cList = context.Categories.ToList();
            var SList = context.Suppliers.ToList();

            var model = new CategoryIndexVM()
            {
                Categories = cList,
                Suppliers = SList
            };


            return View(model);
        }

        [HttpGet("kategori-ekle", Name = "addCategory")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("kategori-ekle", Name = "addCategory")]
        public IActionResult Create(CreateCategoryIM model)
        {
            try
            {
                var newCategory = new Category() { CategoryName = model.CategoryName, Description = model.Description };
                context.Categories.Add(newCategory);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    TempData["Mesaj"] = "Başarıyla Kategori Eklendi";
                }
                else
                {
                    TempData["Mesaj"] = "İşlem Başarısız. Tekrar deneyiniz.";
                    return View();
                }

                return RedirectToAction("Index", "Category");
            }
            catch (Exception)
            {
                ViewBag.Mesaj = "Bir Sorunla Karşılaşıldı Tekrar Deneyiniz.";
                return View();
            }

        }

        [HttpGet("kategori-sil/{id:int}", Name = "deleteCategory")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }


                context.Categories.Remove(category);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    TempData["Mesaj"] = "İşlem Başarılı";
                }
                else
                {
                    TempData["Mesaj"] = "İşlem Başarısız. Tekrar deneyiniz.";
                }

                return RedirectToAction("Index", "Category");
            }
            catch (Exception)
            {
                ViewBag.Mesaj = "Ürünün alt ürünleri olduğu için silemezsiniz";
                return View();
            }

        }


        [HttpGet("kategori-guncelle/{id:int}", Name = "updateCategory")]
        public IActionResult Update(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new UpdateCategoryIM();
            model.Description = category.Description;
            model.CategoryName = category.CategoryName;
            model.Id = category.CategoryId;

            return View(model);
        }


        [HttpPost("kategori-guncelle/{id:int}")]
        public IActionResult Update(UpdateCategoryIM model)
        {
            var category = context.Categories.Find(model.Id);
            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = model.CategoryName;
            category.Description = model?.Description;

            context.Categories.Update(category);
            int result = context.SaveChanges();
            if (result > 0)
            {
                TempData["Mesaj"] = "Başarıyla Güncellendi";
            }
            else
            {
                TempData["Mesaj"] = "İşlem Başarısız. Tekrar deneyiniz.";
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
