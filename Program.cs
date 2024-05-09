using LoncotesLibrary.Models;
using LoncotesLibrary.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoncotesLibraryDbContext>(builder.Configuration["LoncotesLibraryDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var CreateMaterialDTO = (Material m) =>
{
    MaterialDTO materialDTO = new MaterialDTO()
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        GenreId = m.GenreId,
        OutOfCirculationSince = m.OutOfCirculationSince,
        MaterialType = new MaterialTypeDTO()
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        Genre = new GenreDTO()
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        }
    };

    return materialDTO;
};

var CreateCheckoutDTO = (Checkout c) =>
{
    CheckoutDTO checkoutDTO = new CheckoutDTO()
    {
        Id = c.Id,
        MaterialId = c.MaterialId,
        PatronId = c.PatronId,
        CheckoutDate = c.CheckoutDate,
        ReturnDate = c.ReturnDate,
        Paid = c.Paid,
        Patron = new PatronDTO()
        {
            Id = c.Patron.Id,
            FirstName = c.Patron.FirstName,
            LastName = c.Patron.LastName,
            Address = c.Patron.Address,
            Email = c.Patron.Email,
            IsActive = c.Patron.IsActive
        }
    };

    return checkoutDTO;
};

var CreateDetailedCheckoutDTO = (Checkout c) =>
{
    CheckoutLateFeeDTO checkoutDTO = new CheckoutLateFeeDTO()
    {
        Id = c.Id,
        MaterialId = c.MaterialId,
        PatronId = c.PatronId,
        CheckoutDate = c.CheckoutDate,
        ReturnDate = c.ReturnDate,
        Paid = c.Paid,
        Patron = new PatronDTO()
        {
            Id = c.Patron.Id,
            FirstName = c.Patron.FirstName,
            LastName = c.Patron.LastName,
            Address = c.Patron.Address,
            Email = c.Patron.Email,
            IsActive = c.Patron.IsActive
        },
        Material = new MaterialDTO()
        {
            Id = c.Material.Id,
            MaterialName = c.Material.MaterialName,
            MaterialTypeId = c.Material.MaterialTypeId,
            GenreId = c.Material.GenreId,
            OutOfCirculationSince = c.Material.OutOfCirculationSince,
            MaterialType = new MaterialTypeDTO()
            {
                Id = c.Material.MaterialType.Id,
                Name = c.Material.MaterialType.Name,
                CheckoutDays = c.Material.MaterialType.CheckoutDays
            },
            Genre = new GenreDTO()
            {
                Id = c.Material.Genre.Id,
                Name = c.Material.Genre.Name
            }
        }
    };

    return checkoutDTO;
};

var CreateDetailedMaterialDTO = (Material m) =>
{
    MaterialDetailedDTO materialDTO = new MaterialDetailedDTO()
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        GenreId = m.GenreId,
        OutOfCirculationSince = m.OutOfCirculationSince,
        MaterialType = new MaterialTypeDTO()
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        Genre = new GenreDTO()
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        },
        Checkouts = m.Checkouts.Select(c => new CheckoutLateFeeDTO()
        {
            Id = c.Id,
            MaterialId = c.MaterialId,
            PatronId = c.PatronId,
            CheckoutDate = c.CheckoutDate,
            ReturnDate = c.ReturnDate,
            Paid = c.Paid,
            Material = new MaterialDTO()
            {
                Id = m.Id,
                MaterialName = m.MaterialName,
                MaterialTypeId = m.MaterialTypeId,
                GenreId = m.GenreId,
                OutOfCirculationSince = m.OutOfCirculationSince,
                MaterialType = new MaterialTypeDTO()
                {
                    Id = m.MaterialType.Id,
                    Name = m.MaterialType.Name,
                    CheckoutDays = m.MaterialType.CheckoutDays
                },
                Genre = new GenreDTO()
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            },
            Patron = new PatronDTO()
            {
                Id = c.Patron.Id,
                FirstName = c.Patron.FirstName,
                LastName = c.Patron.LastName,
                Address = c.Patron.Address,
                Email = c.Patron.Email,
                IsActive = c.Patron.IsActive,
            }
        }).ToList()
    };

    return materialDTO;
};

var CreatePatronDTO = (Patron p) =>
{
    PatronDTO patronDTO = new PatronDTO()
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Address = p.Address,
        Email = p.Email,
        IsActive = p.IsActive,
        Checkouts = p.Checkouts.Select(c => new CheckoutDTO()
        {
            Id = c.Id,
            MaterialId = c.MaterialId,
            PatronId = c.PatronId,
            CheckoutDate = c.CheckoutDate,
            ReturnDate = c.ReturnDate,
            Paid = c.Paid,
            Material = new MaterialDTO()
            {
                Id = c.Material.Id,
                MaterialName = c.Material.MaterialName,
                MaterialTypeId = c.Material.MaterialTypeId,
                GenreId = c.Material.GenreId,
                OutOfCirculationSince = c.Material.OutOfCirculationSince,
                MaterialType = new MaterialTypeDTO()
                {
                    Id = c.Material.MaterialType.Id,
                    Name = c.Material.MaterialType.Name,
                    CheckoutDays = c.Material.MaterialType.CheckoutDays
                }
            }
        }).ToList()
    };

    return patronDTO;
};

var CreatePatronWithBalanceDTO = (Patron p) =>
{
    PatronWithBalanceDTO patronDTO = new PatronWithBalanceDTO()
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Address = p.Address,
        Email = p.Email,
        IsActive = p.IsActive,
        Checkouts = p.Checkouts.Select(c => new CheckoutLateFeeDTO()
        {
            Id = c.Id,
            MaterialId = c.MaterialId,
            PatronId = c.PatronId,
            CheckoutDate = c.CheckoutDate,
            ReturnDate = c.ReturnDate,
            Paid = c.Paid,
            Material = new MaterialDTO()
            {
                Id = c.Material.Id,
                MaterialName = c.Material.MaterialName,
                MaterialTypeId = c.Material.MaterialTypeId,
                GenreId = c.Material.GenreId,
                OutOfCirculationSince = c.Material.OutOfCirculationSince,
                MaterialType = new MaterialTypeDTO()
                {
                    Id = c.Material.MaterialType.Id,
                    Name = c.Material.MaterialType.Name,
                    CheckoutDays = c.Material.MaterialType.CheckoutDays
                }
            }
        }).ToList()
    };

    return patronDTO;
};

app.MapGet("api/materials", (LoncotesLibraryDbContext db, int? materialTypeId, int? genreId) =>
{
    List<MaterialDTO> materialDTOs = db.Materials
        .Where(m => m.OutOfCirculationSince == null)
        .Where(m => materialTypeId == null ? true : m.MaterialTypeId == materialTypeId)
        .Where(m => genreId == null ? true : m.GenreId == genreId)
        .Include(m => m.MaterialType)
        .Include (m => m.Genre)
        .OrderBy(m => m.MaterialName)
        .Select(m => CreateMaterialDTO(m))
        .ToList();

    return materialDTOs;
});

app.MapGet("api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
   List<MaterialDetailedDTO> materialDTO = null;
    
    try
    {
        materialDTO = db.Materials
            .Where(m => m.Id == id)
            .Include(m => m.MaterialType)
            .Include (m => m.Genre)
            .Include(m => m.Checkouts)
            .ThenInclude(c => c.Patron)
            .Select(m => CreateDetailedMaterialDTO(m))
            .ToList();
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound();
    }

    return materialDTO.Any() ? Results.Ok(materialDTO[0]) : Results.NotFound();
});

app.MapGet("api/materials/available", (LoncotesLibraryDbContext db) =>
{
    List<MaterialDTO> materialDTOs = new List<MaterialDTO>();

    materialDTOs = db.Materials
        .Include(m => m.MaterialType)
        .Include(m => m.Genre)
        .Where(m => m.OutOfCirculationSince == null)
        .Where(m => m.Checkouts.All(co => co.ReturnDate != null))
        .Select(m => CreateMaterialDTO(m))
        .ToList();

    return materialDTOs;
});

app.MapPost("api/materials", (LoncotesLibraryDbContext db, MaterialCreateDTO materialToCreate) =>
{
    Material material = new Material()
    {
        MaterialName = materialToCreate.MaterialName,
        MaterialTypeId = materialToCreate.MaterialTypeId,
        GenreId = materialToCreate.GenreId,
        OutOfCirculationSince = materialToCreate.OutOfCirculationSince
    };

    db.Materials.Add(material);
    db.SaveChanges();

    return Results.Created($"/api/materials/{material.Id}", material);
});

app.MapDelete("api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Material material = db.Materials.SingleOrDefault(material => material.Id == id);
    if (material == null)
    {
        return Results.NotFound();
    }

    material.OutOfCirculationSince = DateTime.Now;
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("api/materialtypes", (LoncotesLibraryDbContext db) =>
{
    List<MaterialTypeDTO> materialTypeDTOs = db.MaterialTypes
        .Select(mt => new MaterialTypeDTO()
        {
            Id = mt.Id,
            Name = mt.Name,
            CheckoutDays = mt.CheckoutDays
        })
        .OrderBy(mt => mt.Name)
        .ToList();

    return materialTypeDTOs;
});

app.MapGet("api/genres", (LoncotesLibraryDbContext db) =>
{
    List<GenreDTO> genreDTOs = db.Genres
        .Select(g => new GenreDTO()
        {
            Id = g.Id,
            Name = g.Name
        })
        .OrderBy(g => g.Name)
        .ToList();

    return genreDTOs;
});

app.MapGet("api/patrons", (LoncotesLibraryDbContext db) =>
{
    List<PatronDTO> patronDTOs = db.Patrons
        .Select(p => new PatronDTO()
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Address = p.Address,
            Email = p.Email,
            IsActive = p.IsActive
        })
        .OrderBy(p => p.LastName)
        .ThenBy(p => p.FirstName)
        .ToList();

    return patronDTOs;
});

app.MapGet("api/patrons/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    List<PatronWithBalanceDTO> patronDTO = null;
    patronDTO = db.Patrons
        .Where(p => p.Id == id)
        .Include(p => p.Checkouts)
        .ThenInclude(c => c.Material)
        .ThenInclude(m => m.MaterialType)
        .Select(p => CreatePatronWithBalanceDTO(p))
        .ToList();

    return patronDTO.Any() ? Results.Ok(patronDTO[0]) : Results.NotFound();
});

app.MapPut("api/patrons/{id}", (LoncotesLibraryDbContext db, int id, PatronUpdateDTO update) =>
{
    if (update.Id != id)
    {
        return Results.BadRequest();
    }
    
    Patron foundPatron = db.Patrons.SingleOrDefault(p => p.Id == id);
    if (foundPatron == null)
    {
        return Results.NotFound();
    }

    foundPatron.Address = update.Address;
    foundPatron.Email = update.Email;
    db.SaveChanges();

    return Results.NoContent();
});

app.MapPut("api/patrons/{id}/deactivate", (LoncotesLibraryDbContext db, int id) =>
{
    Patron foundPatron = db.Patrons.SingleOrDefault(p => p.Id == id);
    if (foundPatron == null)
    {
        return Results.NotFound();
    }

    foundPatron.IsActive = false; 
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("api/checkouts/overdue", (LoncotesLibraryDbContext db) =>
{
    List<CheckoutLateFeeDTO> checkoutDTOs = db.Checkouts
        .Include(c => c.Patron)
        .Include(c => c.Material)
        .ThenInclude(m => m.Genre)
        .Include(c => c.Material)
        .ThenInclude(m => m.MaterialType)
        .Where(c => (
            ((DateTime.Today - c.CheckoutDate).Days > c.Material.MaterialType.CheckoutDays) &&
            (c.ReturnDate == null)
        ))
        .Select(c => CreateDetailedCheckoutDTO(c))
        .ToList();

    return checkoutDTOs;
});

app.MapGet("api/checkouts/unpaid", (LoncotesLibraryDbContext db) =>
{
    List<CheckoutLateFeeDTO> checkoutDTOs = db.Checkouts
        .Include(c => c.Patron)
        .Include(c => c.Material)
        .ThenInclude(m => m.Genre)
        .Include(c => c.Material)
        .ThenInclude(m => m.MaterialType)
        .Where(c => (
            (((DateTime.Today - c.CheckoutDate).Days > c.Material.MaterialType.CheckoutDays) &&
            (c.ReturnDate == null)) || (c.ReturnDate != null ?
            ((((DateTime)c.ReturnDate - c.CheckoutDate).Days > c.Material.MaterialType.CheckoutDays) &&
            (c.Paid == false)) : false)
        ))
        .Select(c => CreateDetailedCheckoutDTO(c))
        .ToList();

    return checkoutDTOs;
});

app.MapPost("api/checkouts", (LoncotesLibraryDbContext db, CheckoutCreateDTO checkout) =>
{
    Material foundMaterial = db.Materials.SingleOrDefault(m => m.Id == checkout.MaterialId);
    if (foundMaterial == null)
    {
        return Results.NotFound("Could not find chosen Material");
    }

    Patron foundPatron = db.Patrons.SingleOrDefault(p => p.Id == checkout.PatronId);
    if (foundPatron == null)
    {
        return Results.NotFound("Could not find chosen Patron");
    }

    Checkout newCheckout = new Checkout()
    {
        MaterialId = checkout.MaterialId,
        PatronId = checkout.PatronId,
        CheckoutDate = DateTime.Now,
        ReturnDate = null
    };

    db.Checkouts.Add(newCheckout);
    db.SaveChanges();

    CheckoutDTO checkoutDTO = new CheckoutDTO()
    {
        Id = newCheckout.Id,
        MaterialId = newCheckout.MaterialId,
        PatronId = newCheckout.PatronId,
        CheckoutDate = newCheckout.CheckoutDate,
        ReturnDate = newCheckout.ReturnDate
    };

    return Results.Created($"api/checkouts/{newCheckout.Id}", checkoutDTO);
});

app.MapPut("api/checkouts/{id}/return", (LoncotesLibraryDbContext db, int id) =>
{
    Checkout foundCheckout = db.Checkouts.SingleOrDefault(c => c.Id == id);
    if (foundCheckout == null)
    {
        return Results.NotFound();
    }
    if (foundCheckout.ReturnDate != null)
    {
        return Results.Conflict("This Material has already been returned!");
    }

    foundCheckout.ReturnDate = DateTime.Now;
    db.SaveChanges();

    return Results.NoContent();
});

app.MapPut("api/checkouts/{id}/pay", (LoncotesLibraryDbContext db, int id) =>
{
    Checkout foundCheckout = db.Checkouts.SingleOrDefault(c => c.Id == id);
    if (foundCheckout.ReturnDate == null)
    {
        return Results.BadRequest("That Material has not yet been returned!");
    }
    if (foundCheckout.Paid == true)
    {
        return Results.BadRequest("This balance was already paid!");
    }

    foundCheckout.Paid = true;
    db.SaveChanges();

    return Results.NoContent();
});

app.Run();

