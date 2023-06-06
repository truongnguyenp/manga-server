using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Model.ChapterModel
{
    public class BaseChapterData
    {
        public Chapters Chapter { get; set; }
        public List<ChapterImages> ChapterImagesList { get; set; }
    }
    public class ChapterData : BaseChapterData
    {
        public int Likes { get; set; }
    }
}
