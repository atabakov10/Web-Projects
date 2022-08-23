using System.Collections.Generic;

namespace FastFood.Web.ViewModels.Categories
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Items { get; set; }
    }
}
