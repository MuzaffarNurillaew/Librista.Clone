using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IBookService
{
    Task<Book> CreateAsync(Book book,
        CancellationToken cancellationToken = default);
    Task<Book> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<List<Book>> GetAllAsync(BookFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<Book> UpdateAsync(long id,
        Book book,
        bool throwException = true,
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}