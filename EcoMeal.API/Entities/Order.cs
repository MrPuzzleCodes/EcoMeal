using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace EcoMeal.API.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public required int UserId { get; set; }

    [ForeignKey(nameof(Package))]
    public required int PackageId { get; set; }

    public required int Status { get; set; }
    public required DateTime Date { get; set; }

    // Links
    public required User User { get; set; }
    public required Package Package { get; set; }

}