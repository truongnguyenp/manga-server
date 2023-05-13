using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryHistoryRepository
    {
        public List<StoryHistory> GetStoryHistory(string user_id, int page, int n_stories);
        public int GetStoryHistorySize(string user_id);
        public StoryHistory AddNewStoryHistory(StoryHistory storyHistory);
        public StoryHistory DeleteStoryHistory(StoryHistory history);

    }
}
