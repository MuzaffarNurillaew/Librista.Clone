using AutoMapper;
using Librista.Api.Models.DTOs.Addresses;
using Librista.Domain.Entities;
using Librista.Service.Services;

namespace Librista.Api.Models.Mappers;

public class AddressesProfile : Profile
{
    public AddressesProfile()
    {
        CreateMap<AddressCreationDto, Address>();
        CreateMap<Address, AddressResultDto>();
        CreateMap<AddressUpdateDto, Address>();
    }
}