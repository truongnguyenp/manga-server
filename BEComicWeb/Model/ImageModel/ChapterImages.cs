using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.ImageModel
{
    [Keyless]
    public class ChapterImages
    {
        [ForeignKey("ImageId")]
        public Image? ChapterImage { get; set; }
        public int Order { get; set; }
        [ForeignKey("ChapterId")]
        public Chapters? Chapter { get; set; }  
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
