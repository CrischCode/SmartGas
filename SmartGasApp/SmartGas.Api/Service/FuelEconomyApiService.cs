using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SmartGas.Api.DTOs;
using SmartGas.Api.Interface;

namespace SmartGas.Api.Service
{
    public class FuelEconomyApiService: IFuelEconomyApiService
    {
        private readonly HttpClient _httpClient;

        public FuelEconomyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://www.fueleconomy.gov/ws/rest/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<string>> GetMakesFromApiAsync()
        {
            try
            {
               var response = await _httpClient.GetAsync("vehicle/menu/make");
               response.EnsureSuccessStatusCode();

               var content = await response.Content.ReadAsByteArrayAsync();
               var result = JsonSerializer.Deserialize<FuelEconomyMenuResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

               return result?.MenuItems?.Select(m => m.Value) ?? Enumerable.Empty<string>();
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        public async Task<IEnumerable<string>> GetModelosApiAsync(string obtener)
        {
            try {
            var response = await _httpClient.GetAsync($"vehicule/menu/modelo?obtener={Uri.EscapeDataString(obtener)}");
            response.EnsureSuccessStatusCode();

            var contenido = await response.Content.ReadAsStringAsync();
            var resultado = JsonSerializer.Deserialize<FuelEconomyMenuResponse>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return resultado?.MenuItems?.Select(m => m.Value) ?? Enumerable.Empty<String>();

            } 
            catch
            {
                return Enumerable.Empty<String>();
            }

        }
    }
}