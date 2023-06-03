using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class ChaptertLikesRepository : IChapterLikesRepository
    {
        AppDbContext _dbContext = new();
        public ChapterLikes Like(string chapterId, string userName)
        {
            var res = _dbContext.ChapterLikesDb.FirstOrDefault(e => (e.ChapterId == chapterId && e.UserName == userName));
            if (res ==  null)
            {
                ChapterLikes chapterLikes = new ChapterLikes()
                {
                    ChapterId = chapterId,
                    UserName = userName,
                    CreatedDate = DateTime.Now
                };
                _dbContext.ChapterLikesDb.Add(chapterLikes);
                _dbContext.SaveChanges();
                return chapterLikes;
            }
            return null;
        }
        public ChapterLikes UnLike(string chapterId, string userName)
        {
            var res = _dbContext.ChapterLikesDb.FirstOrDefault(e => (e.ChapterId == chapterId && e.UserName == userName));
            if (res != null)
            {
                _dbContext.ChapterLikesDb.Remove(res);
                _dbContext.SaveChanges();
                return res;
            }
            return null;
        }
        public bool IsLiked(string chapterId, string userName)
        {
            var res = _dbContext.ChapterLikesDb.FirstOrDefault(e => (e.ChapterId == chapterId && e.UserName == userName));
            if (res == null)
            {
                return false;
            }
            return true;
        }
    }
}
