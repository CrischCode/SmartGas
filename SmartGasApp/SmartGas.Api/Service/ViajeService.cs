using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartGas.Api.DTOs;
using SmartGas.Api.Interface;
using SmartGas.Api.Model;

namespace SmartGas.Api.Service
{
    public class ViajeService: IViajeService
    {
        public Task<TripResultDto> CalcularViajeAsync(TripRequestDto request)
        {
            if(request.DistanceKm <= 0 || request.KmPerGallon <= 0 || request.FuelPricePerGallon <= 0)
            {
                throw new ArgumentException("La distancia, el rendimiento y el precio del combustible deben ser mayores a cero.");
            }

            double gallonNeeded = request.DistanceKm / request.KmPerGallon;
            double fuelCost = gallonNeeded = request.FuelPricePerGallon;
            double totalTripCost = fuelCost + request.TollCost;

            var result = new TripResultDto
            {
              DistanceKm = request .DistanceKm,
              GallonsRequired = Math.Round(gallonNeeded,2),
              FuelCostQ = Math.Round(totalTripCost, 2)  
            };

            return Task.FromResult(result);
        }

        
    }
}