using BEComicWeb.Model.ImageModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.AuthencationModel
{
    public class Users : IdentityUser
    {
        [PersonalData]
        [Required]
        public string? Name { get; set; }
        [ForeignKey("ImageId")]
        public Image? UserImage { get; set; }
        public int? Coins { get; set; }
        public string? National { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
