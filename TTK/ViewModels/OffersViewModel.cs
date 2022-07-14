using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels
{
    public class OffersViewModel
    {
        //Tariff
        [Required]
        public  Tariff Tariff { get; set; }

        [Required]
        public List<DataTariff> DescriptionTariff { get; set; }


        //Equipment
        [Required]
        public Equipment Equipment { get; set; }

    }
}
