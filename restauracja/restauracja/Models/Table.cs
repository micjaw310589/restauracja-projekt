using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Stoliki")]
    public class Table
    {
        [Column("id_stolika")]
        public int TableId { get; set; }

        [Column("id_lok")]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; } = null;

        [Column("nr_stolika")]
        public int TableNumber { get; set; }

        [Column("liczba_miejsc", TypeName = "smallint")]
        public short Seats { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
