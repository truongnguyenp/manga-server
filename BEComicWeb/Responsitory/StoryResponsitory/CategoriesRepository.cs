using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _dbContext = new();
        public Categories? addNew(Categories? category)
        {
            if (category != null)
            {
                _dbContext.CategoriesDb.Add(category);
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

        public List<StoryData>? getStoriesOfCategory(string? category_id, int page, int n_stories)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            if (category != null)
            {
                var storyIdList = _dbContext.StoryCategoriesDb.Where(e => e.CategoryId == category_id).Select(e=> e.StoryId).ToList();
                List<StoryData> res = new List<StoryData>();
                List<Stories> storyList = _dbContext.StoriesDb.Where(e => storyIdList.Contains(e.Id))
                                                              .OrderByDescending(e => e.LastModified)
                                                              .Skip((page - 1) * n_stories)
                                                              .Take(n_stories)
                                                              .ToList();
                                                        
                foreach (var story in storyList)
                {
                    StoryData? storyData = new StoryData()
                    {
                        Story = story
                    };
                    foreach (var storyCate in _dbContext.StoryCategoriesDb.Where(e => e.StoryId == story.Id))
                    {
                        storyData.StoryCategoryList.Add(_dbContext.CategoriesDb.FirstOrDefault(e => e.Id == storyCate.CategoryId));
                    }
                    foreach (var storyAuthor in _dbContext.StoryAuthorsDb.Where(e => e.StoryId == story.Id))
                    {
                        storyData.StoryAuthorList.Add(_dbContext.AuthorsDb.FirstOrDefault(e => e.Id == storyAuthor.AuthorId));
                    }
                    res.Add(storyData);
                }
                return res;
            }
            return null;
        }
        public int getStoriesOfCategorySize(string? category_id)
        {
            Categories? category = _dbContext.CategoriesDb.Find(category_id);
            if (category != null)
            {
                var storyIdList = _dbContext.StoryCategoriesDb.Where(e => e.CategoryId == category_id).Select(e => e.StoryId).ToList();
                List<Stories> storyList = _dbContext.StoriesDb.Where(e => storyIdList.Contains(e.Id)).ToList();
                return storyList.Count();
            }
            return 0;
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
