using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGas.Api.Model
{
    public class CatalogoVehiculo
    {
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;       // Ej. Toyota
    public string Modelo { get; set; } = string.Empty;      // Ej. Corolla
    public int Año { get; set; }                          // Ej. 2022
    public double EstimadodKmPoGalon { get; set; }
    }
}