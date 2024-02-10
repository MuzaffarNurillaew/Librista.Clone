using AutoMapper;
using Librista.Api.Models.DTOs.Clients;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientService clientService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ClientResultDto>> Create(ClientCreationDto client,
        CancellationToken cancellationToken)
    {
        var mappedClient = mapper.Map<Client>(client);
        var createdClient = await clientService.CreateAsync(mappedClient, cancellationToken);
        var resultClient = mapper.Map<ClientResultDto>(createdClient);

        return Ok(resultClient);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ClientResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var client = await clientService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);
        var mappedClient = mapper.Map<ClientResultDto>(client);

        return Ok(mappedClient);
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientResultDto>>> GetAll([FromQuery] ClientFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var clients = await clientService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedClients = mapper.Map<IEnumerable<ClientResultDto>>(clients);

        return Ok(mappedClients);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<ClientResultDto>> Update(long id, ClientUpdateDto client,
        CancellationToken cancellationToken)
    {
        var mappedClient = mapper.Map<Client>(client);
        var updatedClient = await clientService.UpdateAsync(id,
            client: mappedClient,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultClient = mapper.Map<ClientResultDto>(updatedClient);

        return Ok(resultClient);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        _ = await clientService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}