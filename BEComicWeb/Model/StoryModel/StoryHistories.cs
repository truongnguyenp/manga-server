using BEComicWeb.Model.AuthencationModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    
    public class StoryHistories
    {
        [Key]
        [Column(Order = 1)]
        public string? ChapterId;
        [Key]
        [Column(Order = 2)]
        public string? UserId;
        public DateTime? CreatedDate;
    }
}
