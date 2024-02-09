using AutoMapper;
using Librista.Api.Models.DTOs.Publishers;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class PublishersProfile : Profile
{
    public PublishersProfile()
    {
        CreateMap<PublisherCreationDto, Publisher>();
        CreateMap<Publisher, PublisherResultDto>();
        CreateMap<PublisherUpdateDto, Publisher>();
    }
}