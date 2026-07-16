using System.Security.Claims;
using EcoMeal.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoMeal.API.Application.Models;
using EcoMeal.API.Entities;
using Microsoft.Identity.Client;

namespace EcoMeal.API.Application.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public OrderController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<OrderGetDTO>> PlaceOrder([FromBody] OrderCreateDTO request)
    {
        var userId = GetCurrentUserId();

        var package = await _context.Package
            .Include(p => p.Business)
            .Include(p => p.Orders)
            .FirstOrDefaultAsync(p => p.Id == request.PackageId);

        if(package is null)
        {
            return NotFound("Package was not found");
        }

        if (package.Orders.Any())
        {
            return BadRequest("Package is no longer available");
        }

        var order = new Order
        {
            UserId = userId,
            PackageId = package.Id,
            Status = 1,
            Date = DateTime.UtcNow,
        };

        _context.Order.Add(order);
        await _context.SaveChangesAsync();

        return Ok(new OrderGetDTO
        {
            Id = order.Id,
            Date = order.Date,
            Status = order.Status,
            PackageName = package.Name,
            Price = package.Price,
            BusinessId = package.BusinessId,
            BusinessName = package.Business.Name
        });
    }

    [Authorize(Roles="User")]
    [HttpGet("my")]
    public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetMyOrders()
    {
        var userId = GetCurrentUserId();

        var orders = await _context.Order
        .Where(o => o.UserId == userId)
        .OrderByDescending(o => o.Date)
        .Select(o => new OrderGetDTO
        {
            Id = o.Id,
            Date = o.Date,
            Status = o.Status,
            Price = o.Package.Price,
            BusinessId = o.Package.BusinessId,
            BusinessName = o.Package.Business.Name,
            PackageName = o.Package.Name
        })
        .ToListAsync();

        return Ok(orders);
    }

    [Authorize(Roles="Admin")]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetAllOrders()
    {

        var orders = await _context.Order
        .Include(o => o.User)
        .OrderByDescending(o => o.Date)
        .Select(o => new OrderGetDTO
        {
            Id = o.Id,
            Date = o.Date,
            Status = o.Status,
            Price = o.Package.Price,
            BusinessId = o.Package.BusinessId,
            BusinessName = o.Package.Business.Name,
            UserName = o.User.UserName,
            PackageName = o.Package.Name
        })
        .ToListAsync();

        return Ok(orders);
    }

    private int GetCurrentUserId()
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.Parse(userIdValue!);
    }
}