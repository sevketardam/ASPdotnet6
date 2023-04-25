using ASPdotNetEfCoreCrud.Entities;
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

        [HttpGet("kategori-sil/{id:int}", Name = "deleteCategory")]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return RedirectToAction("Index","Category");
        }
    }
}
