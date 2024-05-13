using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class MaterialDetailedDTO
{
    public int Id {get; set;}
    [Required]
    public string MaterialName {get; set;}
    [Required]
    public int MaterialTypeId {get; set;}
    public MaterialTypeDTO MaterialType {get; set;}
    [Required]
    public int GenreId {get; set;}
    public GenreDTO Genre {get; set;}
    public DateTime? OutOfCirculationSince {get; set;}
    public List<CheckoutLateFeeDTO> Checkouts {get; set;}
}