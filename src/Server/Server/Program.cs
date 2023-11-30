var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOrchardCms();

var app = builder.Build();

app.UseStaticFiles();

app.UseOrchardCore();

app.Run();
