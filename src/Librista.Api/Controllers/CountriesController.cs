using AutoMapper;
using Librista.Api.Models.DTOs.Countries;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountryService countryService, IMapper mapper) : ControllerBase
{
    // public async Task<List<CountryResultDto>> GetAll
}