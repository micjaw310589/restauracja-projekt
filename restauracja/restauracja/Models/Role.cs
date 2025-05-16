using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    //[Table("Role")]
    //public class Role : IdentityRole
    //{
    //    [Column("id_rola")]
    //    //public int RoleId { get; set; }
    //    public string RoleId { get; set; } = "";

    //    [Column("nazwa"), MaxLength(15)]
    //    public override string Name { get; set; } = "";

    //    public List<User> Users { get; set; } = new List<User>();
    //}

    public class Role : IdentityRole { }
}
