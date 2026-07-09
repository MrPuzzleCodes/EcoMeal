using System.ComponentModel.DataAnnotations;

namespace EcoMeal.API.Application.Models;

public class PackageEditDTO
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
    public DateTime StartPickup { get; set; }
    public DateTime EndPickup { get; set; }
    public int PackageTypeId { get; set; }
}