using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class Authors
    {
        [PersonalData]
        [Required]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Alias { get; set; }
        public string? National { get; set; }
        public int Follows { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }


        public Authors()
        {
            Id = Guid.NewGuid().ToString();
        }

       public Authors(string? id, string? name, string? alias, string? national, int follows, DateTime? created, DateTime? lastModified)
        {
            Id = id;
            Name = name;
            Alias = alias;
            National = national;
            Follows = follows;
            CreatedDate = created;
            LastModified = lastModified;
        }
        public Authors(Authors _author)
        {
            Id = _author.Id;
            Name = _author.Name;
            National = _author.National;
            Follows = _author.Follows;
            Alias = _author.Alias;
            CreatedDate = _author.CreatedDate;
            LastModified = _author.LastModified;
        }
    }
}
