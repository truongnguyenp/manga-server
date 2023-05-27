using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class StoryCategoriesRepository : IStoryCategoriesRepository
    {
        AppDbContext _dbContext = new();
        public StoryCategories? addStoryCategory(StoryCategories? story_cate)
        {
            if (story_cate.StoryId == null || story_cate.CategoryId == null)
            {
                return null;
            }
            _dbContext.StoryCategoriesDb.Add(story_cate);
            _dbContext.SaveChanges();
            return story_cate;
        }
        public StoryCategories? deleteStoryCategory(StoryCategories story_cate)
        {
            if (story_cate == null)
                return null;
            _dbContext.StoryCategoriesDb.Remove(story_cate);
            _dbContext.SaveChanges();
            return story_cate;
        }
    }
}
