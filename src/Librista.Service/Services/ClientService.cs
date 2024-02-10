using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class ClientService(IRepository repository, ClientValidator clientValidator) : IClientService
{
    public async Task<Client> CreateAsync(Client client, CancellationToken cancellationToken = default)
    {
        await clientValidator.ValidateOrPanicAsync(client);
        var createdClient = await repository.InsertAsync(client, cancellationToken: cancellationToken);

        return createdClient;
    }

    public async Task<Client> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Client.Address), nameof(Client.BorrowingRecords) } : null;
        var client = await repository.SelectAsync<Client>(client => client.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return client;
    }

    public async Task<List<Client>> GetAllAsync(ClientFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Client.Address), nameof(Client.BorrowingRecords) } : null;
        var clientsQuery = repository.SelectAll<Client>(genre => true,
            includes: includes);
        
        #region Filtering

        if (filter.Search is not null)
        {
            var search = filter.Search.ToLower();
            clientsQuery = clientsQuery.Where(client =>
                client.FirstName.ToLower().Contains(search) ||
                client.LastName.ToLower().Contains(search));
        }
        clientsQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            clientsQuery = clientsQuery.AsNoTracking();
        }
        return await clientsQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Client> UpdateAsync(long id,
        Client client,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await clientValidator.ValidateOrPanicAsync(client);
        var updatedGenre = await repository.UpdateAsync<Client>(pub => pub.Id == id,
            entity: client,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<Client>(client => client.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }   
}