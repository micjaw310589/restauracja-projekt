using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Znizki")]
    public class Discount
    {
        [Column("id_znizki")]
        public int DiscountId { get; set; }

        [Column("nazwa_poziomu"), MaxLength(15)]
        public string LevelName { get; set; } = "";

        [Column("znizka", TypeName = "decimal(3, 2)")]
        public decimal DiscountValue { get; set; }

        [Column("prog_zamowien", TypeName = "smallint")]
        public short OrderThreshold { get; set; }

        public List<RegularClient> RegularCustomers { get; set; } = new List<RegularClient>();
    }
}
