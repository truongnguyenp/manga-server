using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.ImageModel
{
    public class ChapterImages
    {
        [Key]
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public int Order { get; set; }
        [ForeignKey("ChapterId")]
        public Chapters? Chapter { get; set; }  
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set;}
        public ChapterImages()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
