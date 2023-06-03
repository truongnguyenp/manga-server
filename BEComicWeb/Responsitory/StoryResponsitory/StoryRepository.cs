using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Model.StoryModel;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BEComicWeb.Repository.StoryRepository
{
    public class StoryRepository : IStoryRepository
    {
        readonly AppDbContext? _dbContext = new();
        private readonly IHostingEnvironment _environment;
        public StoryRepository(IHostingEnvironment env)
        {
            _environment = env;
        }
        public StoryData AddStory(StoryData? storyData)
        {
            if (storyData == null || storyData.Story == null)
            {
                return null;
            }
            storyData.Story.CreatedDate = DateTime.Now;
            storyData.Story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Add(storyData.Story);
            foreach (var cate in storyData.StoryCategoryList)
            {
                StoryCategories storyCategories = new StoryCategories()
                {
                    StoryId = storyData.Story.Id,
                    CategoryId = cate.Id
                };
                _dbContext.StoryCategoriesDb.Add(storyCategories);
            }
            foreach (var author in storyData.StoryAuthorList)
            {
                StoryAuthors storyCategories = new StoryAuthors()
                {
                    StoryId = storyData.Story.Id,
                    AuthorId = author.Id
                };
                _dbContext.StoryAuthorsDb.Add(storyCategories);
            }
            _dbContext.SaveChanges();
            var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", storyData.Story.Id);
            Directory.CreateDirectory(folder_path);
            return storyData;
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

        public Stories? DeleteStory(string? storyId)
        {
            Stories? story = _dbContext.StoriesDb.Find(storyId);
            if (story != null)
            {
                _dbContext.ChaptersDb.RemoveRange(_dbContext.ChaptersDb.Where(e => e.StoryId == storyId).ToList());
                _dbContext.StoryAuthorsDb.RemoveRange(_dbContext.StoryAuthorsDb.Where(e => e.StoryId == storyId).ToList());
                _dbContext.StoryCategoriesDb.RemoveRange(_dbContext.StoryCategoriesDb.Where(e => e.StoryId == storyId).ToList());
                _dbContext.StoriesDb.Remove(story);
                var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", story.Id);
                Directory.Delete(folder_path, true);
                _dbContext.SaveChanges();
                return story;
            }
            return null;
        }

        public StoryData? GetStory(string? id)
        {
            var story = _dbContext.StoriesDb.FirstOrDefault(e => e.Id == id);
            StoryData? storyData = new StoryData()
            {
                Story = story,
                StoryAuthorList = new List<Authors>(),
                StoryCategoryList = new List<Categories>(),
                Likes = _dbContext.ChapterLikesDb.Where(
                                                    e => _dbContext.ChaptersDb.Where(f => f.StoryId == story.Id)
                                                                            .Select(f => f.Id)
                                                                            .Contains(e.ChapterId)
                                                ).Count(),
                Follows = _dbContext.StoryFollowsDb.Where(e => e.StoryId == story.Id).Count()
            };
            foreach (var storyCate in _dbContext.StoryCategoriesDb.Where(e => e.StoryId == id))
            {
                storyData.StoryCategoryList.Add(_dbContext.CategoriesDb.FirstOrDefault(e => e.Id == storyCate.CategoryId));
            }
            foreach (var storyAuthor in _dbContext.StoryAuthorsDb.Where(e => e.StoryId == id))
            {
                storyData.StoryAuthorList.Add(_dbContext.AuthorsDb.FirstOrDefault(e => e.Id == storyAuthor.AuthorId));
            }
            return storyData;
        }

        public StoryData? GetStoryData(Stories? story)
        {
            StoryData? storyData = new StoryData()
            {
                Story = story,
                StoryAuthorList = new List<Authors>(),
                StoryCategoryList = new List<Categories>(),
                Likes = _dbContext.ChapterLikesDb.Where(
                                                    e => _dbContext.ChaptersDb.Where(f => f.StoryId == story.Id)
                                                                            .Select(f => f.Id)
                                                                            .Contains(e.ChapterId)
                                                ).Count(),
                Follows = _dbContext.StoryFollowsDb.Where(e => e.StoryId == story.Id).Count()
            };
            foreach (var storyCate in _dbContext.StoryCategoriesDb.Where(e => e.StoryId == story.Id))
            {
                var category = _dbContext.CategoriesDb.FirstOrDefault(e => e.Id == storyCate.CategoryId);
                if (category != null)
                {
                    storyData.StoryCategoryList.Add(category);
                }
            }
            foreach (var storyAuthor in _dbContext.StoryAuthorsDb.Where(e => e.StoryId == story.Id))
            {
                var author = _dbContext.AuthorsDb.FirstOrDefault(e => e.Id == storyAuthor.AuthorId);
                if (author != null)
                {
                    storyData.StoryAuthorList.Add(author);
                }
            }
            return storyData;
        }

        public List<StoryData> GetNewestStoryList(int page, int n_stories = 30)
        {
            List<StoryData> res = new List<StoryData>();
            List<Stories> storyList = _dbContext.StoriesDb.OrderByDescending(e => e.LastModified)
                                                    .Take(n_stories)
                                                    .Skip(n_stories * (page - 1))
                                                    .ToList();
            foreach (var story in storyList)
            {
                res.Add(GetStoryData(story));
            }
            return res;
        }

        public List<StoryData> SearchStory(string search_string, int page, int n_stories = 30)
        {
            var storyList = _dbContext.StoriesDb.Where(e => e.Name.ToLower().Contains(search_string.ToLower()))
                                            .Take(n_stories)
                                            .Skip(n_stories * (page - 1))
                                            .ToList();
            List<StoryData> res = new List<StoryData>();
            foreach (var story in storyList)
            {
                res.Add(GetStoryData(story));
            }
            return res;
        }

        public StoryData UpdateStory(StoryData? storyData)
        {
            if (storyData == null || storyData.Story == null)
            {
                return null;
            }
            storyData.Story.LastModified = DateTime.Now;
            _dbContext.StoriesDb.Update(storyData.Story);

            _dbContext.SaveChanges();
            return storyData;
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
