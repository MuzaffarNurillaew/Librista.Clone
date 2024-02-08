using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class City : Auditable
{
    [MaxLength(20)]
    public required string Name { get; set; }
    
    public long CountryId { get; set; }
    public Country Country { get; set; } = null!;
}