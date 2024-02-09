using AutoMapper;
using Librista.Api.Models.DTOs.Books;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<BookCreationDto, Book>();
        CreateMap<Book, BookResultDto>();
        CreateMap<BookUpdateDto, Book>();
    }
}