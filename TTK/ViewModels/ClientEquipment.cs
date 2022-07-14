using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels
{
    public class ClientEquipment
    {


        [Required]
        public List<Equipment> equipment { get; set; }
        //[Required]
        //public string equipmentName { get; set; }
        
        //[Required]
        //public string equipmentDescription { get; set; }
        
        //[Required]
        //public decimal price { get; set; }

    }
}
