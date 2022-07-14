using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels.Admin
{
    public class ClientInfoAdmin
    {

        [Required]
        public List<Contract> Contract { get; set; }
        [Required]
        public List<string> Tariff { get; set; }
        [Required]
        public Client Client { get; set; }
        
        [Required]
        public List<Tariff> tariffs { get; set; }



    }
}
