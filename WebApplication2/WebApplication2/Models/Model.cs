using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Model
    {
        [Key]
        public int IdModel { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        
        public ICollection<Car> Cars { get; set; }
    }
}