using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;


namespace BEComicWeb.Repository.StoryRepository
{
    public class StoryRepository : IStoryRepository
    {
        readonly AppDbContext? _dbContext = new();
        public Stories AddStory(Stories? story)
        {
            if (story == null)
            {
                return null;
            }
            story.CreatedDate = DateTime.Now;
            story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Add(story);
            _dbContext.SaveChanges();
            return story;
        }

        public bool CheckStoryExists(string? id)
        {
            Stories? story = _dbContext.StoriesDb.Find(id);
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
                var chapters = from chapter in _dbContext.ChaptersDb
                               where chapter.StoryId == id
                               select chapter;
                _dbContext.ChaptersDb.RemoveRange(chapters.ToList());
                _dbContext.StoriesDb.Remove(story);
                _dbContext.SaveChanges();
            }
            return story;
        }

        public Stories? GetStory(string? id)
        {
            Stories? story = _dbContext.StoriesDb.Find(id);
            return story;
        }

        public List<Stories> GetNewestStoryList(int page, int n_stories = 30)
        {
            List<Stories> res = _dbContext.StoriesDb.OrderByDescending(e => e.LastModified)
                                                    .Take(n_stories)
                                                    .Skip(n_stories * (page - 1))
                                                    .ToList();
            return res;
        }

        public List<Stories> SearchStory(string search_string, int page, int n_stories = 30)
        {
            var query = _dbContext.StoriesDb.Where(e => e.Name.ToLower().Contains(search_string.ToLower()))
                                            .Take(n_stories)
                                            .Skip(n_stories * (page - 1))
                                            .ToList();
            return query;
        }

        public Stories UpdateStory(Stories? story)
        {
            if (story == null)
            {
                return null;
            }
            story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Update(story);
            _dbContext.SaveChanges();
            return story;
        }
        public int GetSearchStoryListSize(string? search_string)
        {
            return _dbContext.StoriesDb.Where(e => e.Name.ToLower().Contains(search_string.ToLower())).Count();
        }

        public int? GetStorySize()
        {
            return _dbContext.StoriesDb.Count();
        }

        public List<Chapters> GetAllChaptersOfStory(string story_id)
        {
            var res = _dbContext.ChaptersDb.Where(e => e.StoryId == story_id).ToList();
            return res;
        }
    }
}
