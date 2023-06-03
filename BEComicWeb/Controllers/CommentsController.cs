using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BEComicWeb.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository _ICommentsRepository;

        public CommentsController(ICommentsRepository ICommentsyRepo)
        {
            _ICommentsRepository = ICommentsyRepo;
        }
        [HttpGet("chapter/{chapterId}")]
        public async Task<ActionResult<IEnumerable<Comments>>> GetCommentsOfChapter(string chapterId, int page, int n_stories)
        {
            return await Task.FromResult(_ICommentsRepository.GetCommentsOfChapter(chapterId, page, n_stories));
        }
        [HttpGet("chapter/{chapterId}/size")]
        public async Task<ActionResult<int>> GetCommentsSizeOfChapter(string chapterId, int n_chapters)
        {
            return await Task.FromResult((int) Math.Ceiling((double)_ICommentsRepository.GetCommentsSizeOfChapter(chapterId) / n_chapters));
        }
        [HttpGet("story/{storyId}")]
        public async Task<ActionResult<IEnumerable<Comments>>> GetCommentsOfStory(string storyId, int page, int n_stories)
        {
            return await Task.FromResult(_ICommentsRepository.GetCommentsOfChapter(storyId, page, n_stories));
        }
        [HttpGet("story/{storyId}/size")]
        public async Task<ActionResult<int>> GetCommentsSizeOfStory(string storyId, int n_stories)
        {
            return await Task.FromResult((int) Math.Ceiling((double)_ICommentsRepository.GetCommentsSizeOfChapter(storyId) / n_stories));
        }
        [HttpPost("new")]
        public async Task<ActionResult<Comments>> AddNewComment(string chapterId, string title)
        {
            return await Task.FromResult(_ICommentsRepository.AddNewComment(chapterId, title, User.Identity.Name));
        }
        [HttpPut("update/{commentId}")]
        public async Task<ActionResult<Comments>> UpdateComment(string commentId, string newTitle)
        {
            return await Task.FromResult(_ICommentsRepository.UpdateComment(commentId, newTitle, User.Identity.Name));
        }
        [HttpDelete("delete/{commentId}")]
        public async Task<ActionResult<Comments>> DeleteCommentByUser(string commentId)
        {
            return await Task.FromResult(_ICommentsRepository.DeleteCommentByUser(commentId, User.Identity.Name));
        }
        [HttpDelete("admin/delete/{commentId}")]
        public async Task<ActionResult<Comments>> DeleteCommentByAdmin(string commentId)
        {
            return await Task.FromResult(_ICommentsRepository.DeleteComment(commentId));
        }
    }
}
