using Librista.Api.Models.DTOs.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(PublisherCreationDto publisher)
    {
        throw null!;
    }
    
    
}