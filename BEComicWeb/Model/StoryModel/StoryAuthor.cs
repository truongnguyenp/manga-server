using BEComicWeb.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    [Keyless]
    public class StoryAuthor
    {
        [ForeignKey("AuthorId")]
        public Authors? Author { get; set; }
        [ForeignKey("StoryId")]
        public Stories? Story { get; set; }
        public DateTime? Created { get; set; }
    }
    
}