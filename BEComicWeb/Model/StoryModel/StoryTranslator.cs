using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryTranslator
    {
        [Key]
        [Required]
        public string? StoryId { get; set;}
        [Key]
        [Required]
        public string? TranslatorId { get; set; }
        public DateTime? Created { get; set; }
    }
}
