using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryResponse
    {
        public List<Stories> GetStoryList(string? categ, int number, int n_chapters = 30, string type = "category");
        public int GetStoryListSize(string? categ, string? type);
        public Stories? GetStory(string? id);
        public bool AddStory(Stories? story);
        public bool UpdateStory(Stories? story);
        Stories DeleteStory(string? id);
        public bool CheckStoryExists(string? id);
    }
}
