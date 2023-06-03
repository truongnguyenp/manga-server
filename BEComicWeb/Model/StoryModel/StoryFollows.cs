using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryFollows
    {
        [Key]
        [Column(Order = 1)]
        public string StoryId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
