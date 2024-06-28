using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

public class Car
{
    [Key] 
    public int IdCar { get; set; }
    
    [MaxLength(17)]
    [Required]
    public string VIN { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Seats { get; set; }
    
    [Required]
    public int PricePerDay { get; set; }
    
    [Required]
    public int IdModel { get; set; }
    [ForeignKey(nameof(IdModel))]
    public Model Model { get; set; }
    
    [Required]
    public int IdColor { get; set; }
    
    [ForeignKey(nameof(IdColor))]
    public Color Color { get; set; }
    
    public ICollection<Car_Rental> CarRentals { get; set; }
}