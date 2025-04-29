using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Menu_Zamowienia")]
    public class DishOrder
    {
        [Column("id_d_zam")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [Column("id_d_men")]
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;

        [Column("cena_zakupu", TypeName = "decimal(5, 2)")]
        public decimal PurchasePrice { get; set; }

        [Column("czy_do_znizki")]
        public bool Discountable { get; set; } = false;
    }
}
