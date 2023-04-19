using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Controllers
{
    [Route("")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterRepository _IChapterRepository;

        public ChapterController(IChapterRepository IChapterRes)
        {
            _IChapterRepository = IChapterRes;
        }

        // Get List of Chapters.
        // Type: Search --> Return {n_Chapters} Chapters which their names have {categ} for page {page}.
        // Type: Category --> Return {n_Chapters} Chapters which their categories has {categ} for page {page}.
        // Type: Newest --> Return the top {n_Chapters} newest Chapters for page {page}. 
        // GET: list/
        [HttpGet("{type}/{categ}/{page}")]
        public async Task<ActionResult<IEnumerable<Chapters>>> Get(string categ, int page, int n_Chapters, string type)
        {
            return await Task.FromResult(_IChapterRepository.GetChaptersList(categ, page, n_Chapters, type));
        }

        // Get Chapter by Id
        // GET Chapter/{id}
        [HttpGet("Chapter/{Chapter_id}")]
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
        [HttpPost("new-Chapter")]
        public async Task<ActionResult<Chapters>> Post(Chapters Chapter, string story_id, int chapter_number)
        {
            _IChapterRepository.AddChapter(Chapter, story_id, chapter_number);
            return await Task.FromResult(Chapter);
        }

        // Update Chapter if this Chapter is existed.
        // PUT Chapter/update/{id}
        [HttpPut("update-Chapter/{id}")]
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
        // DELETE Chapter/delete/{id}
        [HttpDelete("delete-Chapter/{id}")]
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
