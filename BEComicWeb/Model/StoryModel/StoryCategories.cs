﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEComicWeb.Model.StoryModel
{
    public class StoryCategories
    {
        [Key]
        [Column(Order = 1)]
        public string? StoryId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string? CategoryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
