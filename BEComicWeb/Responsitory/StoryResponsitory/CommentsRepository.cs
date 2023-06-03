using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class CommentsRepository : ICommentsRepository
    {
        AppDbContext _dbContext = new();
        public List<Comments> GetCommentsOfChapter(string chapterId, int page, int n_comments)
        {
            List<Comments> CommentList = _dbContext.CommentsDb.Where(e => e.ChapterId == chapterId)
                                                               .OrderBy(e => e.CreatedDate)
                                                               .Skip((page - 1) * n_comments)
                                                               .Take(n_comments)
                                                               .ToList();
            return CommentList;
        }
        public int GetCommentsSizeOfChapter(string chapterId)
        {
            int CommentSize = _dbContext.CommentsDb.Where(e => e.ChapterId == chapterId).Count();
            return CommentSize;
        }
        public List<Comments> GetCommentsOfStory(string storyId, int page, int n_comments)
        {
            var chapterIds = _dbContext.ChaptersDb.Where(e => e.StoryId == storyId).Select(e => e.Id);
            var CommentList = _dbContext.CommentsDb.Where(e => chapterIds.Contains(e.ChapterId))
                                                .OrderBy(e => e.CreatedDate)
                                                .Skip((page - 1) * n_comments)
                                                .Take(n_comments)
                                                .ToList();
            return CommentList;
        }
        public int GetCommentsSizeOfStory(string storyId)
        {
            var chapterIds = _dbContext.ChaptersDb.Where(e => e.StoryId == storyId).Select(e => e.Id);
            int CommentSize = _dbContext.CommentsDb.Where(e => chapterIds.Contains(e.ChapterId)).Count();
            return CommentSize;
        }
        public Comments AddNewComment(string chapterId, string title, string userName)
        {
            Comments Comment;
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
            return Comment;

        }

        public Comments UpdateComment(string commentId, string newTitle, string userName)
        {
            var Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
            if (Comment.UserName != userName)
            {
                Comment = null;
                return Comment;
            }
            Comment.Title = newTitle;
            _dbContext.SaveChanges();
            return Comment;
        }
        public Comments DeleteCommentByUser(string commentId, string userName)
        {
            var Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
            if (Comment.UserName != userName)
            {
                return null;
            }
            return Comment;
        }
        public Comments DeleteComment(string commentId)
        {
            var Comment = _dbContext.CommentsDb.FirstOrDefault(e => e.Id == commentId);
            return Comment;
        }
    }
}
