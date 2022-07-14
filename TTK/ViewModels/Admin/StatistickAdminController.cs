using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TTK.ViewModels.Admin
{
    public class StatistickAdminController
    {
        [Required]
        public string tariff_name { get; set; }
        [Required]
        public int Conunt_tariff { get; set; }
    }
}
