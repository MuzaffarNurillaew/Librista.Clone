using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Book : Auditable
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public DateTimeOffset PublicationDate { get; set; }
    public long GenreId { get; set; }
    public Genre Genre { get; set; }
    public int LeftCount { get; set; }
    public List<Author> Authors { get; set; }
    public long PublisherId { get; set; }
    public Publisher Publisher { get; set; }
}