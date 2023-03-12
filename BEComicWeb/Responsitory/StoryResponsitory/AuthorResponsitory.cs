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
            try
            {
                if (author == null)
                {
                    return false;
                }
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        List<Authors> IAuthorResponse.GetAuthorDetails()
        {
            try
            {
                List<Authors> result = _dbContext.Authors.ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        Authors IAuthorResponse.GetAuthorDetail(string id)
        {
            try
            {
                Authors author = _dbContext.Authors.Find(id);
                if (author != null)
                {
                    return author;
                }
                return new();
            }
            catch
            {
                throw;
            }
        }

        bool IAuthorResponse.AddAuthor(Authors author)
        {
            try
            {
                if (author != null)
                {
                    _dbContext.Authors.Add(author);
                    _dbContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        bool IAuthorResponse.UpdateAuthor(Authors author)
        {
            try
            {
                if (author != null)
                {
                    author.LastModified = DateTime.Now;
                    _dbContext.Authors.Update(author);
                    _dbContext.SaveChanges();
                    return true;
                }
                
                return false;
            }
            catch
            {
                throw;
            }
        }

        Authors IAuthorResponse.DeleteAuthor(string id)
        {
            try
            {
                Authors? author = _dbContext.Authors.Find(id);
                if (author != null)
                {
                    _dbContext.Authors.Remove(author);
                    _dbContext.SaveChanges();
                    return author;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public bool CheckAuthorExists(string id)
        {
            return _dbContext.Authors.Find(id) != null;
        }
    }
}
