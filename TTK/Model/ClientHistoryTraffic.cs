using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("ClientHistoryTraffic")]
    public partial class ClientHistoryTraffic
    {
        [Key]
        [Column("histroryId")]
        public int HistroryId { get; set; }
        [Column("dataTariff")]
        public int DataTariff { get; set; }
        public long Count { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public int Contract { get; set; }

        [ForeignKey(nameof(Contract))]
        [InverseProperty("ClientHistoryTraffics")]
        public virtual Contract ContractNavigation { get; set; }
        [ForeignKey(nameof(DataTariff))]
        [InverseProperty("ClientHistoryTraffics")]
        public virtual DataTariff DataTariffNavigation { get; set; }
    }
}
