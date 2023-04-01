using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
	public class ChapterResponsitory : IChapterResponse
	{
		readonly AppDbContext _dbContext = new();

        public bool AddChapter(Chapters chapter)
        {
            if (chapter != null)
            {
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
            throw new NotImplementedException();
        }

        public bool DeleteChapter(string id)
        {
            throw new NotImplementedException();
        }

        public List<Chapters> GetAllChaptersOfStory(string story_id)
        {
            throw new NotImplementedException();
        }

        public Chapters GetChapter(string chapter_id)
        {
            throw new NotImplementedException();
        }

        public List<Chapters> GetNewChapters()
        {
            throw new NotImplementedException();
        }

        public bool UpdateChapter(Chapters chapter)
        {
            throw new NotImplementedException();
        }
    }
}
