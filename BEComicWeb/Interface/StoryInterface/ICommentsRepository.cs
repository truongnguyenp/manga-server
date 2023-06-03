using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface ICommentsRepository
    {
        public object GetCommentsOfChapter(string chapterId, int page, int n_Comments);
        public object GetCommentsSizeOfChapter(string chapterId);
        public object GetCommentsOfStory(string storyId, int page, int n_comments);
        public object GetCommentsSizeOfStory(string storyId);
        public object AddNewComment(string chapterId, string title, string userName);
        public object UpdateComment(string commentId, string newTitle, string userName);
        public object DeleteCommentByUser(string commentId, string userName);
        public object DeleteComment(string commentId);
    }
}
