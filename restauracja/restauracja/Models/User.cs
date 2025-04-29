using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Uzytkownicy")]
    public class User
    {
        [Column("id_u")]
        public int UserId { get; set; }

        [Column("login"), MaxLength(15)]
        public string? Login { get; set; } = null;

        [Column("haslo"), MaxLength(15)]
        public string? Password { get; set; } = null;

        [Column("imie"), MaxLength(15)]
        public string FirstName { get; set; } = "";

        [Column("nazwisko"), MaxLength(20)]
        public string LastName { get; set; } = "";

        [Column("id_rola")]
        public int RoleId { get; set; }
        public Role? Role { get; set; } = null;

        [Column("id_lok")]
        public int? RestaurantId { get; set; } = null;
        public Restaurant? Restaurant { get; set; } = null;

        [Column("status")]
        public bool Status { get; set; } = true;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
