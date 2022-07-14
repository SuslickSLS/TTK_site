using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTK.Model;

namespace TTK.ViewModels
{
    public class ClientHistory
    {
        [Required]
        public List<ClientHistoryTraffic> historyTraffic { get; set; }

        [Required]
        public List<DataTariff> dataTariff { get; set; }

        [Required]
        public string tariffName { get; set; }

    }
}
