﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoncotesLibrary.Migrations
{
    [DbContext(typeof(LoncotesLibraryDbContext))]
    partial class LoncotesLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LoncotesLibrary.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<int>("PatronId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PatronId");

                    b.ToTable("Checkouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDate = new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 3,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CheckoutDate = new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 4,
                            Paid = false,
                            PatronId = 2
                        },
                        new
                        {
                            Id = 3,
                            CheckoutDate = new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 5,
                            Paid = true,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CheckoutDate = new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 6,
                            Paid = true,
                            PatronId = 2
                        },
                        new
                        {
                            Id = 5,
                            CheckoutDate = new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 7,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CheckoutDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 8,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CheckoutDate = new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 9,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CheckoutDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 10,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CheckoutDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 13,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CheckoutDate = new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 15,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            CheckoutDate = new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 2,
                            Paid = false,
                            PatronId = 1,
                            ReturnDate = new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            CheckoutDate = new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 3,
                            Paid = false,
                            PatronId = 1,
                            ReturnDate = new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            CheckoutDate = new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 7,
                            Paid = false,
                            PatronId = 1,
                            ReturnDate = new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            CheckoutDate = new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 12,
                            Paid = false,
                            PatronId = 1
                        },
                        new
                        {
                            Id = 15,
                            CheckoutDate = new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 13,
                            Paid = false,
                            PatronId = 1,
                            ReturnDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            CheckoutDate = new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 15,
                            Paid = false,
                            PatronId = 1,
                            ReturnDate = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            CheckoutDate = new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 2,
                            Paid = false,
                            PatronId = 3,
                            ReturnDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            CheckoutDate = new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 4,
                            Paid = false,
                            PatronId = 3
                        },
                        new
                        {
                            Id = 19,
                            CheckoutDate = new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 12,
                            Paid = false,
                            PatronId = 3
                        },
                        new
                        {
                            Id = 20,
                            CheckoutDate = new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 1,
                            Paid = false,
                            PatronId = 4,
                            ReturnDate = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 21,
                            CheckoutDate = new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 3,
                            Paid = false,
                            PatronId = 4
                        },
                        new
                        {
                            Id = 22,
                            CheckoutDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 5,
                            Paid = false,
                            PatronId = 4
                        },
                        new
                        {
                            Id = 23,
                            CheckoutDate = new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 1,
                            Paid = false,
                            PatronId = 5
                        },
                        new
                        {
                            Id = 24,
                            CheckoutDate = new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 2,
                            Paid = false,
                            PatronId = 5
                        },
                        new
                        {
                            Id = 25,
                            CheckoutDate = new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 11,
                            Paid = false,
                            PatronId = 5
                        },
                        new
                        {
                            Id = 26,
                            CheckoutDate = new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 12,
                            Paid = false,
                            PatronId = 5
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "History"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OutOfCirculationSince")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            MaterialName = "Hems and Gems",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 3,
                            MaterialName = "Fighter Spiders",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 3,
                            MaterialName = "Hairy Clefairy",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 1,
                            MaterialName = "Book of Madness",
                            MaterialTypeId = 2,
                            OutOfCirculationSince = new DateTime(1995, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 2,
                            MaterialName = "Age of Faith",
                            MaterialTypeId = 2,
                            OutOfCirculationSince = new DateTime(1950, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 3,
                            MaterialName = "Romeo and or Juliet",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 4,
                            MaterialName = "Hyperion Cantos",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 5,
                            MaterialName = "Giddeon the 9th",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 1,
                            MaterialName = "Dead Witch Walking",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 4,
                            MaterialName = "Fall of Hyperion",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 11,
                            GenreId = 1,
                            MaterialName = "Inuyasha",
                            MaterialTypeId = 3,
                            OutOfCirculationSince = new DateTime(2012, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            GenreId = 3,
                            MaterialName = "Saiki K",
                            MaterialTypeId = 3
                        },
                        new
                        {
                            Id = 13,
                            GenreId = 1,
                            MaterialName = "Lord of the Rings",
                            MaterialTypeId = 4
                        },
                        new
                        {
                            Id = 14,
                            GenreId = 2,
                            MaterialName = "Song of the South",
                            MaterialTypeId = 4,
                            OutOfCirculationSince = new DateTime(1192, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            GenreId = 3,
                            MaterialName = "Hot Fuzz",
                            MaterialTypeId = 4
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckoutDays")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDays = 14,
                            Name = "Children's Book"
                        },
                        new
                        {
                            Id = 2,
                            CheckoutDays = 21,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 3,
                            CheckoutDays = 7,
                            Name = "Manga"
                        },
                        new
                        {
                            Id = 4,
                            CheckoutDays = 4,
                            Name = "Movie"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patrons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "42 Whatnot Way",
                            Email = "ztrouy@example.com",
                            FirstName = "Zachary",
                            IsActive = true,
                            LastName = "Trouy"
                        },
                        new
                        {
                            Id = 2,
                            Address = "69 Baser Boulevard",
                            Email = "zhop@example.com",
                            FirstName = "Zavier",
                            IsActive = true,
                            LastName = "Hopson"
                        },
                        new
                        {
                            Id = 3,
                            Address = "32 Cellular Court",
                            Email = "ccote@example.com",
                            FirstName = "Chad",
                            IsActive = true,
                            LastName = "Cote"
                        },
                        new
                        {
                            Id = 4,
                            Address = "27 Dullard Drive",
                            Email = "ebrewer@example.com",
                            FirstName = "Ezra",
                            IsActive = true,
                            LastName = "Brewer"
                        },
                        new
                        {
                            Id = 5,
                            Address = "83 Light Lane",
                            Email = "lbresson@example.com",
                            FirstName = "Lucas",
                            IsActive = true,
                            LastName = "Bresson"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Checkout", b =>
                {
                    b.HasOne("LoncotesLibrary.Models.Material", "Material")
                        .WithMany("Checkouts")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoncotesLibrary.Models.Patron", "Patron")
                        .WithMany("Checkouts")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Patron");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.HasOne("LoncotesLibrary.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoncotesLibrary.Models.MaterialType", "MaterialType")
                        .WithMany()
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.Navigation("Checkouts");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Patron", b =>
                {
                    b.Navigation("Checkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
