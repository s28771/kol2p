using System.ComponentModel.DataAnnotations;

public class Color
{
    [Key] 
    public int IdColor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; }
}