using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Lokale")]
    public class Restaurant
    {
        [Column("id_lok")]
        public int RestaurantId { get; set; }

        [Column("nazwa"), MaxLength(20)]
        public string Name { get; set; } = "";

        [Column("adres"), MaxLength(50)]
        public string Address { get; set; } = "";

        [Column("miasto"), MaxLength(20)]
        public string City { get; set; } = "";

        [Column("czy_otwarty")]
        public bool Open { get; set; } = true;

        public List<User> Users { get; set; } = new List<User>();
        public List<Table> Tables { get; set; } = new List<Table>();
    }
}
