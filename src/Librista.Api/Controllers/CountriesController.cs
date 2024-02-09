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
    [HttpGet("{id:long}")]
    public async Task<ActionResult<CountryResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
    [HttpGet]
    public async Task<ActionResult<List<CountryResultDto>>> GetAll([FromQuery] CountryFilter filter, CancellationToken cancellationToken)
    {
        throw null;   
    }
}