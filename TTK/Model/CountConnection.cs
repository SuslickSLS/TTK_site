using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("CountConnection")]
    public partial class CountConnection
    {
        [Key]
        public int CountConnectionId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int Tariff { get; set; }
        [Column("count")]
        public int Count { get; set; }

        [ForeignKey(nameof(Tariff))]
        [InverseProperty("CountConnections")]
        public virtual Tariff TariffNavigation { get; set; }
    }
}
