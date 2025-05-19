using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace restauracja.Models
{
    [Table("Uzytkownicy")]
    public class User : IdentityUser
    {
        //[Column("id_u")]
        ////public int UserId { get; set; }
        //public string UserId { get; set; } = "";

        //[Column("login"), MaxLength(20)]
        //public string Login { get; set; } = "";

        //[Column("haslo"), MaxLength(50)]
        //public string Password { get; set; } = "";

        [Column("imie"), MaxLength(20)]
        public string FirstName { get; set; } = "";

        [Column("nazwisko"), MaxLength(30)]
        public string LastName { get; set; } = "";

        //[Column("id_rola")]
        //public int RoleId { get; set; }
        //public string RoleId { get; set; } = "";
        //public Role? Role { get; set; } = null;

        [Column("id_lok")]
        public int? RestaurantId { get; set; } = null;
        public Restaurant? Restaurant { get; set; } = null;

        [Column("status")]
        public bool Status { get; set; } = true;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
