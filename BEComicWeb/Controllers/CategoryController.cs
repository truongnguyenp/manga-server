using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;

namespace BEComicWeb.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoriesRepository _ICategoriesRepository;


        public CategoryController(ICategoriesRepository IStoryRes)
        {
            _ICategoriesRepository = IStoryRes;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Categories>>> Get()
        {
            return await Task.FromResult(_ICategoriesRepository.getAll());
        }

        // Get List of newest Categories.
        // GET: search/{page}
        [HttpGet("search/{search_string}")]
        public async Task<ActionResult<IEnumerable<Stories>>> searchStoriesByCategory(string search_string)
        {
            return await Task.FromResult(_ICategoriesRepository.searchStoriesByCategory(search_string));
        }

        // Get Story by Id
        // GET story/{id}
        [HttpGet("{category_id}")]
        public async Task<ActionResult<Categories>> Get(string category_id)
        {
            var category = await Task.FromResult(_ICategoriesRepository.getCategory(category_id));
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpGet("/{category_id}/stories")]
        public async Task<ActionResult<int>> getStoriesOfCategorySize(string category_id)
        {
            var n_pages = await Task.FromResult(_ICategoriesRepository.getStoriesOfCategorySize(category_id));
            return n_pages;
        }

        // Create new Story
        // POST story
        [HttpPost("new")]
        public async Task<ActionResult<Categories>> Post(Categories Story)
        {
            _ICategoriesRepository.addNew(Story);
            return await Task.FromResult(Story);
        }

        // Update Story if this story is existed.
        // PUT story/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Categories>> Put(Categories Category)
        {
            return await Task.FromResult(_ICategoriesRepository.updateCategory(Category));
        }

        // Delete Story
        // Note: We need warning user before delete
        // DELETE story/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Categories>> Delete(string? id)
        {
            return await Task.FromResult(_ICategoriesRepository.deleteCategory(id));
        }

        private bool CategoryExists(string id)
        {
            return _ICategoriesRepository.CheckCategoryExists(id);
        }
    }
}
