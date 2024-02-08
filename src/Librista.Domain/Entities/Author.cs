using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Author : Auditable
{
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(500)]
    public string? Biography { get; set; }

    public List<Book> Books { get; set; } = [];
}