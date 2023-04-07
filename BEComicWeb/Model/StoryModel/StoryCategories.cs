using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryCategories
    {
        [Key]
        [Required]
        public string? StoryId { get; set; }
        [Key]
        [Required]
        public string? CategoryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
