using BEComicWeb.Model.ImageModel;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Model
{
    public class ChapterData
    {
        public Chapters Chapter { get; set; }
        public List<ChapterImages> ChapterImages { get; set; }
    }
}
