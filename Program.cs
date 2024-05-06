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
        Checkouts = m.Checkouts.Select(c => CreateCheckoutDTO(c)).ToList()
    };

    return materialDTO;
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

app.Run();

