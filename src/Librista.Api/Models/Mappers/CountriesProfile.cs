using AutoMapper;
using Librista.Api.Models.DTOs.Countries;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class CountriesProfile : Profile
{
    public CountriesProfile()
    {
        CreateMap<Country, CountryResultDto>();
    }
}