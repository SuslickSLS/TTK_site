using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels.Admin
{
    public class DetailController
    {

        [Required]
        public Tariff tariff { get; set; }
        [Required]
        public List<Contract> users { get; set; }
        [Required]
        public List<Client> client { get; set; }
    }
}
