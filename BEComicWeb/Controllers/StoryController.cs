using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BEComicWeb.Repository.StoryRepository;

namespace BEComicWeb.Controllers
{
    [Route("story")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository _IStoryRepository;

        public StoryController(IStoryRepository IStoryRes)
        {
            _IStoryRepository = IStoryRes;
        }

        // Get List of stories.
        // Type: Search --> Return {n_stories} stories which their names have {categ} for page {page}.
        // Type: Category --> Return {n_stories} stories which their categories has {categ} for page {page}.
        // Type: Newest --> Return the top {n_stories} newest stories for page {page}. 
        // GET: {type}/{categ}/{page}
        [HttpGet("list/{type}/{categ}/{page}")]
        public async Task<ActionResult<IEnumerable<Stories>>> Get(string categ, int page, int n_stories, string type)
        {
            return await Task.FromResult(_IStoryRepository.GetStoryList(categ, page, n_stories, type));
        }

        // Get Story by Id
        // GET story/{id}
        [HttpGet("{story_id}")]
        public async Task<ActionResult<Stories>> Get(string id)
        {
            var story= await Task.FromResult(_IStoryRepository.GetStory(id));
            if (story == null)
            {
                return NotFound();
            }
            return story;
        }

        // Create new Story
        // POST story
        [HttpPost("new")]
        public async Task<ActionResult<Stories>> Post(Stories Story)
        {
            _IStoryRepository.AddStory(Story);
            return await Task.FromResult(Story);
        }

        // Update Story if this story is existed.
        // PUT story/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Stories>> Put(string id, Stories Story)
        {
            if (id != Story.Id)
            {
                return BadRequest();
            }
            try
            {
                _IStoryRepository.UpdateStory(Story);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(Story);
        }

        // Delete Story
        // Note: We need warning user before delete
        // DELETE story/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Stories>> Delete(string? id)
        {
            var Story = _IStoryRepository.DeleteStory(id);
            return await Task.FromResult(Story);
        }

        private bool StoryExists(string id)
        {
            return _IStoryRepository.CheckStoryExists(id);
        }
    }
}
