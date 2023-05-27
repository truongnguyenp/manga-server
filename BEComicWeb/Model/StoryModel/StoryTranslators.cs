using BEComicWeb.Model.AuthencationModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryTranslators
    {
        [Key]
        [Column(Order = 1)]
        public string? StoryId { get; set;}
        [Key]
        [Column(Order = 2)]
        public string? TranslatorId { get; set; }
        public DateTime? Created { get; set; }
    }
}
