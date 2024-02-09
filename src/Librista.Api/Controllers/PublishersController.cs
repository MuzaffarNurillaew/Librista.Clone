using AutoMapper;
using Librista.Api.Models.DTOs.Publishers;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController(IPublisherService publisherService, IMapper mapper) : ControllerBase
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
    public async Task<ActionResult<List<PublisherResultDto>>> GetAll([FromQuery] PublisherFilter filter, CancellationToken cancellationToken)
    {
        throw null!;
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<PublisherResultDto>> Update(long id, PublisherUpdateDto publisher, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
}
