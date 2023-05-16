using BEComicWeb.Model;
using BEComicWeb.Model.AuthencationModel;
using BEComicWeb.Model.ImageModel;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public virtual DbSet<Stories>? StoriesDb { get; set; }
        public virtual DbSet<Chapters>? ChaptersDb { get; set; }
        public virtual DbSet<Categories> CategoriesDb { get; set; }
        public virtual DbSet<Authors> AuthorsDb { get; set; }
        public virtual DbSet<StoryAuthor> StoryAuthorDb { get; set; }
        public virtual DbSet<StoryTranslator> StoryTranslatorDb { get; set; }
        public virtual DbSet<StoryCategories> StoryCategoriesDb { get; set; }
        public virtual DbSet<ChapterImages> ChapterImagesDb { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Ignore<UserInfo>();
            builder.Ignore<ChapterData>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("connMSSQL");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

