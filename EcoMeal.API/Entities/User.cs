using Microsoft.AspNetCore.Identity;

namespace EcoMeal.API.Entities;

public class User : IdentityUser<int>
{
    public string? Name { get; set; }
    public string? Contact { get; set; }

    // Links
    // public ICollection<Order> Orders { get; set; } = new List<Order>();
}