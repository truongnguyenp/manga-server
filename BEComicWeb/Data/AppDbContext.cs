using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Authors>? Authors { get; set; }
        public virtual DbSet<Stories>? Stories { get; set; }
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

            base.OnModelCreating(builder);
        }
    }
}

