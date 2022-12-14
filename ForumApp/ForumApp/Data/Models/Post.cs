using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Posts Identifier")]
        public int Id { get; set; }

        [Comment("Post title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Comment("Content")]
        [Required]
        [MaxLength(ContextMaxLength)]
        public string Content { get; set; }

    }
}
