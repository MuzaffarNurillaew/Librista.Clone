using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Genre : Auditable
{
    [MaxLength(20)]
    public required string Name { get; set; }
    public List<Book> Books { get; set; } = [];
}