using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.ImageModel
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
