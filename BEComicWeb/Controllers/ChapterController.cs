using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Controllers
{
    [Route("chapter")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterRepository _IChapterRepository;

        public ChapterController(IChapterRepository IChapterRes)
        {
            _IChapterRepository = IChapterRes;
        }

        [HttpGet("{story_id}")]
        public async Task<ActionResult<IEnumerable<Chapters>>> GetAllChaptersOfStory(string story_id)
        {
            return await Task.FromResult(_IChapterRepository.GetAllChaptersOfStory(story_id));
        }

        [HttpGet("{story_id}/newest-chapter")]
        public async Task<ActionResult<Chapters>> GetNewestChapterOfStory(string story_id, string story_name)
        {
            return await Task.FromResult(_IChapterRepository.GetNewestChapterOfStory(story_id));
        }


        // Get Chapter by Id
        // GET Chapter/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapters>> Get(string id)
        {
            var Chapter = await Task.FromResult(_IChapterRepository.GetChapter(id));
            if (Chapter == null)
            {
                return NotFound();
            }
            return Chapter;
        }

        // Create new Chapter
        // POST Chapter
        [HttpPost("new")]
        public async Task<ActionResult<Chapters>> Post(Chapters Chapter)
        {
            return await Task.FromResult(_IChapterRepository.AddChapter(Chapter));
        }

        // Update Chapter if this Chapter is existed.
        // PUT Chapter/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Chapters>> Put(string id, Chapters Chapter)
        {
            if (id != Chapter.Id)
            {
                return BadRequest();
            }
            try
            {
                _IChapterRepository.UpdateChapter(Chapter);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(Chapter);
        }

        // Delete Chapter
        // Note: We need warning user before delete
        // DELETE Chapter/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapters>> Delete(string id)
        {
            var Chapter = _IChapterRepository.DeleteChapter(id);
            return await Task.FromResult(Chapter);
        }
        private bool ChapterExists(string id)
        {
            return _IChapterRepository.CheckChapterExists(id);
        }
    }
}
