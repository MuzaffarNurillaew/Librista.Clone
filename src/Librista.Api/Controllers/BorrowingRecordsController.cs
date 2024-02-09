using AutoMapper;
using Librista.Api.Models.DTOs.BorrowingRecords;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librista.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingRecordsController(IBorrowingRecordService borrowingRecordService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BorrowingRecordResultDto>> Create(BorrowingRecordCreationDto borrowingRecord,
        CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BorrowingRecordResultDto>> GetById(long id, CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpGet]
    public async Task<ActionResult<List<BorrowingRecordResultDto>>> GetAll([FromQuery] BorrowingRecordFilter filter,
        CancellationToken cancellationToken)
    {
        throw null;
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BorrowingRecordResultDto>> Update(long id, BorrowingRecordUpdateDto borrowingRecord,
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