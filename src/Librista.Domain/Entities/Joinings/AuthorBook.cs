using Librista.Domain.Commons;

namespace Librista.Domain.Entities.Joinings;

public class AuthorBook : Auditable
{
    public long AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public long BookId { get; set; }
    public Book Book { get; set; } = null!;
}