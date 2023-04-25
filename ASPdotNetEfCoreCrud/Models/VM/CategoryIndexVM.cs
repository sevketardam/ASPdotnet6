using ASPdotNetEfCoreCrud.Entities;

namespace ASPdotNetEfCoreCrud.Models.VM
{
    public class CategoryIndexVM
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
