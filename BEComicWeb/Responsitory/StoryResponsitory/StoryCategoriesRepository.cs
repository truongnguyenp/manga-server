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
            if (story_cate.Story == null || story_cate.Category == null)
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
        public List<StoryCategories>? getStoryCategories(Stories? story)
        {
            if (story == null)
            {
                return null;
            }
            var story_categories = from story_cate in _dbContext.StoryCategoriesDb
                                   where story_cate.Story.Id == story.Id
                                   select story_cate;
            List<StoryCategories>? result = story_categories.ToList();
            return result;
        }
    }
}
