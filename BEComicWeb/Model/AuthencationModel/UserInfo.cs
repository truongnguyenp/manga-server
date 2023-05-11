using BEComicWeb.Model.ImageModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.AuthencationModel
{
    public class UserInfo
    {
        [PersonalData]
        [Required]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Coins { get; set; }
        public string? National { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

        public UserInfo(Users user)
        {
            Id = user.Id;   
            Name = user.Name;
            Coins = user.Coins;
            National = user.National;
            CreatedDate = user.CreatedDate;
            LastModified = user.LastModified;
        }
    }
}
