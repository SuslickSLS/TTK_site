using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TTK.ViewModels.Detail
{
    public class TariffUpdate
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public List<int> component { get; set; }
    }
}
