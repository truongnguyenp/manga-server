using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;

namespace BEComicWeb.Controllers
{
    public class StoryFollowsController : Controller
    {
        private readonly IStoryFollowsRepository _IStoryFollowsRepository;

        public StoryFollowsController(IStoryFollowsRepository IStoryFollowsRep)
        {
            _IStoryFollowsRepository = IStoryFollowsRep;
        }

        [HttpPost]
        public async Task<ActionResult<StoryFollows>> Follow(string storyId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IStoryFollowsRepository.Follow(storyId, User.Identity.Name));
            }
            return null;
        }
        [HttpGet("check/{storyId}")]
        public async Task<ActionResult<bool>> IsFollowd(string storyId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IStoryFollowsRepository.IsFollowed(storyId, User.Identity.Name));
            }
            return null;
        }
        [HttpDelete("{storyId}")]
        public async Task<ActionResult<StoryFollows>> UnFollow(string storyId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IStoryFollowsRepository.UnFollow(storyId, User.Identity.Name));
            }
            return null;
        }
    }
}
