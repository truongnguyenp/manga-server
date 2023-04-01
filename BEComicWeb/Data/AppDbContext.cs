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
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Authors>(entity =>
            {
                entity.ToTable("Authors");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Alias).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.National).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Follows).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<Stories>(entity =>
            {
                entity.ToTable("Stories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Alias).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Image).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(1000).IsUnicode(false);
                entity.Property(e => e.Follows).IsUnicode(false);
                entity.Property(e => e.Status).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<Chapters>(entity =>
            {
                entity.ToTable("Chapters");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.Views).IsUnicode(false);
                entity.Property(e => e.Cost).IsUnicode(false);
                entity.Property(e => e.Created).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(1000).IsUnicode(false);
                entity.Property(e => e.Alias).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Keyword).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Created).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<StoryAuthor>(entity =>
            {
                entity.ToTable("StoryAuthor");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.StoryId).IsUnicode(false);
                entity.Property(e => e.AuthorId).IsUnicode(false);
                entity.Property(e => e.Created).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<StoryTranslator>(entity =>
            {
                entity.ToTable("StoryTranslator");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.StoryId).IsUnicode(false);
                entity.Property(e => e.TranslatorId).IsUnicode(false);
                entity.Property(e => e.Created).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            builder.Entity<StoryChapters>(entity =>
            {
                entity.ToTable("StoryChapters");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.StoryId).IsUnicode(false);
                entity.Property(e => e.TranslatorId).IsUnicode(false);
                entity.Property(e => e.Created).IsUnicode(false);
                entity.Property(e => e.LastModified).IsUnicode(false);
            });

            base.OnModelCreating(builder);
        }
    }
}

