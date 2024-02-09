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
    public async Task<ActionResult<CityResultDto>> GetById(long id, CancellationToken cancellationToken, bool loadRelations = false)
    {
        var city = await cityService.GetAsync(id, 
             loadRelations: loadRelations,
             throwException: true,
             cancellationToken: cancellationToken);
        
        var mappedEntity = mapper.Map<CityResultDto>(city);
        return Ok(mappedEntity);
    }

    [HttpGet]
    public async Task<ActionResult<List<CityResultDto>>> GetAll([FromQuery] CityFilter filter,
        CancellationToken cancellationToken, bool loadRelations = false)
    {
        var cities = await cityService.GetAllAsync(
            filter: filter,
            loadRelations: loadRelations,
            cancellationToken: cancellationToken);
        var mappedCities = mapper.Map<IEnumerable<CityResultDto>>(cities);

        return Ok(mappedCities);
    }
}