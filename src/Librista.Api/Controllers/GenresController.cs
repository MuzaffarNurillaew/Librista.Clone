using Librista.Data.Contexts;
using Librista.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly LibristaContext _context;

    public GenresController(LibristaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        var genre = new Genre()
        {
            Name = "Fiction"
        };
        var result = await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
        return Ok(result.Entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(long id)
    {
        var result = await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);

        return Ok(result);
    }
}