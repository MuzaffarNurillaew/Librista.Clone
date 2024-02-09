using AutoMapper;
using Librista.Api.Models.DTOs.Clients;
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
        throw null;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ClientResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientResultDto>>> GetAll([FromQuery] ClientFilter filter,
        CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<ClientResultDto>> Update(long id, ClientUpdateDto client,
        CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        throw null;
    }
}