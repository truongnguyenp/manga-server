using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BEComicWeb.Controllers
{
    [Route("story-categories")]
    [ApiController]
    public class StoryCategoriesController : Controller
    {
        public IStoryCategoriesRepository _IStoryCategoriesRepository;
        public StoryCategoriesController(IStoryCategoriesRepository _IStoryCategoriesRepos)
        {
            _IStoryCategoriesRepository = _IStoryCategoriesRepos;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<StoryCategories>>> Get(Stories? story)
        {
            return await Task.FromResult(_IStoryCategoriesRepository.getStoryCategories(story));
        }
        [HttpPost("add")]
        public async Task<ActionResult<StoryCategories>> Post(StoryCategories? story_cate)
        {
            return await Task.FromResult(_IStoryCategoriesRepository.addStoryCategory(story_cate));
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<StoryCategories>> Delete(StoryCategories? story_cate)
        {
            return await Task.FromResult(_IStoryCategoriesRepository.deleteStoryCategory(story_cate));
        }
    }
}
