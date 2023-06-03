using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.ChapterModel
{
    public class ChapterLikes
    {
        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ChapterId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
