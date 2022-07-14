using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels.Detail
{
    public class AddClient
    {
        [Required]
        public string FIO  { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string passport { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string password { get; set; }
    }
}
