using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauracja.Models
{
    [Table("Role")]
    public class Role
    {
        [Column("id_rola")]
        public int RoleId { get; set; }

        [Column("nazwa"), MaxLength(15)]
        public string Name { get; set; } = "";

        public List<User> Users { get; set; } = new List<User>();
    }
}
