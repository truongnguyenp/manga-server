using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Model.ChapterModel
{
    public class ChapterData
    {
        public Chapters Chapter { get; set; }
        public List<ChapterImages> ChapterImagesList { get; set; }
        public int Likes { get; set; }
    }
}
