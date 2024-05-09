using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class CheckoutLateFeeDTO
{
    public int Id {get; set;}
    [Required]
    public int MaterialId {get; set;}
    public MaterialDTO Material {get; set;}
    [Required]
    public int PatronId {get; set;}
    public PatronDTO Patron {get; set;}
    [Required]
    public DateTime CheckoutDate {get; set;}
    public DateTime? ReturnDate {get; set;}
    private static decimal _lateFeePerDay = 0.50M;
    public decimal? LateFee
    {
        get
        {
            DateTime returnDate = ReturnDate ?? DateTime.Today;
            DateTime dueDate = CheckoutDate.AddDays(Material.MaterialType.CheckoutDays);
            
            int daysLate = (returnDate - dueDate).Days;
            decimal fee = daysLate * _lateFeePerDay;

            return daysLate > 0 ? fee : null;
        }
    }
}