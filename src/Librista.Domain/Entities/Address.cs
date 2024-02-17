using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class Address : IAuditable
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
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}