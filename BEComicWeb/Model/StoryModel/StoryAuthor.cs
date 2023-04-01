namespace BEComicWeb.Model.StoryModel
{
    public class StoryAuthor
    {
        public string? Id { get; set; }
        public string? AuthorId { get; set; }
        public string? StoryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public StoryAuthor()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    
}
