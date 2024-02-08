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

        builder.Entity<Address>()
            .HasOne(address => address.City)
            .WithMany()
            .HasForeignKey(address => address.CityId);
        
        builder.Entity<Author>()
            .HasMany(author => author.Books)
            .WithMany(book => book.Authors)
            .UsingEntity<AuthorBook>();

        builder.Entity<Book>(entity =>
        {
            entity
                .HasOne(book => book.Genre)
                .WithMany(genre => genre.Books)
                .HasForeignKey(book => book.GenreId);

            entity
                .HasOne(book => book.Publisher)
                .WithMany(publisher => publisher.Books)
                .HasForeignKey(book => book.PublisherId);
        });
        builder.Entity<BorrowingRecord>(entity =>
        {
            entity
                .HasOne(record => record.Book)
                .WithMany(book => book.BorrowingRecords)
                .HasForeignKey(record => record.BookId);

            entity
                .HasOne(record => record.Client)
                .WithMany(client => client.BorrowingRecords)
                .HasForeignKey(record => record.ClientId);
        });

        builder.Entity<City>()
            .HasOne(city => city.Country)
            .WithMany(country => country.Cities)
            .HasForeignKey(city => city.CountryId);

        builder.Entity<Client>()
            .HasOne(client => client.Address)
            .WithMany()
            .HasForeignKey(client => client.AddressId);
    }
}