using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int DishId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = "";
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
    }
}
