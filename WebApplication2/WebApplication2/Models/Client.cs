using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key] 
    public int IdClient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Adress { get; set; }
    
    public ICollection<Car_Rental> CarRentals { get; set; }
}