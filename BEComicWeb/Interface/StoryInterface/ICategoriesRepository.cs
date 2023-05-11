using BEComicWeb.Model.StoryModel;

namespace BEComicWeb.Interface.StoryInterface
{
    public interface ICategoriesRepository
    {
        public Categories? addNew(Categories? category);
        public Categories? deleteCategory(string? category_id);
        public List<Categories> getAll();
        public Categories getCategory(string category_id);
        public List<Stories>? getStoriesOfCategory(string? category_id, int page, int n_stories);
        public int getStoriesOfCategorySize(string? category_id);
        public List<Stories> searchStoriesByCategory(string? category_name);
        public Categories updateCategory(Categories category);
        public bool CheckCategoryExists(string? id);
    }
}
