using AutoMapper;
using Librista.Api.Models.DTOs.Books;
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
        throw null;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BookResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResultDto>>> GetAll([FromQuery] BookFilter filter, CancellationToken cancellationToken)
    {
        throw null;   
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BookResultDto>> Update(long id, BookUpdateDto book,
        CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<BookResultDto>> Delete(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
}