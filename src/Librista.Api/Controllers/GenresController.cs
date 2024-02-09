using AutoMapper;
using Librista.Api.Models.DTOs.Genres;
using Librista.Data.Contexts;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController(IGenreService genreService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GenreResultDto>> Create(GenreCreationDto genre, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GenreResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreResultDto>>> GetAll([FromQuery] GenreFilter filter, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<GenreResultDto>> Update(long id, GenreUpdateDto genre, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
}