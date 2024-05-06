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



app.MapGet("api/materials", (LoncotesLibraryDbContext db) =>
{
    List<MaterialDTO> materialDTOs = db.Materials
        .Include(m => m.MaterialType)
        .Include (m => m.Genre)
        .OrderBy(m => m.MaterialName)
        .Select(m => CreateMaterialDTO(m)).ToList();

    return materialDTOs;
});

app.Run();

