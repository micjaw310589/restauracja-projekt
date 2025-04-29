using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Rezerwacje")]
    public class Reservation
    {
        [Column("id_rez")]
        public int ReservationId { get; set; }

        [Column("nazwisko"), MaxLength(20)]
        public string LastName { get; set; } = "";

        [Column("nr_tel"), MaxLength(12)]
        public string PhoneNumber { get; set; } = "";

        [Column("id_stolika")]
        public int TableId { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();

        [Column("data_rez", TypeName = "datetime")]
        public DateTime? ReservationDate { get; set; } = DateTime.Now;

        [Column("data_koniec", TypeName = "datetime")]
        public DateTime? EndDate { get; set; } = null;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
