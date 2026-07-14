using System.Runtime.InteropServices;
using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace EcoMeal.Client.Components.PackageCard;

public partial class PackageCard
{
    [Parameter]
    public required PackageModel Package { get; set; }
    [Inject]
    public required BusinessService BusinessService { get; set; }
    [Inject]
    public required PackageService PackageService { get; set; }
    [Inject]
    public required OrderService OrderService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    

    [Parameter]
    public EventCallback OnDeleted { get; set; }
    
    public async Task<bool> DeletePackage()
    {
        var success = await PackageService.DeletePackage(Package.Id);
        await OnDeleted.InvokeAsync();
        return success;
    }

    public void NavigateToEditPackage()
    {
        NavigationManager.NavigateTo($"business/{Package.BusinessId}/package/{Package.Id}/edit");
    }

    public async Task<bool> PlaceOrderAsync()
    {
        var success = await OrderService.PlaceOrderAsync(Package.Id);
        await OnDeleted.InvokeAsync();
        return success;
    }

}