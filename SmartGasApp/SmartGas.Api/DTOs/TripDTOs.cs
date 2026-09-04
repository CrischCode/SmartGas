using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGas.Api.DTOs
{
    public class TripRequestDto
    {
        public double DistanceKm { get; set; }
        public double KmPerGallon { get; set; }
        public double FuelPricePerGallon { get; set; }
        public double TollCost { get; set; } = 0;
    }

    public class TripResultDto
    {
        public double DistanceKm { get; set; }
        public double GallonsRequired { get; set; }
        public double FuelCostQ { get; set; }
        public double TotalTripCostQ { get; set; }
    }
}