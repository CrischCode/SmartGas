using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGas.Api.Data;
using SmartGas.Api.DTOs;
using SmartGas.Api.Interface;
using SmartGas.Api.Model;

namespace SmartGas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmartGasController : ControllerBase
{
    private readonly SmartGasDbContext _context;
    private readonly IViajeService _tripService;
    private readonly IFuelEconomyApiService _fuelEconomyApiService;

    public SmartGasController(
        SmartGasDbContext context, 
        IViajeService tripService, 
        IFuelEconomyApiService fuelEconomyApiService)
    {
        _context = context;
        _tripService = tripService;
        _fuelEconomyApiService = fuelEconomyApiService;
    }

    [HttpGet("vehicles/makes")]
    public async Task<IActionResult> GetMakes()
    {
        var apiMakes = await _fuelEconomyApiService.GetMakesFromApiAsync();
        if (apiMakes.Any())
        {
            return Ok(apiMakes);
        }

        var localMakes = await _context.catalogoVehiculos
            .Select(v => v.Marca)
            .Distinct()
            .OrderBy(m => m)
            .ToListAsync();
            
        return Ok(localMakes);
    }

    [HttpGet("vehicles/models")]
    public async Task<IActionResult> GetModels([FromQuery] string make)
    {
        var apiModels = await _fuelEconomyApiService.GetModelosApiAsync(make);
        if (apiModels.Any())
        {
            return Ok(apiModels);
        }

        var localModels = await _context.catalogoVehiculos
            .Where(v => v.Marca == make)
            .Select(v => v.Modelo)
            .Distinct()
            .OrderBy(m => m)
            .ToListAsync();
            
        return Ok(localModels);
    }

    [HttpPost("calculate-trip")]
    public async Task<IActionResult> CalculateTrip([FromBody] TripRequestDto request)
    {
        try
        {
            var result = await _tripService.CalcularViajeAsync(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}