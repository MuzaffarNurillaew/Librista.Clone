using AutoMapper;
using Librista.Api.Models.DTOs.Addresses;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Librista.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressesController(IAddressService addressService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AddressResultDto>> Create(AddressCreationDto address, CancellationToken cancellationToken)
    {
        var addressToCreate = mapper.Map<Address>(address);
        var createdAddress = await addressService.CreateAsync(addressToCreate, cancellationToken: cancellationToken);
        var addressToReturn = mapper.Map<AddressResultDto>(createdAddress);

        return Ok(addressToReturn);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AddressResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        var address = await addressService.GetAsync(id, cancellationToken: cancellationToken);

        return Ok(mapper.Map<AddressResultDto>(address));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressResultDto>>> GetAll(AddressFilter filter, CancellationToken cancellationToken)
    {
        var addresses = await addressService.GetAllAsync(filter, cancellationToken);

        return Ok(mapper.Map<IEnumerable<AddressResultDto>>(addresses));
    }
}