using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml;
using Renci.SshNet;


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
            if (story != null) {
                var chapters = from chapter in _dbContext.ChaptersDb
                               where  chapter.StoryId == id
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

        public List<Stories> GetStoryList(string? categ, int page, int n_stories=30, string type="category")
        {
            List<Stories> res;
            if (type.ToLower() == "newest")
            {
                res = _dbContext.StoriesDb.OrderByDescending(e => e.LastModified)
                                                                   .Take(n_stories)
                                                                   .Skip(n_stories * (page - 1))
                                                                   .ToList();
            }
            else if (type.ToLower() == "category")
            {
                var category_id = from category in _dbContext.CategoriesDb
                                  where category.Name.ToLower() == categ.ToLower()
                                  select category.Id;
                var chapter_query = from story_category in _dbContext.StoryCategoriesDb
                                 join chapter in _dbContext.ChaptersDb on story_category.StoryId equals chapter.StoryId
                                 select chapter;
                var newest_chapter_query = chapter_query.OrderByDescending(e => e.LastModified)
                                                        .Take(n_stories)
                                                        .GroupBy(e => e.StoryId)
                                                        .Skip(n_stories * (page - 1));
                var story_query = from chapter in newest_chapter_query
                                  join story in _dbContext.StoriesDb on chapter.Key equals story.Id
                                  select story;

                res = story_query.ToList();
            }
            else if (type.ToLower() == "search")
            {
                var story_query = from story in _dbContext.StoriesDb
                                  join chapter in _dbContext.ChaptersDb on story.Id equals chapter.StoryId
                                  where story.Name.ToLower() == categ.ToLower()
                                  orderby chapter.LastModified ascending
                                  select story;
                res = story_query.OrderByDescending(e => e.LastModified)
                                 .Take(n_stories)
                                 .Skip(n_stories * (page - 1))
                                 .ToList();
            }
            else
            {
                res = new List<Stories>();
            }
            return res;
        }

        public bool UpdateStory(Stories? story)
        {
            if (story == null)
            {
                return false;
            }
            _dbContext.StoriesDb.Update(story);
            story.LastModified = DateTime.Now;
            _dbContext.SaveChanges();
            return true;
        }
        public int GetStoryListSize(string? categ, string? type)
        {
            if (type.ToLower() == "category")
            {
                var query = from category in _dbContext.CategoriesDb
                            join story_categ in _dbContext.StoryCategoriesDb on category.Id equals story_categ.CategoryId
                            select story_categ.StoryId;
                return query.Count();
            }
            else if (type.ToLower() == "search")
            {
                var query = _dbContext.StoriesDb.Where(e => e.Name.ToLower().Contains(categ.ToLower()));
                return query.Count();
            }
            else if (type.ToLower() == "newest")
            {
                return _dbContext.StoriesDb.Count();
            }
            return 0;
        }
    }
}
