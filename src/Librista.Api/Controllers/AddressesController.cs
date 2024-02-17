using AutoMapper;
using Librista.Api.Models.DTOs.Addresses;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Librista.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressesController(IAddressService addressService, ICountryService countryService, IMapper mapper) : ControllerBase
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
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressResultDto>>> GetAll([FromQuery] AddressFilter filter, CancellationToken cancellationToken)
    {
        var addresses = await addressService.GetAllAsync(filter, cancellationToken: cancellationToken);

        return Ok(mapper.Map<IEnumerable<AddressResultDto>>(addresses));
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<AddressResultDto>> Update(long id, AddressUpdateDto address, CancellationToken cancellationToken)
    {
        var mappedAddress = mapper.Map<Address>(address);
        var updatedAddress = await addressService.UpdateAsync(id, mappedAddress, cancellationToken: cancellationToken);

        return Ok(mapper.Map<AddressResultDto>(updatedAddress));
    }
    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        var isDeleted = await addressService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(mapper.Map<AddressResultDto>(isDeleted));
    }
}