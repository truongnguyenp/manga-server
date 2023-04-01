using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class StoryResponsitory : IStoryResponse
    {
        readonly AppDbContext? _dbContext = new();
        public bool AddStory(Stories? story)
        {
            if (story == null)
            {
                return false;
            }
            _dbContext.StoriesDb.Add(story);
            return true;
        }

        public bool CheckStoryExists(string? id)
        {
            Stories? story =  _dbContext.StoriesDb.Find(id);
            if (story != null)
            {
                return true;
            }
            return false;
        }

        public Stories? DeleteStory(string? id)
        {
            Stories? story = _dbContext.StoriesDb.Find(id);
            if (story != null)
            {
                _dbContext.StoriesDb.Remove(story);
            }
            return story;
        }

        public Stories? GetStoryDetail(string? id)
        {
            Stories? story = _dbContext.StoriesDb.Find(id);
            return story;
        }

        public List<Stories> GetStoryDetails()
        {
            List<Stories> stories = _dbContext.StoriesDb.Where<Stories>(e => e.Status == true)
                                          .OrderByDescending(s => s.LastModified)
                                          .Take(20)
                                          .ToList();
            return stories;
        }

        public bool UpdateStory(Stories? story)
        {
            if (story == null)
            {
                return false;
            }
            story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Update(story);
            return true;
        }
    }
}
