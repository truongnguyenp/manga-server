using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryHistoryRepository
    {
        public List<StoryHistories> GetStoryHistory(string user_id, int page, int n_stories);
        public int GetStoryHistorySize(string user_id);
        public StoryHistories AddNewStoryHistory(StoryHistories storyHistory);
        public StoryHistories DeleteStoryHistory(StoryHistories history);

    }
}
