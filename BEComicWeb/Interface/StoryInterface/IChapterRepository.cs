using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IChapterRepository
    {
        public List<Chapters> GetChaptersList(string? categ, int number, int n_chapters, string type);
        public List<Chapters> GetAllChaptersOfStory(string story_id);
        public Chapters GetChapter(string chapter_id);
        public bool AddChapter(Chapters chapter, string story_id, int chapter_number);
        public bool UpdateChapter(Chapters chapter);
        public Chapters DeleteChapter(string id);
        public bool CheckChapterExists(string id);
    }
}
