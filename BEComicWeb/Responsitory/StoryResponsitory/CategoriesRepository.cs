using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _dbContext = new();
        public Categories? addNew(Categories? category)
        {
            if (category != null)
            {
                _dbContext.Add(category);
                _dbContext.SaveChanges();
            }
            return category;
        }

        public Categories? deleteCategory(string? category_id)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            if (category != null)
            {
                _dbContext.CategoriesDb.Remove(category);
                _dbContext.SaveChanges();
            }
            return category;
        }

        public List<Categories> getAll()
        {
            var res = _dbContext.CategoriesDb.ToList();
            return res;
        }

        public Categories getCategory(string category_id)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            return category;
        }

        public List<Stories>? getStoriesOfCategory(string? category_id, int page, int n_stories)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            if (category != null)
            {
                var stories = from story in _dbContext.StoriesDb
                              join story_cate in _dbContext.StoryCategoriesDb on story.Id equals story_cate.Story.Id
                              where story_cate.Category.Id == category.Id
                              select story;
                return stories.Skip(n_stories*(page - 1)).Take(n_stories).ToList();
            }
            return null;
        }
        public int getStoriesOfCategorySize(string? category_id)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            if (category != null)
            {
                var stories = from story in _dbContext.StoriesDb
                              join story_cate in _dbContext.StoryCategoriesDb on story.Id equals story_cate.Story.Id
                              where story_cate.Category.Id == category.Id
                              select story;
                return stories.Count();
            }
            return 0;
        }

        public List<Stories>? searchStoriesByCategory(string? category_name)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_name);
            if (category != null)
            {
                var stories = from story in _dbContext.StoriesDb
                              join story_cate in _dbContext.StoryCategoriesDb on story.Id equals story_cate.Story.Id
                              where story_cate.Category.Name.Contains(category.Name)
                              select story;
                return stories.ToList();
            }
            return null;
        }

        public Categories updateCategory(Categories category)
        {
            if (category == null)
            {
                return category;
            }
            _dbContext.CategoriesDb.Update(category);
            _dbContext.SaveChanges();
            return category;
        }

        public bool CheckCategoryExists(string? id)
        {
            Categories? cate = _dbContext.CategoriesDb.Find(id);
            if (cate != null)
            {
                return true;
            }
            return false;
        }
    }
}
