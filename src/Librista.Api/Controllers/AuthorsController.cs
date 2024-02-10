using AutoMapper;
using Librista.Api.Models.DTOs.Authors;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService authorService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AuthorResultDto>> Create(AuthorCreationDto author,
        CancellationToken cancellationToken)
    {
        var mappedAuthor = mapper.Map<Author>(author);
        var createdAuthor = await authorService.CreateAsync(mappedAuthor, cancellationToken);
        var resultAuthor = mapper.Map<AuthorResultDto>(createdAuthor);

        return Ok(resultAuthor);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AuthorResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var author = await authorService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);
        var mappedAuthor = mapper.Map<AuthorResultDto>(author);

        return Ok(mappedAuthor);
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResultDto>>> GetAll([FromQuery] AuthorFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var authors = await authorService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedAuthors = mapper.Map<IEnumerable<AuthorResultDto>>(authors);

        return Ok(mappedAuthors);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<AuthorResultDto>> Update(long id,
        AuthorUpdateDto author,
        CancellationToken cancellationToken)
    {
        var mappedAuthor = mapper.Map<Author>(author);
        var updatedAuthor = await authorService.UpdateAsync(id,
            author: mappedAuthor,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultAuthor = mapper.Map<AuthorResultDto>(updatedAuthor);

        return Ok(resultAuthor);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id,
        CancellationToken cancellationToken)
    {
        _ = await authorService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}