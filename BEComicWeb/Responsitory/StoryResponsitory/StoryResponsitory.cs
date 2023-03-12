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
            try
            {
                if (story == null)
                {
                    return false;
                }
                _dbContext.Stories.Add(story);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool CheckStoryExists(string? id)
        {
            try
            {
                Stories? story =  _dbContext.Stories.Find(id);
                if (story != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public Stories? DeleteStory(string? id)
        {
            try
            {
                Stories? story = _dbContext.Stories.Find(id);
                if (story != null)
                {
                    _dbContext.Stories.Remove(story);
                }
                return story;
            }
            catch
            {
                throw;
            }
        }

        public Stories? GetStoryDetail(string? id)
        {
            try
            {
                Stories? story = _dbContext.Stories.Find(id);
                return story;
            }
            catch
            {
                throw;
            }
        }

        public List<Stories> GetStoryDetails()
        {
            List<Stories> stories = _dbContext.Stories.Where<Stories>(e => e.Status == true)
                                          .OrderByDescending(s => s.LastModified)
                                          .Take(20)
                                          .ToList();
            return stories;
        }

        public bool UpdateStory(Stories? story)
        {
            try
            {
                if (story == null)
                {
                    return false;
                }
                story.LastModified = DateTime.Now;
                _dbContext.Stories.Update(story);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
