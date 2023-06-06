using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly AppDbContext _dbContext = new();
        private readonly IHostingEnvironment _environment;
        public ChapterRepository(IHostingEnvironment env)
        {
            _environment = env;
        }
        public ChapterData CreateNewChapter(ChapterData? chapterData)
        {
            if (chapterData == null || chapterData.Chapter == null || chapterData.ChapterImagesList == null)
            {
                return null;
            }
            if (!IsChapterExists(chapterData.Chapter))
            {
                _dbContext.ChaptersDb.Add(chapterData.Chapter);
                _dbContext.ChapterImagesDb.AddRange(chapterData.ChapterImagesList);
                _dbContext.SaveChanges();
                return chapterData;
            }
            return null;
        }

        public ChapterData UpdateChapter(ChapterData chapterData)
        {
            if (chapterData == null || chapterData.Chapter == null || chapterData.ChapterImagesList == null)
            {
                return null;
            }
            var chapter = _dbContext.ChaptersDb.FirstOrDefault(e => e.StoryId == chapterData.Chapter.StoryId && e.ChapterNumber == chapterData.Chapter.ChapterNumber);
            if (chapter != null)
            {
                chapter = chapterData.Chapter;
                foreach (var chapterImage in chapterData.ChapterImagesList)
                {
                    var image = _dbContext.ChapterImagesDb.FirstOrDefault(e => e.Id == chapterImage.Id);
                    if (image == null)
                    {
                        _dbContext.ChapterImagesDb.Add(chapterImage);
                    }
                    else
                    {
                        image.Order = chapterImage.Order;
                    }
                }
                var outImage = _dbContext.ChapterImagesDb.Where(e => !chapterData.ChapterImagesList.Select(f => f.ImagePath).Contains(e.ImagePath));
                foreach (var image in outImage)
                {
                    var splitFilePath = image.ImagePath.Split('/');
                    string filePath = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", splitFilePath[splitFilePath.Length - 3], splitFilePath[splitFilePath.Length - 2], splitFilePath[splitFilePath.Length - 1]);
                    try
                    {
                        File.Delete(filePath);
                        Console.WriteLine("File deleted successfully.");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("An error occurred while deleting the file: " + e.Message);
                    }
                }
                _dbContext.ChapterImagesDb.RemoveRange(outImage);
                _dbContext.SaveChanges();
                return chapterData;
            }
            return null;
        }
        public ChapterData DeleteChapter(string id)
        {
            ChapterData result = new();
            result.Chapter = _dbContext.ChaptersDb.FirstOrDefault(e => e.Id == id);
            if (result.Chapter != null)
            {
                _dbContext.ChaptersDb.Remove(result.Chapter);
                result.ChapterImagesList = _dbContext.ChapterImagesDb.Where(e => e.ChapterId == id).ToList();
                _dbContext.ChapterImagesDb.RemoveRange(result.ChapterImagesList);
                _dbContext.ChapterLikesDb.RemoveRange(_dbContext.ChapterLikesDb.Where(e => e.ChapterId == id));
                _dbContext.SaveChanges();
                return result;
            }
            return null;
        }
        public void DeleteChapterOfStory(string storyId)
        {
            var chapters = _dbContext.ChaptersDb.Where(e => e.StoryId == storyId);
            var chapterIds = chapters.Select(f => f.Id);
            var images = _dbContext.ChapterImagesDb.Where(e => chapterIds.Contains(e.ChapterId));
            var likes = _dbContext.ChapterLikesDb.Where(e => chapterIds.Contains(e.ChapterId));
            _dbContext.ChaptersDb.RemoveRange(chapters);
            _dbContext.ChapterImagesDb.RemoveRange(images);
            _dbContext.ChapterLikesDb.RemoveRange(likes);
            _dbContext.SaveChanges();
        }
        public ChapterData GetChapter(string id)
        {
            ChapterData result = new();
            result.Chapter = _dbContext.ChaptersDb.FirstOrDefault(e => e.Id == id);
            if (result.Chapter != null)
            {
                result.Chapter.Views++;
                result.Likes = _dbContext.ChapterLikesDb.Where(e => e.ChapterId == id).Count();
                result.ChapterImagesList = _dbContext.ChapterImagesDb.Where(e => e.ChapterId == id).ToList();
                _dbContext.SaveChanges();
                return result;
            }
            return null;
        }
        public Chapters GetNewestChapterOfStory(string story_id)
        {
            if (story_id == null)
                return null;
            Chapters result = new();
            result = _dbContext.ChaptersDb.Where(e => e.StoryId == story_id).OrderByDescending(e => e.LastModified).FirstOrDefault();
            return result;
        }

        public List<Chapters> GetAllChaptersOfStory(string story_id)
        {
            if (story_id == null)
                return null;
            return _dbContext.ChaptersDb.Where(e => e.StoryId == story_id).OrderByDescending(e => e.LastModified).ToList();
        }

        public bool IsChapterExists(Chapters? chapter)
        {
            return _dbContext.ChaptersDb.FirstOrDefault(e => e.StoryId == chapter.StoryId && e.ChapterNumber == chapter.ChapterNumber) != null;
        }

        public bool IsChapterImageExists(ChapterImages? chapterImage)
        {
            return _dbContext.ChapterImagesDb.FirstOrDefault(e => e.ChapterId == chapterImage.ChapterId && e.ImagePath == chapterImage.ImagePath) != null;
        }
    }
}
