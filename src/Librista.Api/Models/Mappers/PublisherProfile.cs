using AutoMapper;
using Librista.Api.Models.DTOs.Publishers;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreateMap<PublisherCreationDto, Publisher>();
        CreateMap<Publisher, PublisherResultDto>();
        CreateMap<PublisherUpdateDto, Publisher>();
    }
}