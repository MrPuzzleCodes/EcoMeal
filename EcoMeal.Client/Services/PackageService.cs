using System.Diagnostics;
using EcoMeal.Client.Models;

namespace EcoMeal.Client.Services;

public class PackageService
{
    private readonly HttpClient _http;
    public PackageService(HttpClient http)
    {
        _http = http;
    }

    public async Task<PackageModel?> GetPackageById(int id)
    {
        var package = await _http.GetFromJsonAsync<PackageModel>($"api/package/{id}");
        return package;
    }

    public async Task<bool> UpdatePackage(PackageEditModel package)
    {
        var response = await _http.PutAsJsonAsync($"api/package/{package.Id}",package);
        return response.IsSuccessStatusCode;
    }
}