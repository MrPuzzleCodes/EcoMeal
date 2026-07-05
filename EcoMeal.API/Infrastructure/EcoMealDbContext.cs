using EcoMeal.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.API.Infrastructure;

public class EcoMealDbContext : DbContext
{
    public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options)
        :base(options)
    {}

    public DbSet<User> User { get; set; }
    public DbSet<PackageType> PackageType { get; set; }
    public DbSet<BusinessType> BusinessType { get; set; }
    public DbSet<Business> Business { get; set; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Business>().HasKey(e => e.Id);

        modelbuilder.Entity<Business>()
            .HasOne(p => p.BusinessType)
            .WithMany(p => p.Businesses)
            .HasForeignKey(p => p.BusinessTypeId);
    }
}