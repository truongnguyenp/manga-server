using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BEComicWeb.Responsitory.StoryResponsitory;

namespace BEComicWeb.Controllers
{
    [Route("story")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryResponse _IStoryResponse;

        public StoryController(IStoryResponse IStoryRes)
        {
            _IStoryResponse = IStoryRes;
        }

        // GET: story/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Stories>>> Get()
        {
            return await Task.FromResult(_IStoryResponse.GetStoryDetails());
        }

        // GET story/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Stories>> Get(string id)
        {
            var Stories = await Task.FromResult(_IStoryResponse.GetStoryDetail(id));
            if (Stories == null)
            {
                return NotFound();
            }
            return Stories;
        }

        // POST story
        [HttpPost]
        public async Task<ActionResult<Stories>> Post(Stories Story)
        {
            _IStoryResponse.AddStory(Story);
            return await Task.FromResult(Story);
        }

        // PUT story/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Stories>> Put(string id, Stories Story)
        {
            if (id != Story.Id)
            {
                return BadRequest();
            }
            try
            {
                _IStoryResponse.UpdateStory(Story);
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

        // DELETE story/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Stories>> Delete(string id)
        {
            var Story = _IStoryResponse.DeleteStory(id);
            return await Task.FromResult(Story);
        }

        private bool StoryExists(string id)
        {
            return _IStoryResponse.CheckStoryExists(id);
        }
    }
}
