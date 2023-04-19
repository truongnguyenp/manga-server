using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.PersonModel
{
    public class Authors
    {
        [PersonalData]
        [Required]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Alias { get; set; }
        public string? National { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }


        public Authors()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            LastModified = DateTime.Now;
        }

       public Authors(string? id, string? name, string? alias, string? national, DateTime? created, DateTime? lastModified)
        {
            Id = id;
            Name = name;
            Alias = alias;
            National = national;
            CreatedDate = created;
            LastModified = lastModified;
        }
        public Authors(Authors _author, bool is_created=false)
        {
            if (is_created)
            {
                Id = Guid.NewGuid().ToString();
                CreatedDate = DateTime.Now;
                LastModified = DateTime.Now;
            }
            else
            {
                Id = _author.Id;
                CreatedDate = _author.CreatedDate;
                LastModified = _author.LastModified;
            }
            Name = _author.Name;
            National = _author.National;
            Alias = _author.Alias;
        }
    }
}
