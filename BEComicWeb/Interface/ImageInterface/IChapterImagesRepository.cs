using BEComicWeb.Model.ImageModel;

namespace BEComicWeb.Interface.ImageInterface
{
    public interface IChapterImagesRepository
    {
        public List<string> GetChapterImages(string chapter_id);
        public List<string> DeleteChapterImages(string chapter_id);
        public List<string> UpdateChapterImages(string chapter_id);
        public ChapterImages AddChapterImage(ChapterImages ChapterImage);
    }
}
