using BEComicWeb.Model.StoryModel;
using BEComicWeb.Model.ResponseModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface IAuthorResponse
    {
        public List<Authors> GetAuthorDetails();
        public Authors GetAuthorDetail(string? id);
        public bool AddAuthor(Authors? author);
        public bool UpdateAuthor(Authors? author);
        Authors DeleteAuthor(string? id);
        public bool CheckAuthorExists(string? id);
    }
}
