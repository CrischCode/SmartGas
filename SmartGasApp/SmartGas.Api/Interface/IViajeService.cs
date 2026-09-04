using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartGas.Api.DTOs;
using SmartGas.Api.Model;

namespace SmartGas.Api.Interface
{
    public interface IViajeService
    {
        Task<TripResultDto> CalcularViajeAsync(TripRequestDto request);
    }
}