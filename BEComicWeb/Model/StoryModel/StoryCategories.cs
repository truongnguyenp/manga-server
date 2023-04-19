using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    [Keyless]
    public class StoryCategories
    {
        [ForeignKey("StoryId")]
        public Stories? Story { get; set; }
        [ForeignKey("CategoryId")]
        public Categories? Category { get; set; }
        public DateTime? Created { get; set; }
    }
}
