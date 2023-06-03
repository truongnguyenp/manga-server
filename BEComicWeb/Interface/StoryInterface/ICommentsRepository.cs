using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface ICommentsRepository
    {
        public List<Comments> GetCommentsOfChapter(string chapterId, int page, int n_Comments);
        public int GetCommentsSizeOfChapter(string chapterId);
        public List<Comments> GetCommentsOfStory(string storyId, int page, int n_comments);
        public int GetCommentsSizeOfStory(string storyId);
        public Comments AddNewComment(string chapterId, string title, string userName);
        public Comments UpdateComment(string commentId, string newTitle, string userName);
        public Comments DeleteCommentByUser(string commentId, string userName);
        public Comments DeleteComment(string commentId);
    }
}
