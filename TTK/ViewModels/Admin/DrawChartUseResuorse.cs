using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;
using TTK.ViewModels;

namespace TTK.ViewModels.Admin
{
    public class DrawChartUseResuorse
    {
        [Required]
        public string component_name { get; set; }
        [Required]
        public int component_count { get; set; }

        [Required]
        public int count_use { get; set; }
    }
}
