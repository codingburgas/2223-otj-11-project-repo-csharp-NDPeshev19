var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOrchardCms()
    .AddSetupFeatures("OrchardCore.AutoSetup")
    .ConfigureAzureADSettings()
    ;

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseStaticFiles();

app.UseOrchardCore();

app.Run();
