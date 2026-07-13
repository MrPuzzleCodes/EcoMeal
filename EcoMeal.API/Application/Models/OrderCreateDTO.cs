using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.API.Application.Models;

public class OrderCreateDTO
{
    [Required]
    public int PackageId { get; set; }
}