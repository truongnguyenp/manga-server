using BEComicWeb.Model.ImageModel;
using BEComicWeb.Model.PersonModel;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Authors>? AuthorsDb { get; set; }
        public virtual DbSet<Stories>? StoriesDb { get; set; }
        public virtual DbSet<Chapters>? ChaptersDb { get; set; }
        public virtual DbSet<Categories> CategoriesDb { get; set; }
        public virtual DbSet<StoryAuthor> StoryAuthorDb { get; set; }
        public virtual DbSet<StoryTranslator> StoryTranslatorDb { get; set; }
        public virtual DbSet<StoryCategories> StoryCategoriesDb { get; set; }
        public virtual DbSet<Image> ImageDb { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}

