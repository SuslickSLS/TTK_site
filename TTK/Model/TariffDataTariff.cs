using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("Tariff_DataTariff")]
    public partial class TariffDataTariff
    {
        [Key]
        [Column("Id_Tariff")]
        public int IdTariff { get; set; }
        [Key]
        [Column("Id_DataTariff")]
        public int IdDataTariff { get; set; }
        [Required]
        [StringLength(50)]
        public string Count { get; set; }

        [ForeignKey(nameof(IdDataTariff))]
        [InverseProperty(nameof(DataTariff.TariffDataTariffs))]
        public virtual DataTariff IdDataTariffNavigation { get; set; }
        [ForeignKey(nameof(IdTariff))]
        [InverseProperty(nameof(Tariff.TariffDataTariffs))]
        public virtual Tariff IdTariffNavigation { get; set; }
    }
}
