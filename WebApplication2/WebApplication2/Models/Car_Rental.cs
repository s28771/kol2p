using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Car_Rental
{
    [Key] 
    public int IdCar_Rental { get; set; }
    
    [Required]
    public int IdClient { get; set; }
    [ForeignKey(nameof(IdClient))]
    public Client Client { get; set; }
    
    [Required]
    public int IdCar { get; set; }
    
    [ForeignKey(nameof(IdCar))]
    public Car Car { get; set; }
    
    [Required] 
    public DateTime DateFrom { get; set; }
    
    [Required] 
    public DateTime DateTo { get; set; }
    
    [Required] 
    public int TotalPrice { get; set; }
    
    public int Disscount { get; set; }
}