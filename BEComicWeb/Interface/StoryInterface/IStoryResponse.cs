using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryResponse
    {
        public List<Stories> GetStoryDetails();
        public Stories? GetStoryDetail(string? id);
        public bool AddStory(Stories? story);
        public bool UpdateStory(Stories? story);
        Stories DeleteStory(string? id);
        public bool CheckStoryExists(string? id);
    }
}
