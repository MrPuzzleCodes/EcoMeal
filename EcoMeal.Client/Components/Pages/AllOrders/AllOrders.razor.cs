using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EcoMeal.Client.Components.Pages.AllOrders;

public partial class AllOrders
{
    [Inject]
    public required OrderService OrderService { get; set; }
    private List<OrderGetModel>? AllOrdersList { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                AllOrdersList = await OrderService.GetAllOrdersAsync();
                StateHasChanged();
                
            } catch
            {
                
            }
        }
        
    }
}