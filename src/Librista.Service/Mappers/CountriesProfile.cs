using AutoMapper;
using Librista.Domain.Entities;
using Librista.Service.Models.IntegrationModels;

namespace Librista.Service.Mappers;

public class CountriesProfile : Profile
{
    public CountriesProfile()
    {
        CreateMap<Country, CountryApiModel>()
            .ReverseMap()
            .ForMember(
                apiModel => apiModel.Name,
                options
                    => options.MapFrom(src => src.Country))
            .ForMember(
                apiModel => apiModel.Cities,
                options
                    => options.MapFrom(src
                        => src.Cities.Select(cityName => new City
                        {
                            Name = cityName
                        })));

    }
}