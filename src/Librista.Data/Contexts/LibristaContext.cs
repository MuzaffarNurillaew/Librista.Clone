using Librista.Domain.Entities;
using Librista.Domain.Entities.Joinings;
using Microsoft.EntityFrameworkCore;

namespace Librista.Data.Contexts;

public class LibristaContext(DbContextOptions<LibristaContext> options) : DbContext(options)
{
    #region Tables
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BorrowingRecord> BorrowingRecords => Set<BorrowingRecord>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Global query filters 
        builder.Entity<Address>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<Author>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<Book>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<BorrowingRecord>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<City>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<Country>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<Genre>().HasQueryFilter(address => !address.IsDeleted);
        builder.Entity<Publisher>().HasQueryFilter(address => !address.IsDeleted);
        #endregion

        #region Fluent API
        builder.Entity<Address>(entity =>
        {
            entity
                .HasOne(address => address.City)
                .WithMany()
                .HasForeignKey(address => address.CityId);
        });
        
        builder.Entity<Author>()
            .HasMany(author => author.Books)
            .WithMany(book => book.Authors)
            .UsingEntity<AuthorBook>(entity =>
            {
                entity
                    .HasOne(ab => ab.Author)
                    .WithMany()
                    .HasForeignKey(ab => ab.AuthorId);
                entity
                    .HasOne(ab => ab.Book)
                    .WithMany()
                    .HasForeignKey(ab => ab.BookId);
            });

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

            entity
                .HasIndex(book => book.Isbn)
                .IsUnique();
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

        builder.Entity<Genre>()
            .HasKey(genre => genre.Id);

        builder.Entity<AuthorBook>()
            .HasKey(ab => ab.Id);

        #endregion
    }
}
