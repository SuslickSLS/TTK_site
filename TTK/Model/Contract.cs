using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Contract
    {
        public Contract()
        {
            ActionHistories = new HashSet<ActionHistory>();
            ClientHistoryTraffics = new HashSet<ClientHistoryTraffic>();
            ContractEquipments = new HashSet<ContractEquipment>();
        }

        [Key]
        [Column("contractId")]
        public int ContractId { get; set; }
        public int Client { get; set; }
        public long ContractNumber { get; set; }
        [Required]
        [StringLength(350)]
        public string AddressConnection { get; set; }
        public bool Status { get; set; }
        public int Tariff { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(Client))]
        [InverseProperty("Contracts")]
        public virtual Client ClientNavigation { get; set; }
        [ForeignKey(nameof(Tariff))]
        [InverseProperty("Contracts")]
        public virtual Tariff TariffNavigation { get; set; }
        [InverseProperty(nameof(ActionHistory.Contract))]
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
        [InverseProperty(nameof(ClientHistoryTraffic.ContractNavigation))]
        public virtual ICollection<ClientHistoryTraffic> ClientHistoryTraffics { get; set; }
        [InverseProperty(nameof(ContractEquipment.ContractNavigation))]
        public virtual ICollection<ContractEquipment> ContractEquipments { get; set; }
    }
}
