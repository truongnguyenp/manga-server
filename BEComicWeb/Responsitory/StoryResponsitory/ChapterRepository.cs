using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly AppDbContext _dbContext = new();
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
                    var image = _dbContext.ChapterImagesDb.Where(e => e.Order == chapterImage.Order).ToList();
                    if (image == null)
                    {
                        _dbContext.ChapterImagesDb.Add(chapterImage);
                    }
                    else
                    {
                        _dbContext.ChapterImagesDb.RemoveRange(image);
                        _dbContext.ChapterImagesDb.Add(chapterImage);
                    }
                }
                _dbContext.ChapterImagesDb.RemoveRange(_dbContext.ChapterImagesDb.Where(e => e.Order > chapterData.ChapterImagesList.Count));
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
                _dbContext.SaveChanges();
                return result;
            }
            return null;
        }
        public ChapterData GetChapter(string id)
        {
            ChapterData result = new();
            result.Chapter = _dbContext.ChaptersDb.FirstOrDefault(e => e.Id == id);
            if (result.Chapter != null)
            {
                result.ChapterImagesList = _dbContext.ChapterImagesDb.Where(e => e.ChapterId == id).ToList();
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
