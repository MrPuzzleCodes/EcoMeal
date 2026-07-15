
using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EcoMeal.Client.Components.BusinessList;


public partial class BusinessList
{
    [Inject]
    public required BusinessService BusinessService { get; set; }



    private List<BusinessModel>? Businesses { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {

                await RefreshList();
            }
            catch
            {
                Console.Write("Failed to refresh list");
            }
        }

    }

    private async Task RefreshList()
    {
        Businesses = await BusinessService.GetAllAsync();
        StateHasChanged();
    }
}