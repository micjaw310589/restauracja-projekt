using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("StaliKlienci")]
    public class RegularClient
    {
        [Column("id_k")]
        public int RegularClientId { get; set; }

        [Column("imie"), MaxLength(15)]
        public string FirstName { get; set; } = "";

        [Column("nazwisko"), MaxLength(20)]
        public string LastName { get; set; } = "";

        [Column("nr_tel"), MaxLength(12)]
        public string? PhoneNumber { get; set; } = null;

        [Column("mail"), MaxLength(10)]
        public string? Email { get; set; } = null;

        [Column("id_znizki")]
        public int? DiscountId { get; set; } = null;
        public Discount? Discount { get; set; } = null;

        [Column("czy_aktywny")]
        public bool Active { get; set; } = true;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
