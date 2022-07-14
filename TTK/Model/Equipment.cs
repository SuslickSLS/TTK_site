using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Equipment
    {
        public Equipment()
        {
            ContractEquipments = new HashSet<ContractEquipment>();
        }

        [Key]
        [Column("equipmentId")]
        public int EquipmentId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Discription { get; set; }
        [Required]
        [StringLength(250)]
        public string Image { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(ContractEquipment.EquipmentNavigation))]
        public virtual ICollection<ContractEquipment> ContractEquipments { get; set; }
    }
}
