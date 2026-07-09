using EcoMeal.API.Entities;
using EcoMeal.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoMeal.API.Application.Models;
using System.Runtime.CompilerServices;

namespace EcoMeal.API.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackageController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public PackageController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessDetailsDTO>> GetPackageById(int id)
    {
        var package = await _context.Package
            .Include(p => p.PackageType)
            .Select(p => new PackageDTO
            {
                Id = p.Id,
                Name = p.Name,
                BusinessId = p.BusinessId,
                PackageTypeId = p.PackageTypeId,
                PackageTypeName = p.PackageType.Name,
                Description = p.Description,
                Price = p.Price,
                StartPickup = p.StartPickup,
                EndPickup = p.EndPickup
            })
            .FirstOrDefaultAsync(p => p.Id == id);

        if (package is null)
        {
            return NotFound();
        }

        return Ok(package);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePackage(int id, [FromBody] PackageEditDTO packageEditDTO)
    {
        
        var package = await _context.Package.FindAsync(id);

        if(package == null)
        {
            return NotFound();
        }

        package.Name = packageEditDTO.Name;
        package.Description = packageEditDTO.Description;
        package.Price = packageEditDTO.Price;
        package.StartPickup = packageEditDTO.StartPickup;
        package.EndPickup = packageEditDTO.EndPickup;
        package.PackageTypeId = packageEditDTO.PackageTypeId;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}