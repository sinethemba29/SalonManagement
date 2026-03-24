using MudBlazor.Services; // Add this at the top

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// ...rest of your code