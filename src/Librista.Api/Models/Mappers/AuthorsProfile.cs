using AutoMapper;
using Librista.Api.Models.DTOs.Authors;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class AuthorsProfile : Profile
{
    public AuthorsProfile()
    {
        CreateMap<AuthorCreationDto, Author>();
        CreateMap<Author, AuthorResultDto>();
        CreateMap<AuthorUpdateDto, Author>();
        CreateMap<AuthorCreationDtoForBook, Author>();
    }
}