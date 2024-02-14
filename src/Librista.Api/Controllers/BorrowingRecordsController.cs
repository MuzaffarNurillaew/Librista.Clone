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
        var mappedBorrowingRecord = mapper.Map<BorrowingRecord>(borrowingRecord);
        var createdBorrowingRecord = await borrowingRecordService.CreateAsync(mappedBorrowingRecord, cancellationToken);
        var resultBorrowingRecord = mapper.Map<BorrowingRecordResultDto>(createdBorrowingRecord);

        return Ok(resultBorrowingRecord);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BorrowingRecordResultDto>> GetById(long id,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var borrowingRecord = await borrowingRecordService.GetAsync(id,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);
        var mappedBorrowingRecord = mapper.Map<BorrowingRecordResultDto>(borrowingRecord);

        return Ok(mappedBorrowingRecord);
    }

    [HttpGet]
    public async Task<ActionResult<List<BorrowingRecordResultDto>>> GetAll([FromQuery] BorrowingRecordFilter filter,
        CancellationToken cancellationToken,
        bool loadRelations = false)
    {
        var borrowingRecords = await borrowingRecordService.GetAllAsync(filter: filter,
            loadRelations: loadRelations,
            throwException: true,
            track: false,
            cancellationToken: cancellationToken);

        var mappedBorrowingRecords = mapper.Map<IEnumerable<BorrowingRecordResultDto>>(borrowingRecords);

        return Ok(mappedBorrowingRecords);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BorrowingRecordResultDto>> Update(long id, BorrowingRecordUpdateDto borrowingRecord,
        CancellationToken cancellationToken)
    {
        var mappedBorrowingRecord = mapper.Map<BorrowingRecord>(borrowingRecord);
        var updatedBorrowingRecord = await borrowingRecordService.UpdateAsync(id,
            borrowingRecord: mappedBorrowingRecord,
            throwException: true,
            cancellationToken: cancellationToken);
        var resultBorrowingRecord = mapper.Map<BorrowingRecordResultDto>(updatedBorrowingRecord);

        return Ok(resultBorrowingRecord);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id, CancellationToken cancellationToken)
    {
        _ = await borrowingRecordService.DeleteAsync(id,
            throwException: true,
            cancellationToken: cancellationToken);

        return Ok(true);
    }
}