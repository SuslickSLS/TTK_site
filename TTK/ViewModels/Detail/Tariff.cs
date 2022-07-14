using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels.Detail
{
    public class Tariff
    {
       
            [Required]
            public string Name { get; set; }

            [Required]
            public decimal price { get; set; }

            [Required]
            public List<int> component { get; set; }
            
             
            
            //[Required]
            //public int GB { get; set; }

            //[Required]
            //public int MIN { get; set; }
            //[Required]
            //public int SMS { get; set; }
            //[Required]
            //public int Home_internet { get; set; }

            //[Required]

            //public int TV { get; set; }


    }
}
