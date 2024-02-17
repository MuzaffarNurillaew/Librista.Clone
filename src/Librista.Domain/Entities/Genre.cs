using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class Genre : IAuditable
{
    [MaxLength(20)]
    public required string Name { get; set; }
    public List<Book> Books { get; set; } = [];
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}