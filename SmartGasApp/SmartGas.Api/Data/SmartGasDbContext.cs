using Microsoft.EntityFrameworkCore;
using SmartGas.Api.Model;

namespace SmartGas.Api.Data;

public class SmartGasDbContext : DbContext
{
    public SmartGasDbContext(DbContextOptions<SmartGasDbContext> options) : base(options) { }

    public DbSet<CatalogoVehiculo> catalogoVehiculos => Set<CatalogoVehiculo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Datos iniciales de respaldo locales (Seeding)
        modelBuilder.Entity<CatalogoVehiculo>().HasData(
            new CatalogoVehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla", Año = 2022, EstimadodKmPoGalon = 45.0 },
            new CatalogoVehiculo { Id = 2, Marca = "Toyota", Modelo = "Hilux", Año = 2023, EstimadodKmPoGalon = 32.0 },
            new CatalogoVehiculo { Id = 3, Marca = "Hyundai", Modelo = "Elantra", Año = 2021, EstimadodKmPoGalon = 42.0 },
            new CatalogoVehiculo { Id = 4, Marca = "Honda", Modelo = "Civic", Año = 2022, EstimadodKmPoGalon = 44.0 }
        );
    }
}