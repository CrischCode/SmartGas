using Microsoft.EntityFrameworkCore;
using SmartGas.Api.Data;
using SmartGas.Api.Interface;
using SmartGas.Api.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartGas API",
        Version = "v1",
        Description = "API oficial de SmartGas conectada a PostgreSQL y FuelEconomy.gov"
    });
});

builder.Services.AddScoped<IViajeService, ViajeService>();
builder.Services.AddHttpClient<IFuelEconomyApiService, FuelEconomyApiService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Host=localhost;Database=smartgasdb;Username=postgres;Password=StrongPassword123!";

builder.Services.AddDbContext<SmartGasDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SmartGasDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartGas API V1");
    c.RoutePrefix = string.Empty; 
});

app.UseAuthorization();
app.MapControllers();

app.Run();