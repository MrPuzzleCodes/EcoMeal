using System.Runtime.InteropServices;
using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace EcoMeal.Client.Components.BusinessCard;

public partial class BusinessCard
{
    [Parameter]
    public required BusinessModel Business { get; set; }
    [Inject]
    public required BusinessService BusinessService { get; set; }
    [Parameter]
    public EventCallback OnDeleted { get; set; }
    [Inject]
    public required NavigationManager Navigation { get; set; }

    
    public async Task<bool> DeleteBusiness()
    {
        var success = await BusinessService.DeleteAsync(Business.Id);
        await OnDeleted.InvokeAsync();
        return success;
    }



    public void NavigateToDetails()
    {
        Navigation.NavigateTo($"/business/{Business.Id}");
    }
}