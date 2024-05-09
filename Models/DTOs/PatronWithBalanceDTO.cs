using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class PatronWithBalanceDTO
{
    public int Id {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    public string Address {get; set;}
    [Required]
    public string Email {get; set;}
    [Required]
    public bool IsActive {get; set;}
    public List<CheckoutLateFeeDTO> Checkouts {get; set;}
    public decimal? Balance
    {
        get
        {
            decimal? sum = Checkouts.Any() ? 
                Checkouts.Where(c => c.LateFee != null && c.Paid == false).Sum(c => c.LateFee) : 
                null;
            return sum;
        }
    }
}