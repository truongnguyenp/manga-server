using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Responsitory.StoryResponsitory
{
    public class AuthorResponsitory : IAuthorResponse
    {
        readonly AppDbContext _dbContext = new();
        public AuthorResponsitory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddAuthor(Authors? author)
        {

            if (author == null)
            {
                return false;
            }
            _dbContext.AuthorsDb.Add(author);
            _dbContext.SaveChanges();
            return true;
        }

        List<Authors> IAuthorResponse.GetAuthorDetails()
        {
            List<Authors> result = _dbContext.AuthorsDb.ToList();
            return result;
        }

        Authors IAuthorResponse.GetAuthorDetail(string id)
        {
            Authors author = _dbContext.AuthorsDb.Find(id);
            if (author != null)
            {
                return author;
            }
            return new();
        }

        bool IAuthorResponse.AddAuthor(Authors author)
        {
            if (author != null)
            {
                _dbContext.AuthorsDb.Add(author);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        bool IAuthorResponse.UpdateAuthor(Authors author)
        {
            if (author != null)
            {
                author.LastModified = DateTime.Now;
                _dbContext.AuthorsDb.Update(author);
                _dbContext.SaveChanges();
                return true;
            }
                
            return false;
        }

        Authors IAuthorResponse.DeleteAuthor(string id)
        {
            Authors? author = _dbContext.AuthorsDb.Find(id);
            if (author != null)
            {
                _dbContext.AuthorsDb.Remove(author);
                _dbContext.SaveChanges();
                return author;
            }
            return null;
        }

        public bool CheckAuthorExists(string id)
        {
            return _dbContext.AuthorsDb.Find(id) != null;
        }
    }
}
