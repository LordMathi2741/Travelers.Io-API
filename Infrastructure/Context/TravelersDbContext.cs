using Infrastructure.subscription.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class TravelersDbContext(DbContextOptions<TravelersDbContext> options) : DbContext(options)
{
    public DbSet<Plan> Plans { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("Database is not configured");
        }
        
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plan>(entity =>
        {
            entity.ToTable("plans");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.MaxUsers).HasColumnName("max_users").IsRequired();
            entity.Property(e => e.IsDefalut).HasColumnName("is_default").IsRequired();
        });
    }
}