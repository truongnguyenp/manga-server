using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.AuthencationModel
{
    public class Users : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }
        [ForeignKey("ImageId")]
        public string? UserImage { get; set; }
        public int? Coins { get; set; }
        public string? National { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
