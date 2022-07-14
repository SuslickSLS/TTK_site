using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("roleId")]
        public int RoleId { get; set; }
        [Required]
        [Column("Role")]
        [StringLength(200)]
        public string Role1 { get; set; }

        [InverseProperty(nameof(User.RoleNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
