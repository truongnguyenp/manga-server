using BEComicWeb.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    [Keyless]
    public class StoryTranslator
    {
        [ForeignKey("StoryId")]
        public Stories? Story { get; set;}
        [ForeignKey("TranslatorId")]
        public Translators? Translator { get; set; }
        public DateTime? Created { get; set; }
    }
}
