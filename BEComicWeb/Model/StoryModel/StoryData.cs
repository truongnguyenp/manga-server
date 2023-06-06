namespace BEComicWeb.Model.StoryModel
{
    public class BaseStoryData
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public string? AuthorId { get; set; }
        public string? CategoryId { get; set; }
    }

    public class StoryData
    {
        public Stories Story { get; set; }
        public Categories Category { get; set; }
        public Authors Author { get; set; }
        public int Likes { get; set; }
        public int Follows { get; set; }
    }
}
