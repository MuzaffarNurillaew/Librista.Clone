using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IBorrowingRecordService
{
    Task<BorrowingRecord> CreateAsync(BorrowingRecord borrowingRecord,
        CancellationToken cancellationToken = default);
    Task<BorrowingRecord> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<List<BorrowingRecord>> GetAllAsync(BorrowingRecordFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<BorrowingRecord> UpdateAsync(long id,
        BorrowingRecord borrowingRecord,
        bool throwException = true,
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}