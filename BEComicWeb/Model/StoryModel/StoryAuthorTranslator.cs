namespace BEComicWeb.Model.StoryModel
{
    public class StoryAuthorTranslator
    {
        public string? Id { get; set; }
        public string? AuthorId { get; set; }
        public string? StoryId { get; set;}
        public string? TranslatorId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set;}
    }
}
