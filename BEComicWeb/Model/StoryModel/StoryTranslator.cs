using BEComicWeb.Model.AuthencationModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    [Keyless]
    public class StoryTranslator
    {
        [ForeignKey("StoryId")]
        public Stories? Story { get; set;}
        [ForeignKey("TranslatorId")]
        public Users? Translator { get; set; }
        public DateTime? Created { get; set; }
    }
}
