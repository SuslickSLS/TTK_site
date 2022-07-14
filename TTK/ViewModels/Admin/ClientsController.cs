using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels.Admin
{
    public class ClientsController
    {

        
        [Required]
        public List<Client> clients { get; set; }
        [Required]
        public List<Contract> contracts { get; set; }

        [Required]
        public List<Tariff> tariff { get; set; }
    }
}
