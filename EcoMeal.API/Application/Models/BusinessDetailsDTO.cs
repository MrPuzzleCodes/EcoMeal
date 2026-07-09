namespace EcoMeal.API.Application.Models;

public class BusinessDetailsDTO : BusinessDTO
{
    public required int BusinessTypeId { get; set; }
    public List<PackageDTO>? Packages { get; set; }
}