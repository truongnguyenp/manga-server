using BEComicWeb.Model.ChapterModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IChapterRepository
    {
        public ChapterData CreateNewChapter(ChapterData chapterData);
        public ChapterData UpdateChapter(ChapterData chapterData);
        public ChapterData DeleteChapter(string id);
        public ChapterData GetChapter(string id);
        public Chapters GetNewestChapterOfStory(string story_id);
        public List<Chapters> GetAllChaptersOfStory(string story_id);
        public bool IsChapterExists(Chapters chapter);
        public bool IsChapterImageExists(ChapterImages chapterImages);
    }
}
