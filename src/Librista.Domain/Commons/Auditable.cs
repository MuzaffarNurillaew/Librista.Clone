using System.ComponentModel.DataAnnotations;

namespace Librista.Domain.Commons;

public abstract class Auditable
{
    /// <summary>
    /// Gets or sets the id of the entity
    /// </summary>
    [Key]
    public long Id { get; set; } = default;

    /// <summary>
    /// Gets or sets the created date of the entity
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    /// <summary>
    /// Gets or sets the updated date of the entity
    /// </summary>
    public DateTimeOffset? UpdatedDate { get; set; }
    /// <summary>
    /// Gets or sets the deleted date of the entity
    /// </summary>
    public DateTimeOffset? DeletedDate { get; set; }
    /// <summary>
    /// Represents whether the entity is deleted or not
    /// </summary>
    public bool IsDeleted { get; set; }
}