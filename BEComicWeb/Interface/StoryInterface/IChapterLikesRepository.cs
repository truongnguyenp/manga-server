using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IChapterLikesRepository
    {
        public ChapterLikes Like(string chapterId, string userName);
        public ChapterLikes UnLike(string chapterId, string userName);
        public bool IsLiked(string chapterId, string userName);
    }
}
