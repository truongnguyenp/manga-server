using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Repository.StoryRepository
{
    public class ChapterRepository : IChapterRepository
    {
        readonly AppDbContext _dbContext = new();

        public Chapters AddChapter(Chapters chapter)
        {
            if (chapter != null && chapter.StoryId != null)
            {
                var story = _dbContext.StoriesDb.Find(chapter.StoryId);
                if (story == null)
                {
                    return null;
                }
                story.LastModified = DateTime.Now;
                _dbContext.ChaptersDb.Add(chapter);
                _dbContext.SaveChanges();
                return chapter;
            }
            return null;
        }

        public bool CheckChapterExists(string id)
        {
            Chapters chapter = _dbContext.ChaptersDb.Find(id);
            return chapter != null;
        }

        public Chapters? DeleteChapter(string? id)
        {
            Chapters? chapter = _dbContext.ChaptersDb?.Find(id);
            if (chapter != null)
            {
                _dbContext.ChaptersDb?.Remove(chapter);
                _dbContext.SaveChanges();
            }
            return chapter;
        }

        public Chapters? GetChapter(string? chapter_id)
        {
            if (chapter_id == null)
            {
                return null;
            }
            var res = _dbContext.ChaptersDb?.Find(chapter_id);
            return res;
        }
        public Chapters? GetNewestChapterOfStory(string story_id)
        {
            var res = _dbContext.ChaptersDb.Where(e => e.StoryId == story_id)
                                           .OrderByDescending(e => e.LastModified)
                                           .First();
            return res;
        }
        public Chapters? UpdateChapter(Chapters chapter)
        {
            if (chapter != null)
            {
                var old = _dbContext.ChaptersDb.FirstOrDefault(e => e.Id == chapter.Id);
                if (old != null)
                {
                    _dbContext.Entry(old).State = EntityState.Detached;
                    _dbContext.ChaptersDb.Update(chapter);
                    _dbContext.SaveChanges();
                    return chapter;
                }
            }
            return null;
        }
    }
}
