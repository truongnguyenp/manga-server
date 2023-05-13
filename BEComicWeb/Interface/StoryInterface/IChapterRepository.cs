using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IChapterRepository
    {
        public Chapters GetNewestChapterOfStory(string story_id);
        public Chapters GetChapter(string chapter_id);
        public Chapters AddChapter(Chapters chapter);
        public Chapters UpdateChapter(Chapters chapter);
        public Chapters DeleteChapter(string id);
        public bool CheckChapterExists(string id);
    }
}
