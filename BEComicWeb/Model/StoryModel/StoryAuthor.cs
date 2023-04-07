using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryAuthor
    {
        [Key]
        [Required]
        public string? AuthorId { get; set; }
        [Key]
        [Required]
        public string? StoryId { get; set; }
        public DateTime? Created { get; set; }
    }
    
}