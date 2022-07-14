using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class User
    {
        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("client")]
        public int? Client { get; set; }
        [Required]
        [Column("password")]
        [StringLength(250)]
        public string Password { get; set; }
        [Column("role")]
        public int Role { get; set; }
        [StringLength(250)]
        public string Login { get; set; }

        [ForeignKey(nameof(Client))]
        [InverseProperty("Users")]
        public virtual Client ClientNavigation { get; set; }
        [ForeignKey(nameof(Role))]
        [InverseProperty("Users")]
        public virtual Role RoleNavigation { get; set; }
    }
}
