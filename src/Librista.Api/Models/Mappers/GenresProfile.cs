using AutoMapper;
using Librista.Api.Models.DTOs.Genres;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class GenresProfile : Profile
{
    public GenresProfile()
    {
        CreateMap<GenreCreationDto, Genre>();
        CreateMap<Genre, GenreResultDto>();
        CreateMap<GenreUpdateDto, Genre>();
    }
}