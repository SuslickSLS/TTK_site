using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Action
    {
        public Action()
        {
            ActionHistories = new HashSet<ActionHistory>();
        }

        [Key]
        [Column("Action_id")]
        public int ActionId { get; set; }
        [Required]
        [Column("Action_name")]
        [StringLength(100)]
        public string ActionName { get; set; }

        [InverseProperty(nameof(ActionHistory.Action))]
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
    }
}
