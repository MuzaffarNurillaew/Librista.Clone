using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class Author : IAuditable
{
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(500)]
    public string? Biography { get; set; }

    public List<Book> Books { get; set; }
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}