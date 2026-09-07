using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGas.Api.Interface
{
    public interface IFuelEconomyApiService
    {
    Task<IEnumerable<string>> GetMakesFromApiAsync();
    Task<IEnumerable<string>> GetModelosApiAsync(string obtener); 
    }
}