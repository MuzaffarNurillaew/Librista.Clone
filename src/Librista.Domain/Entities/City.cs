using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class City : IAuditable
{
    [MaxLength(20)]
    public required string Name { get; set; }
    
    public long CountryId { get; set; }
    public Country Country { get; set; } = null!;
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}