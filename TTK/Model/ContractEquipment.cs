using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    [Table("ContractEquipment")]
    public partial class ContractEquipment
    {
        [Key]
        public int Contract { get; set; }
        [Key]
        public int Equipment { get; set; }

        [ForeignKey(nameof(Contract))]
        [InverseProperty("ContractEquipments")]
        public virtual Contract ContractNavigation { get; set; }
        [ForeignKey(nameof(Equipment))]
        [InverseProperty("ContractEquipments")]
        public virtual Equipment EquipmentNavigation { get; set; }
    }
}
