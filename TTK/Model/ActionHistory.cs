using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("ActionHistory")]
    public partial class ActionHistory
    {
        [Key]
        [Column("Action_id")]
        public int ActionId { get; set; }
        [Key]
        [Column("Contract_id")]
        public int ContractId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [ForeignKey(nameof(ActionId))]
        [InverseProperty("ActionHistories")]
        public virtual Action Action { get; set; }
        [ForeignKey(nameof(ContractId))]
        [InverseProperty("ActionHistories")]
        public virtual Contract Contract { get; set; }
    }
}
