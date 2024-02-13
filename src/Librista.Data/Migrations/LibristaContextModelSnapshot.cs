﻿// <auto-generated />
using System;
using Librista.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Librista.Data.Migrations
{
    [DbContext(typeof(LibristaContext))]
    partial class LibristaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Librista.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuildingNumber")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<long>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GeneratedName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Latitude")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Longitude")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biography")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chapters")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("LeftCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Librista.Domain.Entities.BorrowingRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("BorrowingDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("ReturningDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("TotalFines")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ClientId");

                    b.ToTable("BorrowingRecords");
                });

            modelBuilder.Entity("Librista.Domain.Entities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalFines")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Joinings.AuthorBook", b =>
                {
                    b.Property<long>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks", (string)null);
                });

            modelBuilder.Entity("Librista.Domain.Entities.Publisher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Address", b =>
                {
                    b.HasOne("Librista.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Book", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Librista.Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Librista.Domain.Entities.BorrowingRecord", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Book", "Book")
                        .WithMany("BorrowingRecords")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Librista.Domain.Entities.Client", "Client")
                        .WithMany("BorrowingRecords")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Librista.Domain.Entities.City", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Client", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Joinings.AuthorBook", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Librista.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Publisher", b =>
                {
                    b.HasOne("Librista.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Book", b =>
                {
                    b.Navigation("BorrowingRecords");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Client", b =>
                {
                    b.Navigation("BorrowingRecords");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Librista.Domain.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
