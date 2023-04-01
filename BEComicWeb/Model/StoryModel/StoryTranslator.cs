namespace BEComicWeb.Model.StoryModel
{
    public class StoryTranslator
    {
        public string? Id { get; set; }
        public string? StoryId { get; set;}
        public string? TranslatorId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set;}

        public StoryTranslator()
        {
            Id = Guid.NewGuid().ToString();
        }
        public StoryTranslator(string? _StoryId, string? _TranslatorId, bool isCreated=false)
        {
            Id = Guid.NewGuid().ToString();
            StoryId = _StoryId;
            TranslatorId = _TranslatorId;
            if (!isCreated)
                Created = DateTime.Now;
            LastModified = DateTime.Now;
        }
    }
}
