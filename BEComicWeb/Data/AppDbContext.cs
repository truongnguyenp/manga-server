using BEComicWeb.Model.AuthencationModel;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BEComicWeb.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public virtual DbSet<Stories>? StoriesDb { get; set; }
        public virtual DbSet<Chapters>? ChaptersDb { get; set; }
        public virtual DbSet<Categories> CategoriesDb { get; set; }
        public virtual DbSet<Authors> AuthorsDb { get; set; }
        public virtual DbSet<StoryAuthors> StoryAuthorsDb { get; set; }
        public virtual DbSet<StoryTranslators> StoryTranslatorDb { get; set; }
        public virtual DbSet<StoryCategories> StoryCategoriesDb { get; set; }
        public virtual DbSet<ChapterImages> ChapterImagesDb { get; set; }
        public virtual DbSet<Comments> CommentsDb { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StoryTranslators>().HasKey(e => new { e.StoryId, e.TranslatorId });
            builder.Entity<StoryHistories>().HasKey(e => new { e.ChapterId, e.UserId });
            builder.Entity<StoryCategories>().HasKey(e => new { e.StoryId, e.CategoryId });
            builder.Entity<StoryAuthors>().HasKey(e => new { e.StoryId, e.AuthorId });
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

