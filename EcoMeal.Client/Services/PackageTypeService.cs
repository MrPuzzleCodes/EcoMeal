using System.Diagnostics;
using EcoMeal.Client.Models;

namespace EcoMeal.Client.Services;

public class PackageTypeService
{
    private readonly HttpClient _http;
    public PackageTypeService(HttpClient http)
    {
        _http = http;
    }
    public async Task<List<PackageTypeModel>> GetAllPackageTypes()
    {
        var packagetypes = await _http.GetFromJsonAsync<List<PackageTypeModel>>("/api/packagetype");
        return packagetypes ?? new List<PackageTypeModel>();
    }

}