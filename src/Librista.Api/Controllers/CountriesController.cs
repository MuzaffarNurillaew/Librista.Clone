using AutoMapper;
using Librista.Api.Models.DTOs.Countries;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountryService countryService, IMapper mapper) : ControllerBase
{
    [HttpPost("reload")]
    public async Task<IActionResult> CreateCountries(CancellationToken cancellationToken)
    {
        await countryService.CreateAllAsync(cancellationToken);
        return NoContent();
    }
    [HttpGet("{id:long}")]
    public async Task<ActionResult<CountryResultDto>> GetById(long id, CancellationToken cancellationToken, bool loadRelations = false)
    {
        var country = await countryService.GetAsync(id, loadRelations, cancellationToken);
        var mappedCountry = mapper.Map<CountryResultDto>(country);
        return Ok(mappedCountry);
    }
    [HttpGet]
    public async Task<ActionResult<List<CountryResultDto>>> GetAll([FromQuery] CountryFilter filter, CancellationToken cancellationToken, bool loadRelations = false)
    {
        var countries = await countryService.GetAllAsync(filter, loadRelations, cancellationToken);
        var mappedCountries = mapper.Map<IEnumerable<CountryResultDto>>(countries);

        return Ok(mappedCountries);
    }
}