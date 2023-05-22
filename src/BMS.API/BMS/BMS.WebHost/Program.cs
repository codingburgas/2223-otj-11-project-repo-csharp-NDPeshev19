using BMS.Data.Data;
using BMS.Data.Models.Auth;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Security.Principal;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


// Entity Framework
var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString, o =>
    {
        o.MigrationsAssembly("BMS.WebHost");
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

// Identity
builder.Services.AddDefaultIdentity<Account>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityCore<Worker>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentityCore<Patient>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services
//    .AddLogging(conf =>
//    {
//        conf.ClearProviders();

//        // conf.AddSeq(configuration.GetSection("Seq"));
//        conf.AddAzureWebAppDiagnostics();
//        conf.AddConsole();
//    })
//    .Configure<AzureFileLoggerOptions>(options =>
//    {
//        options.FileName = "first-azure-log";
//        options.FileSizeLimit = 50 * 1024;
//        options.RetainedFileCountLimit = 10;
//    });

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
