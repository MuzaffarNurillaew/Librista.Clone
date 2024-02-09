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
        throw null!;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AuthorResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null!;   
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResultDto>>> GetAll(AuthorFilter filter,
        CancellationToken cancellationToken)
    {
        throw null!;
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<AuthorResultDto>> Update(long id, AuthorUpdateDto author,
        CancellationToken cancellationToken)
    {
        throw null!;   
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        throw null!;
    }
}