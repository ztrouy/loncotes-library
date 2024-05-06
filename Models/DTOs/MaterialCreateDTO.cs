using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class MaterialCreateDTO
{
    [Required]
    public string MaterialName {get; set;}
    [Required]
    public int MaterialTypeId {get; set;}
    [Required]
    public int GenreId {get; set;}
    public DateTime? OutOfCirculationSince {get; set;}
}