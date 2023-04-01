using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IChapterResponse
    {
        public List<Chapters> GetNewChapters();
        public List<Chapters> GetAllChaptersOfStory(string story_id);
        public Chapters GetChapter(string chapter_id);
        public bool AddChapter(Chapters chapter);
        public bool UpdateChapter(Chapters chapter);
        public bool DeleteChapter(string id);
        public bool CheckChapterExists(string id);
    }
}
