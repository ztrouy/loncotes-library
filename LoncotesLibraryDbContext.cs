using Microsoft.EntityFrameworkCore;
using LoncotesLibrary.Models;

public class LoncotesLibraryDbContext : DbContext
{
    public DbSet<Checkout> Checkouts {get; set;}
    public DbSet<Genre> Genres {get; set;}
    public DbSet<Material> Materials {get; set;}
    public DbSet<MaterialType> MaterialTypes {get; set;}
    public DbSet<Patron> Patrons {get; set;}

    public LoncotesLibraryDbContext(DbContextOptions<LoncotesLibraryDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>().HasData(new MaterialType[]
        {
            new MaterialType {Id = 1, Name = "Children's Book", CheckoutDays = 14},
            new MaterialType {Id = 2, Name = "Book", CheckoutDays = 21},
            new MaterialType {Id = 3, Name = "Manga", CheckoutDays = 7},
            new MaterialType {Id = 4, Name = "Movie", CheckoutDays = 4}
        });
        
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre {Id = 1, Name = "Fantasy"},
            new Genre {Id = 2, Name = "History"},
            new Genre {Id = 3, Name = "Comedy"},
            new Genre {Id = 4, Name = "Sci-Fi"},
            new Genre {Id = 5, Name = "Romance"}
        });

        modelBuilder.Entity<Material>().HasData(new Material[]
        {
            new Material {Id = 1, MaterialName = "Hems and Gems", MaterialTypeId = 1, GenreId = 1, OutOfCirculationSince = null},
            new Material {Id = 2, MaterialName = "Fighter Spiders", MaterialTypeId = 1, GenreId = 3, OutOfCirculationSince = null},
            new Material {Id = 3, MaterialName = "Hairy Clefairy", MaterialTypeId = 1, GenreId = 3, OutOfCirculationSince = null},
            new Material {Id = 4, MaterialName = "Book of Madness", MaterialTypeId = 2, GenreId = 1, OutOfCirculationSince = new DateTime(1995, 8, 14)},
            new Material {Id = 5, MaterialName = "Age of Faith", MaterialTypeId = 2, GenreId = 2, OutOfCirculationSince = new DateTime(1950, 09, 12)},
            new Material {Id = 6, MaterialName = "Romeo and or Juliet", MaterialTypeId = 2, GenreId = 3, OutOfCirculationSince = null},
            new Material {Id = 7, MaterialName = "Hyperion Cantos", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = null},
            new Material {Id = 8, MaterialName = "Giddeon the 9th", MaterialTypeId = 2, GenreId = 5, OutOfCirculationSince = null},
            new Material {Id = 9, MaterialName = "Dead Witch Walking", MaterialTypeId = 2, GenreId = 1, OutOfCirculationSince = null},
            new Material {Id = 10, MaterialName = "Fall of Hyperion", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = null},
            new Material {Id = 11, MaterialName = "Inuyasha", MaterialTypeId = 3, GenreId = 1, OutOfCirculationSince = new DateTime(2012, 07, 14)},
            new Material {Id = 12, MaterialName = "Saiki K", MaterialTypeId = 3, GenreId = 3, OutOfCirculationSince = null},
            new Material {Id = 13, MaterialName = "Lord of the Rings", MaterialTypeId = 4, GenreId = 1, OutOfCirculationSince = null},
            new Material {Id = 14, MaterialName = "Song of the South", MaterialTypeId = 4, GenreId = 2, OutOfCirculationSince = new DateTime(1192, 6, 11)},
            new Material {Id = 15, MaterialName = "Hot Fuzz", MaterialTypeId = 4, GenreId = 3, OutOfCirculationSince = null}
        });

        modelBuilder.Entity<Patron>().HasData(new Patron[]
        {
            new Patron {Id = 1, FirstName = "Zachary", LastName = "Trouy", Address = "42 Whatnot Way", Email = "ztrouy@example.com", IsActive = true},
            new Patron {Id = 2, FirstName = "Zavier", LastName = "Hopson", Address = "69 Baser Boulevard", Email = "zhop@example.com", IsActive = true},
            new Patron {Id = 3, FirstName = "Chad", LastName = "Cote", Address = "32 Cellular Court", Email = "ccote@example.com", IsActive = true},
            new Patron {Id = 4, FirstName = "Ezra", LastName = "Brewer", Address = "27 Dullard Drive", Email = "ebrewer@example.com", IsActive = true},
            new Patron {Id = 5, FirstName = "Lucas", LastName = "Bresson", Address = "83 Light Lane", Email = "lbresson@example.com", IsActive = true}
        });

        modelBuilder.Entity<Checkout>().HasData(new Checkout[]
        {
            new Checkout {Id = 1, MaterialId = 3, PatronId = 2, CheckoutDate = new DateTime(2024, 01, 09), ReturnDate = new DateTime(2024, 01, 16), Paid = false},
            new Checkout {Id = 2, MaterialId = 4, PatronId = 2, CheckoutDate = new DateTime(2024, 01, 22), ReturnDate = null, Paid = false},
            new Checkout {Id = 3, MaterialId = 5, PatronId = 2, CheckoutDate = new DateTime(2024, 01, 23), ReturnDate = new DateTime(2024, 02, 15), Paid = true},
            new Checkout {Id = 4, MaterialId = 6, PatronId = 2, CheckoutDate = new DateTime(2024, 01, 26), ReturnDate = null, Paid = false},
            new Checkout {Id = 5, MaterialId = 7, PatronId = 2, CheckoutDate = new DateTime(2024, 02, 02), ReturnDate = new DateTime(2024, 02, 15), Paid = false},
            new Checkout {Id = 6, MaterialId = 8, PatronId = 2, CheckoutDate = new DateTime(2024, 02, 15), ReturnDate = new DateTime(2024, 02, 23), Paid = false},
            new Checkout {Id = 7, MaterialId = 9, PatronId = 2, CheckoutDate = new DateTime(2024, 02, 16), ReturnDate = new DateTime(2024, 02, 23), Paid = false},
            new Checkout {Id = 8, MaterialId = 10, PatronId = 2, CheckoutDate = new DateTime(2024, 02, 23), ReturnDate = new DateTime(2024, 03, 04), Paid = false},
            new Checkout {Id = 9, MaterialId = 13, PatronId = 2, CheckoutDate = new DateTime(2024, 03, 05), ReturnDate = new DateTime(2024, 03, 07), Paid = false},
            new Checkout {Id = 10, MaterialId = 15, PatronId = 2, CheckoutDate = new DateTime(2024, 03, 13), ReturnDate = new DateTime(2024, 03, 18), Paid = false},
            new Checkout {Id = 11, MaterialId = 2, PatronId = 1, CheckoutDate = new DateTime(2024, 01, 23), ReturnDate = new DateTime(2024, 02, 09), Paid = false},
            new Checkout {Id = 12, MaterialId = 3, PatronId = 1, CheckoutDate = new DateTime(2024, 01, 26), ReturnDate = new DateTime(2024, 02, 09), Paid = false},
            new Checkout {Id = 13, MaterialId = 7, PatronId = 1, CheckoutDate = new DateTime(2024, 02, 16), ReturnDate = new DateTime(2024, 03, 13), Paid = false},
            new Checkout {Id = 14, MaterialId = 12, PatronId = 1, CheckoutDate = new DateTime(2024, 02, 17), ReturnDate = null, Paid = false},
            new Checkout {Id = 15, MaterialId = 13, PatronId = 1, CheckoutDate = new DateTime(2024, 03, 13), ReturnDate = new DateTime(2024, 03, 15), Paid = false},
            new Checkout {Id = 16, MaterialId = 15, PatronId = 1, CheckoutDate = new DateTime(2024, 03, 29), ReturnDate = new DateTime(2024, 04, 01), Paid = false},
            new Checkout {Id = 17, MaterialId = 2, PatronId = 3, CheckoutDate = new DateTime(2024, 02, 25), ReturnDate = new DateTime(2024, 03, 15), Paid = false},
            new Checkout {Id = 18, MaterialId = 4, PatronId = 3, CheckoutDate = new DateTime(2024, 03, 28), ReturnDate = null, Paid = false},
            new Checkout {Id = 19, MaterialId = 12, PatronId = 3, CheckoutDate = new DateTime(2024, 04, 28), ReturnDate = null, Paid = false},
            new Checkout {Id = 20, MaterialId = 1, PatronId = 4, CheckoutDate = new DateTime(2024, 01, 23), ReturnDate = new DateTime(2024, 02, 04), Paid = false},
            new Checkout {Id = 21, MaterialId = 3, PatronId = 4, CheckoutDate = new DateTime(2024, 02, 02), ReturnDate = null, Paid = false},
            new Checkout {Id = 22, MaterialId = 5, PatronId = 4, CheckoutDate = new DateTime(2024, 02, 05), ReturnDate = null, Paid = false},
            new Checkout {Id = 23, MaterialId = 1, PatronId = 5, CheckoutDate = new DateTime(2024, 04, 19), ReturnDate = null, Paid = false},
            new Checkout {Id = 24, MaterialId = 2, PatronId = 5, CheckoutDate = new DateTime(2024, 04, 19), ReturnDate = null, Paid = false},
            new Checkout {Id = 25, MaterialId = 11, PatronId = 5, CheckoutDate = new DateTime(2024, 04, 22), ReturnDate = null, Paid = false},
            new Checkout {Id = 26, MaterialId = 12, PatronId = 5, CheckoutDate = new DateTime(2024, 04, 22), ReturnDate = null, Paid = false}
        });
    }
}