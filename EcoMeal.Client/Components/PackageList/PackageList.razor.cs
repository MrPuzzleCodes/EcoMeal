using EcoMeal.Client.Models;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EcoMeal.Client.Components.PackageList;



public partial class PackageList{

        [Parameter]
        public int BusinessId { get; set; }
        public BusinessDetailsModel? Business { get; set; }

        [Inject]
        public required BusinessService BusinessService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await RefreshList();
        }

        private async Task RefreshList()
        {
            Business = await BusinessService.GetOneById(BusinessId);
            StateHasChanged();
        }
}