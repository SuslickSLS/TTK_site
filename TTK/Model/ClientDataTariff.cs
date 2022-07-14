using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("Client_DataTariff")]
    public partial class ClientDataTariff
    {
        [Key]
        [Column("Id_Client")]
        public int IdClient { get; set; }
        [Key]
        [Column("Id_DataTariff")]
        public int IdDataTariff { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.ClientDataTariffs))]
        public virtual Client IdClientNavigation { get; set; }
        [ForeignKey(nameof(IdDataTariff))]
        [InverseProperty(nameof(DataTariff.ClientDataTariffs))]
        public virtual DataTariff IdDataTariffNavigation { get; set; }
    }
}
