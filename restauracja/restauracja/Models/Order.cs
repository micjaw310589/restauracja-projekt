using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Zamowienia")]
    public class Order
    {
        [Column("id_zam")]
        public int OrderId { get; set; }

        [Column("id_u")]
        //public int UserId { get; set; }
        public string UserId { get; set; } = "";
        public User? User { get; set; } = null;

        [Column("id_rez")]
        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; } = null;

        [Column("id_k")]
        public int? RegularCustomerId { get; set; }
        public RegularClient? RegularCustomer { get; set; } = null;

        [Column("id_s")]
        public int TableId { get; set; }

        [Column("data_zam", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; } = DateTime.Now;

        [Column("data_wyd", TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; } = null;

        [Column("nr_wydania", TypeName = "tinyint")]
        public sbyte? DeliveryNumber { get; set; } = null;

        [Column("id_status", TypeName = "tinyint")]
        public sbyte StatusId { get; set; }
        public OrderStatus Status { get; set; } = null!;

        public List<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
        public List<Table> Tables { get; set; } = new List<Table>();
    }
}
