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
    public required NavigationManager NavigationManager { get; set; }

    public void NavigateToEditPackage()
    {
        NavigationManager.NavigateTo($"business/{Package.BusinessId}/package/{Package.Id}/edit");
    }

}