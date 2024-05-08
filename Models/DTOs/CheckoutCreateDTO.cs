using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class CheckoutCreateDTO
{
    [Required]
    public int MaterialId {get; set;}
    [Required]
    public int PatronId {get; set;}
}