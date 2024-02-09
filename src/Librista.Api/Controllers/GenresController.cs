using Librista.Data.Contexts;
using Librista.Domain.Entities;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController(LibristaContext context, IGenreService genreService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        var genre = new Genre()
        {
            Name = "Fiction"
        };
        var result = await context.Genres.AddAsync(genre);
        await context.SaveChangesAsync();
        return Ok(result.Entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(long id)
    {
        var result = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);

        return Ok(result);
    }
}