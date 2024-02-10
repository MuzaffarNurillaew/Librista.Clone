using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Book : Auditable
{
    [Unicode(false)]
    [MaxLength(20)]
    public required string Isbn { get; set; }
    
    [MaxLength(80)]
    public required string Title { get; set; }
    
    [MaxLength(500)]
    public string? Summary { get; set; }
    
    [MaxLength(500)]
    public string? Chapters { get; set; }
    
    public DateTimeOffset PublicationDate { get; set; }
    public int LeftCount { get; set; }
    
    public long GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
    
    public long PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
    
    public List<Author> Authors { get; set; } = [];
    public List<BorrowingRecord> BorrowingRecords { get; set; } = [];
}