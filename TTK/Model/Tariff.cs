using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Tariff
    {
        public Tariff()
        {
            Contracts = new HashSet<Contract>();
            CountConnections = new HashSet<CountConnection>();
            TariffDataTariffs = new HashSet<TariffDataTariff>();
        }

        [Key]
        [Column("tariffId")]
        public int TariffId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Discription { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(Contract.TariffNavigation))]
        public virtual ICollection<Contract> Contracts { get; set; }
        [InverseProperty(nameof(CountConnection.TariffNavigation))]
        public virtual ICollection<CountConnection> CountConnections { get; set; }
        [InverseProperty(nameof(TariffDataTariff.IdTariffNavigation))]
        public virtual ICollection<TariffDataTariff> TariffDataTariffs { get; set; }
    }
}
