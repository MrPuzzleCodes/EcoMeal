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
}