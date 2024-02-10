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
        var mappedGenre = mapper.Map<Genre>(genre);
        var createdGenre = await genreService.CreateAsync(mappedGenre,
            cancellationToken: cancellationToken);
        var resultGenre = mapper.Map<GenreResultDto>(createdGenre);

        return Ok(resultGenre);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GenreResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var genre = await genreService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(genre);
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreResultDto>>> GetAll([FromQuery] GenreFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var genres = await genreService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedGenres = mapper.Map<IEnumerable<GenreResultDto>>(genres);
        return Ok(mappedGenres);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<GenreResultDto>> Update(long id,
        GenreUpdateDto genre,
        CancellationToken cancellationToken)
    {
        var mappedGenre = mapper.Map<Genre>(genre);
        var updatedGenre = await genreService.UpdateAsync(id,
            genre: mappedGenre,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultGenre = mapper.Map<GenreResultDto>(updatedGenre);

        return Ok(resultGenre);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        _ = await genreService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}