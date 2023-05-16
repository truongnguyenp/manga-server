using BEComicWeb.Model.ImageModel;

namespace BEComicWeb.Interface.ImageInterface
{
    public interface IChapterImagesRepository
    {
        public List<ChapterImages> GetChapterImages(string chapter_id);
        public List<ChapterImages> DeleteChapterImages(string chapter_id);
        public Task<List<ChapterImages>> UpdateChapterImages(string chapter_id, List<ChapterImages> chapterImages);
        public ChapterImages AddChapterImage(ChapterImages ChapterImage);
    }
}
