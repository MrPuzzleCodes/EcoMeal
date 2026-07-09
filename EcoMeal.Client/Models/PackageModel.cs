using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EcoMeal.Client.Models;

public class PackageModel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required int BusinessId { get; set; }
    public required int PackageTypeId { get; set;}
    
    public string? Description { get; set; }
    public required double Price { get; set; }
    public required DateTime StartPickup { get; set; }
    public required DateTime EndPickup { get; set; }

    public string? PackageTypeName { get; set; }
}