using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("DataTariff")]
    public partial class DataTariff
    {
        public DataTariff()
        {
            ClientDataTariffs = new HashSet<ClientDataTariff>();
            ClientHistoryTraffics = new HashSet<ClientHistoryTraffic>();
            TariffDataTariffs = new HashSet<TariffDataTariff>();
        }

        [Key]
        [Column("Id _DataTariff")]
        public int IdDataTariff { get; set; }
        [Required]
        [Column("DataTariff_Name")]
        [StringLength(150)]
        public string DataTariffName { get; set; }

        [InverseProperty(nameof(ClientDataTariff.IdDataTariffNavigation))]
        public virtual ICollection<ClientDataTariff> ClientDataTariffs { get; set; }
        [InverseProperty(nameof(ClientHistoryTraffic.DataTariffNavigation))]
        public virtual ICollection<ClientHistoryTraffic> ClientHistoryTraffics { get; set; }
        [InverseProperty(nameof(TariffDataTariff.IdDataTariffNavigation))]
        public virtual ICollection<TariffDataTariff> TariffDataTariffs { get; set; }
    }
}
