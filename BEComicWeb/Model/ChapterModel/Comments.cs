namespace BEComicWeb.Model.ChapterModel
{
    public class Comments
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public string ChapterId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
        public Comments()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
    }
}
