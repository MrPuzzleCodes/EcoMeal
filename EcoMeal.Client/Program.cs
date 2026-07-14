using EcoMeal.Client.Components;
using EcoMeal.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<AuthenticationHeaderHandler>();

var apiClientBuilder = builder.Services.AddHttpClient("EcoMealApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7287/");
}).AddHttpMessageHandler<AuthenticationHeaderHandler>();

// In development the backend uses the ASP.NET self-signed dev certificate.
// Accept it for the server-to-server API calls so the Authorization header is not
// dropped by an http->https redirect (which strips auth headers on cross-scheme redirects).
if (builder.Environment.IsDevelopment())
{
    apiClientBuilder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    });
}


builder.Services.AddScoped(sp => 
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("EcoMealApi"));

builder.Services.AddScoped<EcoMeal.Client.Services.BusinessService>();
builder.Services.AddScoped<EcoMeal.Client.Services.PackageTypeService>();
builder.Services.AddScoped<EcoMeal.Client.Services.PackageService>();
builder.Services.AddScoped<EcoMeal.Client.Services.OrderService>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
