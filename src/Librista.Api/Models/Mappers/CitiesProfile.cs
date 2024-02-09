using AutoMapper;
using Librista.Api.Models.DTOs.Cities;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class CitiesProfile : Profile
{
    public CitiesProfile()
    {
        CreateMap<City, CityResultDto>();
    }
}