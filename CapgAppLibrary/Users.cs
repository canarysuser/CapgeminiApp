using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgAppLibrary
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [DefaultValue("Admin")]
        public string RoleName { get; set; } = "Admin";

    }
}
