using Library.Data.Constants;

namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.NameMaxLength, MinimumLength = DataConstants.NameMinLength)]
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
