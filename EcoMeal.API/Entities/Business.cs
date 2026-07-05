using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcoMeal.API.Entities;

public class Business
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public string? Description { get; set; }
    public required string Contact { get; set; }
    [ForeignKey(nameof(BusinessType))]
    public int BusinessTypeId { get; set; }

    // Links
    public required BusinessType BusinessType { get; set; }
    public ICollection <Package> Packages { get; set; } = new List<Package>();
}