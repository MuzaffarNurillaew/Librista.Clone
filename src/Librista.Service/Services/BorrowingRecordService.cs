using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class BorrowingRecordService(IRepository repository, BorrowingRecordValidator borrowingRecordValidator) : IBorrowingRecordService
{
    public async Task<BorrowingRecord> CreateAsync(BorrowingRecord borrowingRecord, CancellationToken cancellationToken = default)
    {
        await borrowingRecordValidator.ValidateOrPanicAsync(borrowingRecord);
        var createdBorrowingRecord = await repository.InsertAsync(borrowingRecord, cancellationToken: cancellationToken);

        return createdBorrowingRecord;
    }

    public async Task<BorrowingRecord> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(BorrowingRecord.Book), nameof(BorrowingRecord.Client) } : null;
        var borrowingRecord = await repository.SelectAsync<BorrowingRecord>(borrowingRecord => borrowingRecord.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return borrowingRecord;
    }

    public async Task<List<BorrowingRecord>> GetAllAsync(BorrowingRecordFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(BorrowingRecord.Book), nameof(BorrowingRecord.Client) } : null;
        var borrowingRecordsQuery = repository.SelectAll<BorrowingRecord>(genre => true,
            includes: includes);
        
        #region Filtering

        if (filter.Search is not null)
        {
            borrowingRecordsQuery = borrowingRecordsQuery.Where(borrowingRecord =>
                borrowingRecord.Book.Title.ToLower()
                    .Contains(filter.Search.ToLower()));
        }
        borrowingRecordsQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            borrowingRecordsQuery = borrowingRecordsQuery.AsNoTracking();
        }
        return await borrowingRecordsQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<BorrowingRecord> UpdateAsync(long id,
        BorrowingRecord borrowingRecord,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await borrowingRecordValidator.ValidateOrPanicAsync(borrowingRecord);
        var updatedGenre = await repository.UpdateAsync<BorrowingRecord>(pub => pub.Id == id,
            entity: borrowingRecord,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<BorrowingRecord>(borrowingRecord => borrowingRecord.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }
}