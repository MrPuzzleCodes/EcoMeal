using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace EcoMeal.Client.Models;

public class BusinessDetailsModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public string? Description { get; set; }
    public required string Contact { get; set; }
    public required string BusinessTypeName { get; set; }
    
}