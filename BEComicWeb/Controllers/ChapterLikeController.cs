using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Responsitory.StoryResponsitory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEComicWeb.Controllers
{
    [Route("chapterlike")]
    [ApiController]
    public class ChapterLikeController : ControllerBase
    {
        private readonly IChapterLikesRepository _IChapterLikesRepository;

        public ChapterLikeController(IChapterLikesRepository IChapterLikesRep)
        {
            _IChapterLikesRepository = IChapterLikesRep;
        }

        [HttpPost]
        public async Task<ActionResult<ChapterLikes>> Like(string chapterId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IChapterLikesRepository.Like(chapterId, User.Identity.Name));
            }
            return null;
        }
        [HttpGet("check/{chapterId}")]
        public async Task<ActionResult<bool>> IsLiked(string chapterId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IChapterLikesRepository.IsLiked(chapterId, User.Identity.Name));
            }
            return null;
        }
        [HttpDelete("{chapterId}")]
        public async Task<ActionResult<ChapterLikes>> UnLike(string chapterId)
        {
            if (User.Identity.Name != null)
            {
                return await Task.FromResult(_IChapterLikesRepository.UnLike(chapterId, User.Identity.Name));
            }
            return null;
        }
    }
}
