using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.ChapterModel
{
    public class ChapterImages
    {
        [Key]
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public int Order { get; set; }

        public string ChapterId { get; set; }
        public ChapterImages()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
