using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace EcoMeal.Client.Models;

public class BusinessDetailsModel : BusinessModel
{
    public required int BusinessTypeId { get; set; }
    public List<PackageModel>? Packages { get; set; }
    
}