using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryRepository
    {
        public List<StoryData> GetNewestStoryList(int page, int n_stories = 30);
        public int? GetStorySize();
        public List<StoryData> SearchStory(string search_string, int page, int n_stories = 30);
        public int GetSearchStoryListSize(string? search_string);
        public StoryData? GetStory(string? id);
        public StoryData AddStory(StoryData? story);
        public StoryData UpdateStory(StoryData? story);
        Stories DeleteStory(string? id);
        public bool CheckStoryExists(string? id);
        public List<Chapters> GetAllChaptersOfStory(string story_id);
        public List<StoryData> GetFollowStories(string userName, int page, int n_story);
        public int GetFollowStoriesSize(string userName);
    }
}
