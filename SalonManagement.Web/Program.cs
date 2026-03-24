using Microsoft.AspNetCore.Builder; // <-- Add this using directive
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SalonManagement.Infrastructure;
using SalonManagement.Web.Components;
using static SalonManagement.Web.Components.Pages.UserDashboard;
var builder = WebApplication.CreateBuilder(args);

// Register infra services (includes DbContext)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddScoped<UserSession>();

var app = builder.Build();

// Seed initial admin if needed (reads config/env vars)
//await AdminSeedExtensions.EnsureSeedDataAsync(app.Services, builder.Configuration);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
