using AutoMapper;
using Librista.Api.Models.DTOs.Publishers;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Librista.Service.Validators.Utilities;
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
        var mappedPublisher = mapper.Map<Publisher>(publisher);
        var createdPublisher = await publisherService.CreateAsync(mappedPublisher, cancellationToken);
        var resultPublisher = mapper.Map<PublisherResultDto>(createdPublisher);

        return Ok(resultPublisher);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<PublisherResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var publisher = await publisherService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);
        var mappedPublisher = mapper.Map<PublisherResultDto>(publisher);

        return Ok(mappedPublisher);
    }

    [HttpGet]
    public async Task<ActionResult<List<PublisherResultDto>>> GetAll([FromQuery] PublisherFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var publishers = await publisherService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedPublishers = mapper.Map<IEnumerable<PublisherResultDto>>(publishers);

        return Ok(mappedPublishers);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<PublisherResultDto>> Update(long id,
        PublisherUpdateDto publisher,
        CancellationToken cancellationToken)
    {
        var mappedPublisher = mapper.Map<Publisher>(publisher);
        var updatedPublisher = await publisherService.UpdateAsync(id,
            publisher: mappedPublisher,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultPublisher = mapper.Map<PublisherResultDto>(updatedPublisher);

        return Ok(resultPublisher);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        _ = await publisherService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}