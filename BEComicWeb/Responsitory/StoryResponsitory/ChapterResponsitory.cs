using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Migrations;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
	public class ChapterResponsitory : IChapterResponse
	{
		readonly AppDbContext _dbContext = new();

        public bool AddChapter(Chapters chapter, string story_id, int chapter_number)
        {
            if (chapter != null && story_id != null)
            {
                var story = _dbContext.StoriesDb.Find(story_id);
                if (story == null)
                {
                    return false;
                }
                _dbContext.ChaptersDb.Add(chapter);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckChapterExists(string id)
        {
            Chapters chapter = _dbContext.ChaptersDb.Find(id);
            return chapter != null;
        }

        public Chapters DeleteChapter(string id)
        {
            Chapters chapter = _dbContext.ChaptersDb.Find(id);
            if (chapter != null)
            {
                _dbContext.ChaptersDb.Remove(chapter);
                _dbContext.SaveChanges();    
            }
            return chapter;
        }

        public List<Chapters> GetAllChaptersOfStory(string story_id)
        {
            throw new NotImplementedException();
        }

        public Chapters GetChapter(string chapter_id)
        {
            throw new NotImplementedException();
        }

        public List<Chapters> GetChaptersList(string? categ, int page, int n_chapters, string type)
        {
            List<Chapters> res;
            if (type.ToLower() == "newest")
            {
                res = _dbContext.ChaptersDb.OrderByDescending(e => e.Created)
                                           .Take(n_chapters)
                                           .Skip(n_chapters * (page - 1))
                                           .ToList();
            }
            else if (type.ToLower() == "category")
            {
                var category_id = from category in _dbContext.CategoriesDb
                                  where category.Name.ToLower() == categ.ToLower()
                                  select category.Id;
                var storyid_list = from story_category in _dbContext.StoryCategoriesDb
                                 join story in _dbContext.StoriesDb on story_category.StoryId equals story.Id
                                 select story.Id;
                var chapter_list = from chapter in _dbContext.ChaptersDb
                                   join story_id in storyid_list on chapter.StoryId equals story_id
                                   select chapter;

                res = chapter_list.OrderByDescending(e => e.Created)
                                  .Take(n_chapters)
                                  .Skip(n_chapters * (page - 1))
                                  .ToList();
            }
            else if (type.ToLower() == "search")
            {
                var chapter_query = from story in _dbContext.StoriesDb
                                  join chapter in _dbContext.ChaptersDb on story.Id equals chapter.StoryId
                                  where story.Name.ToLower() == categ.ToLower()
                                  orderby chapter.LastModified ascending
                                  select chapter;
                res = chapter_query.OrderByDescending(e => e.Created)
                                   .Take(n_chapters)
                                   .Skip(n_chapters * (page - 1))
                                   .ToList();
            }
            else
            {
                res = new List<Chapters>();
            }
            return res;
        }

        public bool UpdateChapter(Chapters chapter)
        {
            if (chapter == null)
            {
                return false;
            }
            _dbContext.ChaptersDb.Update(chapter);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
