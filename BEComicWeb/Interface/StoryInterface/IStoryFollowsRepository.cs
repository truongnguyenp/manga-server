using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IStoryFollowsRepository
    {
        public StoryFollows Follow(string storyId, string userName);
        public StoryFollows UnFollow(string storyId, string userName);
        public bool IsFollowed(string storyId, string userName);
    }
}
