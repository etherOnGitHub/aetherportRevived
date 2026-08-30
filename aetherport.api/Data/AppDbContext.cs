using aetherport.api.Models;
using Microsoft.EntityFrameworkCore;

namespace aetherport.api.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

            entity.Property(p => p.Slug)
            .HasMaxLength(50)
            .IsRequired();

            entity.HasIndex(p => p.Slug)
            .IsUnique();

            entity.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();


            entity.Property(p => p.CreatedAt).IsRequired();
            entity.Property(p => p.UpdatedAt).IsRequired();
        });
            
    }
}