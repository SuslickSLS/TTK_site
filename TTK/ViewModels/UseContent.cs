using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels
{
    public class UseContent
    {
        [Required]
        public Contract contract { get; set; }

        [Required]
        public int componets { get; set; }


    }
}
