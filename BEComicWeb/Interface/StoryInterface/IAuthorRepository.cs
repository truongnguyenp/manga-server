using BEComicWeb.Model.ResponseModel;
using BEComicWeb.Model.PersonModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IAuthorRepository
    {
        public List<Authors> GetAuthorDetails();
        public Authors GetAuthorDetail(string? id);
        public bool AddAuthor(Authors? author);
        public bool UpdateAuthor(Authors? author);
        public Authors DeleteAuthor(string? id);
        public bool CheckAuthorExists(string? id);
    }
}
