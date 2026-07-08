using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EcoMeal.API.Entities;

public class Package
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    [ForeignKey(nameof(Business))]
    public required int BusinessId { get; set; }
    [ForeignKey(nameof(PackageType))]
    public required int PackageTypeId { get; set;}
    
    public string? Description { get; set; }
    public required double Price { get; set; }
    public required DateTime StartPickup { get; set;}
    public required DateTime EndPickup { get; set; }


    // Links
    public PackageType PackageType { get; set; }
    public Business Business { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}