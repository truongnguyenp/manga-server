using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    public class Chapters
    {
        [Key]
        [Required]
        public string? Id { get; set; }
        [ForeignKey("StoryId")]
        public Stories? Story { get; set; }
        public int? ChapterNumner { get; set; }
        public string? Name { get; set; }
        public int? Cost { get; set; }
        public string? Image { get; set; }
        public int? Views { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public Chapters()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
