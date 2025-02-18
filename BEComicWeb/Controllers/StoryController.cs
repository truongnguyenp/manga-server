﻿using BEComicWeb.Interface.StoryInterface;
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

        // Get List of newest stories.
        // GET: newest/{page}
        [HttpGet("newest/{page}/{n_stories}")]
        public async Task<ActionResult<IEnumerable<StoryData>>> GetNewestStoryList(int page, int n_stories)
        {
            return await Task.FromResult(_IStoryRepository.GetNewestStoryList(page, n_stories));
        }
        [HttpGet("newest/n-pages")]
        public async Task<ActionResult<int>> GetStorySize(int n_stories)
        {
            return await Task.FromResult((int) Math.Ceiling((double)_IStoryRepository.GetStorySize() / n_stories));
        }

        // Get List of newest stories.
        // GET: search/{page}
        [HttpGet("search/{search_string}/{page}/{n_stories}")]
        public async Task<ActionResult<IEnumerable<StoryData>>> SearchStory(string search_string, int page, int n_stories)
        {
            return await Task.FromResult(_IStoryRepository.SearchStory(search_string, page, n_stories));
        }

        // Get Story by Id
        // GET story/{id}
        [HttpGet("{story_id}")]
        public async Task<ActionResult<object>> Get(string story_id)
        {
            var story= await Task.FromResult(_IStoryRepository.GetStory(story_id));
            if (story == null)
            {
                return NotFound();
            }
            var chapters = _IStoryRepository.GetAllChaptersOfStory(story_id);
            return await Task.FromResult(new { story, chapters});
        }

        [HttpGet("n_pages")]
        public async Task<ActionResult<int>> GetSearchStoryListSize(string search_string, int n_stories)
        {
            var n_pages = await Task.FromResult(_IStoryRepository.GetSearchStoryListSize(search_string));
            return await Task.FromResult((int) Math.Ceiling((double)n_pages / n_stories));
        }

        // Create new Story
        // POST story
        [HttpPost("new")]
        public async Task<ActionResult<StoryData>> Post(BaseStoryData storyData)
        {
            return await Task.FromResult(_IStoryRepository.AddStory(storyData));
        }

        // Update Story if this story is existed.
        // PUT story/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<StoryData>> Put(string id, BaseStoryData storyData)
        {
            try
            {
                return await Task.FromResult(_IStoryRepository.UpdateStory(id, storyData));
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
        }

        // Delete Story
        // Note: We need warning user before delete
        // DELETE story/{id}
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
        [HttpGet("follow/{page}/{n_stories}")]
        public async Task<ActionResult<IEnumerable<StoryData>>> GetFolloiwStories(int page, int n_stories)
        {
            return await Task.FromResult(_IStoryRepository.GetFollowStories(User.Identity.Name, page, n_stories));
        }
        [HttpGet("follow/size")]
        public async Task<ActionResult<int>> GetFolloiwStoriesSize(int n_stories)
        {
            return await Task.FromResult((int) Math.Ceiling((double)_IStoryRepository.GetFollowStoriesSize(User.Identity.Name) / n_stories));
        }
    }
}
