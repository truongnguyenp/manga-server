using BEComicWeb.Data;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.PersonModel;

namespace BEComicWeb.Repository.StoryRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly AppDbContext _dbContext = new();
        public AuthorRepository(AppDbContext dbContext)
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

        public List<Authors> GetAuthorDetails()
        {
            var result = _dbContext.AuthorsDb.ToList();
            return result;
        }

        public Authors GetAuthorDetail(string? id)
        {
            Authors? author = _dbContext.AuthorsDb.Find(id);
            if (author != null)
            {
                return author;
            }
            return new();
        }

        public bool UpdateAuthor(Authors? author)
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

        public Authors DeleteAuthor(string? id)
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

        public bool CheckAuthorExists(string? id)
        {
            return _dbContext.AuthorsDb.Find(id) != null;
        }
    }
}
