using Library.Data.Constants;

namespace Library.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.TitleMaxLength, MinimumLength = DataConstants.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DataConstants.AuthorMaxLength, MinimumLength = DataConstants.AuthorMinLength)]
        public string Author { get; set; }

        [Required]
        [StringLength(DataConstants.DescriptionMaxLength, MinimumLength = DataConstants.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Rating { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public List<ApplicationUserBook> ApplicationUserBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
