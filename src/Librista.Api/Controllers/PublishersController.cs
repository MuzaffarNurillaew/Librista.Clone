using Librista.Api.Models.DTOs.Publishers;
using Librista.Service.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PublisherResultDto>> Create(PublisherCreationDto publisher,
        CancellationToken cancellationToken)
    {
        throw null!;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<PublisherResultDto>> GetById(long id,
        CancellationToken cancellationToken)
    {
        throw null!;
    }

    [HttpGet]
    public async Task<ActionResult<List<PublisherResultDto>>> GetAll(PublisherFilter filter)
    {
        
    }
}