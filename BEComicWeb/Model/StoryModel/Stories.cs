using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class Stories
    {
        [Key]
        [Required]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public string? Image { get; set; }
        public string? Keyword { get; set; }
        public int Follows { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

        public Stories()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Stories(string? id, string? name, string? description, string? alias, string? image, string? keyword, bool status, DateTime? created, DateTime? lastModified)
        {
            Id = id;
            Name = name;
            Description = description;
            Alias = alias;
            Image = image;
            Keyword = keyword;
            Status = status;
            CreatedDate = created;
            LastModified = lastModified;
        }

        public Stories(Stories story)
        {
            Id = story.Id;
            Name = story.Name;
            Description = story.Description;
            Alias = story.Alias;
            Image = story.Image;
            Keyword = story.Keyword;
            Status = story.Status;
            CreatedDate = story.CreatedDate;
            LastModified = story.LastModified;
        }
    }
}
