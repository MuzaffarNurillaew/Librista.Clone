using AutoMapper;
using Librista.Api.Models.DTOs.Cities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(ICityService cityService, IMapper mapper) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<CityResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
    [HttpGet]
    public async Task<ActionResult<List<CityResultDto>>> GetAll([FromQuery] CityFilter filter, CancellationToken cancellationToken)
    {
        throw null;
    }
    
}