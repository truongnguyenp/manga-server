using BEComicWeb.Model.AuthencationModel;
using BEComicWeb.Model.ChapterModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    [Keyless]
    public class StoryHistory
    {
        [ForeignKey("ChapterId")]
        public Chapters? Chapter;
        [ForeignKey("UserId")]
        public Users? User;
        public DateTime? CreatedDate;
    }
}
