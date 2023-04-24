namespace ASPLearning.UI.Models.VM
{
    public class CategoryViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public CategoryViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
