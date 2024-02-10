using AutoMapper;
using Librista.Api.Models.DTOs.Books;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BookResultDto>> Create(BookCreationDto book, CancellationToken cancellationToken)
    {
        var mappedBook = mapper.Map<Book>(book);
        var createdBook = await bookService.CreateAsync(mappedBook, cancellationToken);
        var resultBook = mapper.Map<BookResultDto>(createdBook);

        return Ok(resultBook);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BookResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var book = await bookService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);
        var mappedBook = mapper.Map<BookResultDto>(book);

        return Ok(mappedBook);
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResultDto>>> GetAll([FromQuery] BookFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var books = await bookService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedBooks = mapper.Map<IEnumerable<BookResultDto>>(books);

        return Ok(mappedBooks);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BookResultDto>> Update(long id, BookUpdateDto book,
        CancellationToken cancellationToken)
    {
        var mappedBook = mapper.Map<Book>(book);
        var updatedBook = await bookService.UpdateAsync(id,
            book: mappedBook,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultBook = mapper.Map<BookResultDto>(updatedBook);

        return Ok(resultBook);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<BookResultDto>> Delete(long id, CancellationToken cancellationToken)
    {
        _ = await bookService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}