using System.ComponentModel.DataAnnotations;

namespace BEComicWeb.Model.ImageModel
{
    public class Image
    {
        [Key]
        [Required]
        public string? Id {get; set;}
        public string? Name { get; set;}
        public string? Storage { get; set;}  
    }
}
