using System.ComponentModel.DataAnnotations;

namespace ASPLearning.UI.Models.VM
{
    public class CategoryCreateInputModel
    {
        [Required(ErrorMessage ="Kategori Adı boş geçilemez")]
        [MaxLength(20,ErrorMessage ="Maksimum 20 karakter girilebilir")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
    }
}
