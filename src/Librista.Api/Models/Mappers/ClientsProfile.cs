using AutoMapper;
using Librista.Api.Models.DTOs.Clients;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        CreateMap<ClientCreationDto, Client>();
        CreateMap<Client, ClientResultDto>();
        CreateMap<ClientUpdateDto, Client>();
    }
}