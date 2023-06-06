using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryFollowsRepository
    {
        public StoryFollows ChangeFollowStatus(string storyId, string userName);
        public bool IsFollowed(string storyId, string userName);
    }
}
