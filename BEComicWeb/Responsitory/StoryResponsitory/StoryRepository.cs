using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Model.StoryModel;
using BEComicWeb.Responsitory.StoryResponsitory;
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
        public StoryData AddStory(BaseStoryData? storyData)
        {
            if (storyData == null || storyData.Name == null)
            {
                return null;
            }
            Stories story = new Stories()
            {
                Id = Guid.NewGuid().ToString(),
                Name = storyData.Name,
                Description = storyData.Description,
                Image = storyData.Image,
                Status = storyData.Status,
                Views = 0,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            };
            _dbContext.StoriesDb.Add(story);
            StoryCategories storyCategory = new StoryCategories()
            {
                StoryId = story.Id,
                CategoryId = storyData.CategoryId,
                Created = DateTime.Now
            };
            _dbContext.StoryCategoriesDb.Add(storyCategory);
            StoryAuthors storyAuthor = new StoryAuthors()
            {
                StoryId = story.Id,
                AuthorId = storyData.AuthorId,
                Created = DateTime.Now
            };
            _dbContext.StoryAuthorsDb.Add(storyAuthor);
            _dbContext.SaveChanges();
            var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", story.Id);
            Directory.CreateDirectory(folder_path);
            StoryData result = new StoryData()
            {
                Story = story,
                Author = _dbContext.AuthorsDb.FirstOrDefault(e => e.Id == storyData.AuthorId),
                Category = _dbContext.CategoriesDb.FirstOrDefault(e => e.Id == storyData.CategoryId),
                Likes = 0,
                Follows = 0
            };
            return result;
        }

        public bool CheckStoryExists(string? id)
        {
            return _dbContext.StoriesDb.FirstOrDefault(e => e.Id == id) != null;
        }

        public Stories? DeleteStory(string? storyId)
        {
            Stories? story = _dbContext.StoriesDb.FirstOrDefault(e => e.Id == storyId);
            if (story != null)
            {
                var category = _dbContext.StoryCategoriesDb.FirstOrDefault(e => e.StoryId == storyId);
                var author = _dbContext.StoryAuthorsDb.FirstOrDefault(e => e.StoryId != storyId);
                //_dbContext.ChaptersDb.RemoveRange(_dbContext.ChaptersDb.Where(e => e.StoryId == storyId).ToList());
                //_dbContext.StoryAuthorsDb.RemoveRange(_dbContext.StoryAuthorsDb.Where(e => e.StoryId == storyId).ToList());
                //_dbContext.StoryCategoriesDb.RemoveRange(_dbContext.StoryCategoriesDb.Where(e => e.StoryId == storyId).ToList());

                _dbContext.StoryCategoriesDb.Remove(category);
                _dbContext.StoryAuthorsDb.Remove(author);
                _dbContext.StoryFollowsDb.RemoveRange(_dbContext.StoryFollowsDb.Where(e => e.StoryId == storyId));
                IChapterRepository IChapter = new ChapterRepository(_environment);
                IChapter.DeleteChapterOfStory(storyId);
                var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", story.Id);
                Directory.Delete(folder_path, true);

                _dbContext.StoriesDb.Remove(story);
                _dbContext.SaveChanges();
                return story;
            }
            return null;
        }

        public StoryData? GetStory(string? id)
        {
            var story = _dbContext.StoriesDb.FirstOrDefault(e => e.Id == id);
            if (story == null) return null;
            story.Views++;

            StoryData? storyData = new StoryData()
            {
                Story = story,
                Author = _dbContext.AuthorsDb.FirstOrDefault(e => e.Id == _dbContext.StoryAuthorsDb.FirstOrDefault(e => e.StoryId == id).AuthorId),
                Category = _dbContext.CategoriesDb.FirstOrDefault(e => e.Id == _dbContext.StoryCategoriesDb.FirstOrDefault(e => e.StoryId == id).CategoryId),
                Likes = _dbContext.ChapterLikesDb.Where(
                                                    e => _dbContext.ChaptersDb.Where(f => f.StoryId == story.Id)
                                                                            .Select(f => f.Id)
                                                                            .Contains(e.ChapterId)
                                                ).Count(),
                Follows = _dbContext.StoryFollowsDb.Where(e => e.StoryId == story.Id).Count()
            };
            _dbContext.SaveChanges();
            return storyData;
        }

        public StoryData? GetStoryData(Stories? story)
        {
            StoryData? storyData = new StoryData()
            {
                Story = story,
                Author = _dbContext.AuthorsDb.FirstOrDefault(e => e.Id == _dbContext.StoryAuthorsDb.FirstOrDefault(e => e.StoryId == story.Id).AuthorId),
                Category = _dbContext.CategoriesDb.FirstOrDefault(e => e.Id == _dbContext.StoryCategoriesDb.FirstOrDefault(e => e.StoryId == story.Id).CategoryId),
                Likes = _dbContext.ChapterLikesDb.Where(
                                                    e => _dbContext.ChaptersDb.Where(f => f.StoryId == story.Id)
                                                                            .Select(f => f.Id)
                                                                            .Contains(e.ChapterId)
                                                ).Count(),
                Follows = _dbContext.StoryFollowsDb.Where(e => e.StoryId == story.Id).Count()
            };
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

        public StoryData UpdateStory(string id, BaseStoryData? storyData)
        {
            if (storyData == null || id != null)
            {
                return null;
            }
            var story = _dbContext.StoriesDb.FirstOrDefault(e => e.Id == id);
            story.LastModified = DateTime.Now;
            story.Status = storyData.Status;
            story.Name = storyData.Name;
            story.Description = storyData.Description;
            story.Image = storyData.Image;
            _dbContext.StoriesDb.Update(story);
            var author = _dbContext.StoryAuthorsDb.FirstOrDefault(e => e.StoryId == story.Id);
            StoryCategories storyCategory = new StoryCategories()
            {
                StoryId = story.Id,
                CategoryId = storyData.CategoryId,
                Created = DateTime.Now
            };
            _dbContext.StoryCategoriesDb.Update(storyCategory);
            StoryAuthors storyAuthor = new StoryAuthors()
            {
                StoryId = story.Id,
                AuthorId = storyData.AuthorId,
                Created = DateTime.Now
            };
            _dbContext.StoryAuthorsDb.Update(storyAuthor);
            _dbContext.SaveChanges();
            return GetStoryData(story);
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
        public List<StoryData> GetFollowStories(string userName, int page, int n_story)
        {
            var storiesIds = _dbContext.StoryFollowsDb.Where(e => e.UserName == userName)
                                                     .OrderByDescending(e => e.CreatedDate)
                                                     .Skip((page - 1) * n_story)
                                                     .Take(n_story)
                                                     .Select(e => e.StoryId);
            List<StoryData> res = new List<StoryData>();
            foreach (var storyId in storiesIds)
            {
                res.Add(GetStory(storyId));
            }
            return res;

        }
        public int GetFollowStoriesSize(string userName)
        {
            return _dbContext.StoryFollowsDb.Where(e => e.UserName == userName).Count();
        }
    }
}
