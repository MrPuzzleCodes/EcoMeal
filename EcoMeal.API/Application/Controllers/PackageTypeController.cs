using EcoMeal.API.Entities;
using EcoMeal.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoMeal.API.Application.Models;
using System.Runtime.CompilerServices;

namespace EcoMeal.API.Application.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PackageTypeController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public PackageTypeController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackageTypeDTO>>> GetAllPackageTypes()
    {
        var packageTypeDTO = await _context.PackageType
            .Select( pt => new PackageTypeDTO
            {
                Name = pt.Name,
                Id = pt.Id
            }).ToListAsync();

        return Ok(packageTypeDTO);
    }
}