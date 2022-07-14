using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TTK.Model
{
    public partial class Client
    {
        public Client()
        {
            ClientDataTariffs = new HashSet<ClientDataTariff>();
            Contracts = new HashSet<Contract>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("clientId")]
        public int ClientId { get; set; }
        [Required]
        [StringLength(250)]
        public string Fullname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(20)]
        public string Passport { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }
        public bool? Status { get; set; }

        [InverseProperty(nameof(ClientDataTariff.IdClientNavigation))]
        public virtual ICollection<ClientDataTariff> ClientDataTariffs { get; set; }
        [InverseProperty(nameof(Contract.ClientNavigation))]
        public virtual ICollection<Contract> Contracts { get; set; }
        [InverseProperty(nameof(User.ClientNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
