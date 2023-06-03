using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class CommentsRepository : ICommentsRepository
    {
        AppDbContext _dbContext = new();
        public object GetCommentsOfChapter(string chapterId, int page, int n_comments)
        {
            string Message;
            List<Comments> CommentList = new List<Comments>();
            try
            {
                CommentList = _dbContext.CommentsDb.Where(e => e.ChapterId == chapterId)
                                 .Skip((page - 1) * n_comments)
                                 .Take(n_comments)
                                 .ToList();
                Message = "Success";
                return new { Message, CommentList };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                CommentList = null;
                return new { Message, CommentList };
            }
        }  
        public object GetCommentsSizeOfChapter(string chapterId)
        {
            string Message;
            int CommentSize;
            try
            {
                CommentSize = _dbContext.CommentsDb.Where(e => e.ChapterId == chapterId).Count();
                Message = "Success";
                return new { Message, CommentSize };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                CommentSize = 0;
                return new { Message, CommentSize };
            }
        }
        public object GetCommentsOfStory(string storyId, int page, int n_comments)
        {
            string Message;
            List<Comments> CommentList = new List<Comments>();
            try
            {
                var chapterIds = _dbContext.ChaptersDb.Where(e => e.StoryId == storyId).Select(e => e.Id);
                CommentList = _dbContext.CommentsDb.Where(e => chapterIds.Contains(e.ChapterId))
                                 .Skip((page - 1) * n_comments)
                                 .Take(n_comments)
                                 .ToList();
                Message = "Success";
                return new { Message, CommentList };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                CommentList = null;
                return new { Message, CommentList };
            }
        }
        public object GetCommentsSizeOfStory(string storyId)
        {
            string Message;
            int CommentSize;
            try
            {
                var chapterIds = _dbContext.ChaptersDb.Where(e => e.StoryId == storyId).Select(e => e.Id);
                CommentSize = _dbContext.CommentsDb.Where(e => chapterIds.Contains(e.ChapterId)).Count();
                Message = "Success";
                return new { Message, CommentSize };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                CommentSize = 0;
                return new { Message, CommentSize };
            }
        }
        public object AddNewComment(string chapterId, string title, string userName)
        {
            Comments Comment;
            string Message;
            try
            {
                Comment = new Comments()
                {
                    Id = Guid.NewGuid().ToString(),
                    ChapterId = chapterId,
                    Title = title,
                    UserName = userName,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };
                _dbContext.CommentsDb.Add(Comment);
                _dbContext.SaveChanges();
                Message = "Success";
                return new { Message, Comment };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Comment = null;
                return new { Message, Comment };
            }
        }

        public object UpdateComment(string commentId, string newTitle, string userName)
        {
            string Message;
            Comments Comment;
            try
            {
                Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
                if (Comment.UserName != userName)
                {
                    Message = "You cannot update Comments that you are not its own.";
                    Comment = null;
                    return new { Message, Comment };
                }
                Comment.Title = newTitle;
                _dbContext.SaveChanges();
                Message = "Success";
                return new { Message, Comment };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Comment = null;
                return new { Message, Comment };
            }
        }
        public object DeleteCommentByUser(string commentId, string userName)
        {
            Comments Comment;
            string Message;
            try
            {
                Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
                if (Comment.UserName != userName)
                {
                    Message = "You cannot delete Comments that you are not its own.";
                }
                else
                {
                    Message = "Success";
                }
                return new { Message, Comment };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Comment = null;
                return new { Message, Comment };
            }
        }
        public object DeleteComment(string commentId)
        {
            Comments Comment;
            string Message;
            try
            {
                Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
                Message = "Success";
                return new { Message, Comment };
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Comment = null;
                return new { Message, Comment };
            }
        }
    }
}
