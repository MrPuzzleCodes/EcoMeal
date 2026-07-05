using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMeal.API.Entities;

public class Package
{
    [Key]
    public int Id { get; set; }
    public required int No_Package { get; set; }

    [ForeignKey(nameof(Business))]
    public required int BusinessId { get; set; }
    [ForeignKey(nameof(PackageType))]
    public required int PackageTypeId { get; set;}
    
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public required DateTime Start_Pickup { get; set;}
    public required DateTime End_Pickup { get; set; }


    // Links
    public required PackageType PackageType { get; set; }
    public required Business Business { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}