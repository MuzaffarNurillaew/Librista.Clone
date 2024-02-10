using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class PublisherService(IRepository repository, PublisherValidator publisherValidator) : IPublisherService
{
    public async Task<Publisher> CreateAsync(Publisher publisher, CancellationToken cancellationToken = default)
    {
        await publisherValidator.ValidateOrPanicAsync(publisher);
        var createdPublisher = await repository.InsertAsync(publisher, cancellationToken: cancellationToken);

        return createdPublisher;
    }

    public async Task<Publisher> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Publisher.Address), nameof(Publisher.Books) } : null;
        var publisher = await repository.SelectAsync<Publisher>(publisher => publisher.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return publisher;
    }

    public async Task<List<Publisher>> GetAllAsync(PublisherFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Publisher.Address), nameof(Publisher.Books) } : null;
        var publishersQuery = repository.SelectAll<Publisher>(genre => true,
            includes: includes);
        
        #region Filtering

        if (filter.Search is not null)
        {
            publishersQuery = publishersQuery.Where(publisher =>
                publisher.Name.ToLower()
                    .Contains(filter.Search.ToLower()));
        }
        publishersQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            publishersQuery = publishersQuery.AsNoTracking();
        }
        return await publishersQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Publisher> UpdateAsync(long id,
        Publisher publisher,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await publisherValidator.ValidateOrPanicAsync(publisher);
        var updatedGenre = await repository.UpdateAsync<Publisher>(pub => pub.Id == id,
            entity: publisher,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id, bool throwException = true, CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<Publisher>(publisher => publisher.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }
}