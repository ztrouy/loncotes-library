using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class PatronUpdateDTO
{
    public int Id {get; set;}
    [Required]
    public string Address {get; set;}
    [Required]
    public string Email {get; set;}
}