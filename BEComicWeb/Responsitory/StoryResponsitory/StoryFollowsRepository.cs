using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class StoryFollowsRepository : IStoryFollowsRepository
    {
        AppDbContext _dbContext = new();
        public StoryFollows Follow(string storyId, string userName)
        {
            var follow = _dbContext.StoryFollowsDb.FirstOrDefault(e => (e.StoryId == storyId && e.UserName == userName));
            if (follow == null)
            {
                StoryFollows foll = new StoryFollows()
                {
                    StoryId = storyId,
                    UserName = userName,
                    CreatedDate = DateTime.Now
                };
                _dbContext.StoryFollowsDb.Add(foll);
                _dbContext.SaveChanges();
                return foll;
            }
            return null;
        }
        public StoryFollows UnFollow(string storyId, string userName)
        {
            var follow = _dbContext.StoryFollowsDb.FirstOrDefault(e => (e.StoryId == storyId && e.UserName == userName));
            if (follow != null)
            {
                _dbContext.StoryFollowsDb.Remove(follow);
                _dbContext.SaveChanges();
                return follow;
            }
            return null;
        }
        public bool IsFollowed(string storyId, string userName)
        {
            var follow = _dbContext.StoryFollowsDb.FirstOrDefault(e => (e.StoryId == storyId && e.UserName == userName));
            if (follow != null)
            {
                return true;
            }
            return false;
        }
    }
}
