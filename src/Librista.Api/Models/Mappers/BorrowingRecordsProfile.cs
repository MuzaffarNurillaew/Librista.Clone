using AutoMapper;
using Librista.Api.Models.DTOs.BorrowingRecords;
using Librista.Domain.Entities;

namespace Librista.Api.Models.Mappers;

public class BorrowingRecordsProfile : Profile
{
    public BorrowingRecordsProfile()
    {
        CreateMap<BorrowingRecordCreationDto, BorrowingRecord>();
        CreateMap<BorrowingRecord, BorrowingRecordResultDto>();
        CreateMap<BorrowingRecordUpdateDto, BorrowingRecord>();
    }
}