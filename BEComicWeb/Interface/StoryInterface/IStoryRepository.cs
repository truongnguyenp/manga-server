using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryRepository
    {
        public List<Stories> GetNewestStoryList(int page, int n_stories = 30);
        public List<Stories> SearchStory(string search_string, int page, int n_stories = 30);
        public int GetSearchStoryListSize(string? search_string);
        public Stories? GetStory(string? id);
        public bool AddStory(Stories? story);
        public bool UpdateStory(Stories? story);
        Stories DeleteStory(string? id);
        public bool CheckStoryExists(string? id);
    }
}
