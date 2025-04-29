using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Status")]
    public class OrderStatus
    {
        [Column("id_stat", TypeName = "tinyint")]
        public sbyte StatusId { get; set; }

        [Column("nazwa"), MaxLength(15)]
        public string Name { get; set; } = "";

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
