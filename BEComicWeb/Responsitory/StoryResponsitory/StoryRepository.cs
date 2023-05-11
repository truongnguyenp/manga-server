using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml;
using Renci.SshNet;


namespace BEComicWeb.Repository.StoryRepository
{
    public class StoryRepository : IStoryRepository
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
            if (story != null) {
                var chapters = from chapter in _dbContext.ChaptersDb
                               where  chapter.Story.Id == id
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

        public List<Stories> GetNewestStoryList(int page, int n_stories=30)
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

        public bool UpdateStory(Stories? story)
        {
            if (story == null)
            {
                return false;
            }
            story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Update(story);
            _dbContext.SaveChanges();
            return true;
        }
        public int GetSearchStoryListSize(string? search_string)
        {
            return _dbContext.StoriesDb.Where(e => e.Name.ToLower().Contains(search_string.ToLower())).Count();
        }
    }
}
