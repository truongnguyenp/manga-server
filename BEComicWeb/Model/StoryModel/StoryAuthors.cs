using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryAuthors
    {
        [Key]
        [Column(Order = 1)]
        public string? AuthorId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string? StoryId { get; set; }
        public DateTime? Created { get; set; }
    }
    
}