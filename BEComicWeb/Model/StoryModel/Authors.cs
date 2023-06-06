using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.StoryModel
{
    public class Authors
    {
        [PersonalData]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? National { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public Authors()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
