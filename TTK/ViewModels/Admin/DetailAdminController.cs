using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TTK.ViewModels.Admin
{
    public class DetailAdminController
    {
        [Required]
        public int count { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
