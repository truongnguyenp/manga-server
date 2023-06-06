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
        public async Task<ActionResult<StoryFollows>> ChangeFollowStatus(string storyId, string userName)
        {
            return await Task.FromResult(_IStoryFollowsRepository.ChangeFollowStatus(storyId, userName));
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
    }
}
