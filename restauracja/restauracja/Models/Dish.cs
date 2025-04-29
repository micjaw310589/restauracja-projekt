using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Menu")]
    public class Dish
    {
        [Column("id_d")]
        public int DishId { get; set; }

        [Column("nazwa"), MaxLength(20)]
        public string Name { get; set; } = "";

        [Column("cena", TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [Column("dostepny")]
        public bool Available { get; set; } = true;

        [Column("cz_staly", TypeName = "time")]
        public TimeSpan? TimeConstant { get; set; } = null;

        [Column("cz_obliczony", TypeName = "time")]
        public TimeSpan? TimeCalculated { get; set; } = null;

        [Column("danie_dnia")]
        public bool DishOfTheDay { get; set; } = false;

        [Column("wyklucz_flag")]
        public bool Exclude { get; set; } = false;

        public List<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
    }
}
