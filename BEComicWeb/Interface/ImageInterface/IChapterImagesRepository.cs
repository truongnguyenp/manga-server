using BEComicWeb.Model.ImageModel;

namespace BEComicWeb.Interface.ImageInterface
{
    public interface IChapterImagesRepository
    {
        public List<ChapterImages> GetChapterImages(string chapter_id);
        public List<ChapterImages> DeleteChapterImages(string chapter_id);
        public List<ChapterImages> UpdateChapterImages(string chapter_id);
        public ChapterImages AddChapterImage(ChapterImages ChapterImage);
    }
}
