using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Address : Auditable
{
    [MaxLength(100)]
    public string GeneratedName { get; set; } = string.Empty;
    
    [MaxLength(30)]
    public string? Street { get; set; }
    
    [MaxLength(10)]
    public string? BuildingNumber { get; set; }
    
    public long CityId { get; set; }
    public City City { get; set; } = null!;
    
    [Precision(18, 2)]
    public decimal? Longitude { get; set; }
    
    [Precision(18, 2)]
    public decimal? Latitude { get; set; }
}