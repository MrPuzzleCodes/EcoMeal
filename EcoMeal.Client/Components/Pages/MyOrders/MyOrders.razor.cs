using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EcoMeal.Client.Components.Pages.MyOrders;

public partial class MyOrders
{
    [Inject]
    public required OrderService OrderService { get; set; }
    private List<OrderGetModel>? MyOrdersList { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            MyOrdersList = await OrderService.GetMyOrdersAsync();
            StateHasChanged();
        }
        
    }
}