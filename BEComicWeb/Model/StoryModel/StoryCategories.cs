namespace BEComicWeb.Model.StoryModel
{
    public class StoryCategories
    {
        public string? Id { get; set; }
        public string? StoryId { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public StoryCategories()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
