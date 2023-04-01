namespace BEComicWeb.Model.StoryModel
{
    public class StoryChapters
    {
        public string? Id { get; set; }
        public int? Number { get; set; }
        public string? ChapterId { get; set; }
        public string? StoryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }

        public StoryChapters()
        {
            Id = Guid.NewGuid().ToString();
        }
        public StoryChapters(string? _ChapterId, string? _StoryId, int? _Number=null, bool isCreated = false)
        {
            Id = Guid.NewGuid().ToString();
            ChapterId = _ChapterId;
            StoryId = _StoryId;
            Number = _Number;
            if (!isCreated)
                Created = DateTime.Now;
            LastModified = DateTime.Now;
        }
    }
}
