using EcoMeal.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.API.Infrastructure;

public class EcoMealDbContext : IdentityDbContext<User, IdentityRole<int>,int>
{
    public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options)
        :base(options)
    {}

    public DbSet<Package> Package { get; set; }
    public DbSet<PackageType> PackageType { get; set; }
    public DbSet<Business> Business { get; set; }
    public DbSet<BusinessType> BusinessType { get; set; }
    public DbSet<Order> Order { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    { 
        base.OnModelCreating(modelbuilder);

        //modelbuilder.Entity<Business>().HasKey(e => e.Id);

        /// Many Businesses have one BusinessType (M:1)
        modelbuilder.Entity<Business>()
            .HasOne(b => b.BusinessType)
            .WithMany(bt => bt.Businesses)
            .HasForeignKey(b => b.BusinessTypeId);

        /// Many Packages have one Business (M:1)
        modelbuilder.Entity<Package>()
            .HasOne(p => p.Business)
            .WithMany(b => b.Packages)
            .HasForeignKey(p => p.BusinessId);

        /// Many packages have one PackageType (M:1)
        modelbuilder.Entity<Package>()
            .HasOne(p => p.PackageType)
            .WithMany(pt => pt.Packages)
            .HasForeignKey(p => p.PackageTypeId);

        /// Many Orders have one Package (M:1)
        modelbuilder.Entity<Order>()
            .HasOne(o => o.Package)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.PackageId);

        /// Many Orders have one User (M:1)
        /* modelbuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
        */

    }
}