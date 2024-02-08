using Librista.Domain.Entities;
using Librista.Domain.Entities.Joinings;
using Microsoft.EntityFrameworkCore;

namespace Librista.Data.Contexts;

public class LibristaContext(DbContextOptions<LibristaContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BorrowingRecord> BorrowingRecords => Set<BorrowingRecord>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Publisher> Publishers => Set<Publisher>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Librista");

        builder.Entity<Author>()
            .HasMany(author => author.Books)
            .WithMany(book => book.Authors)
            .UsingEntity<AuthorBook>();
    }
}