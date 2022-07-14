using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels
{
    public class Client_Info
    {
        [Required]
        public Contract contract { get; set; }
        [Required]
        public string tariffName { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public bool status { get; set; }


    }
}
