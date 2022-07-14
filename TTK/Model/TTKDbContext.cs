using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TTK.Model
{
    public partial class TTKDbContext : DbContext
    {
        public TTKDbContext()
        {
        }

        public TTKDbContext(DbContextOptions<TTKDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionHistory> ActionHistories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientDataTariff> ClientDataTariffs { get; set; }
        public virtual DbSet<ClientHistoryTraffic> ClientHistoryTraffics { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractEquipment> ContractEquipments { get; set; }
        public virtual DbSet<CountConnection> CountConnections { get; set; }
        public virtual DbSet<DataTariff> DataTariffs { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffDataTariff> TariffDataTariffs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HOME-PC\\SQLEXPRESS;Database=db_a7cad1_ttk;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.ActionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ActionHistory>(entity =>
            {
                entity.HasKey(e => new { e.ActionId, e.ContractId });

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionHistories)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionHistory_Actions");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ActionHistories)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionHistory_Contracts");
            });

            modelBuilder.Entity<ClientDataTariff>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdDataTariff });

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientDataTariffs)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_DataTariff_Clients");

                entity.HasOne(d => d.IdDataTariffNavigation)
                    .WithMany(p => p.ClientDataTariffs)
                    .HasForeignKey(d => d.IdDataTariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_DataTariff_DataTariff");
            });

            modelBuilder.Entity<ClientHistoryTraffic>(entity =>
            {
                entity.HasOne(d => d.ContractNavigation)
                    .WithMany(p => p.ClientHistoryTraffics)
                    .HasForeignKey(d => d.Contract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientHistoryTraffic_Contracts");

                entity.HasOne(d => d.DataTariffNavigation)
                    .WithMany(p => p.ClientHistoryTraffics)
                    .HasForeignKey(d => d.DataTariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientHistoryTraffic_DataTariff");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Clients");

                entity.HasOne(d => d.TariffNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.Tariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Tariffs");
            });

            modelBuilder.Entity<ContractEquipment>(entity =>
            {
                entity.HasKey(e => new { e.Contract, e.Equipment });

                entity.HasOne(d => d.ContractNavigation)
                    .WithMany(p => p.ContractEquipments)
                    .HasForeignKey(d => d.Contract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractEquipment_Contracts");

                entity.HasOne(d => d.EquipmentNavigation)
                    .WithMany(p => p.ContractEquipments)
                    .HasForeignKey(d => d.Equipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractEquipment_Equipments");
            });

            modelBuilder.Entity<CountConnection>(entity =>
            {
                entity.Property(e => e.CountConnectionId).ValueGeneratedNever();

                entity.HasOne(d => d.TariffNavigation)
                    .WithMany(p => p.CountConnections)
                    .HasForeignKey(d => d.Tariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountConnection_Tariffs");
            });

            modelBuilder.Entity<TariffDataTariff>(entity =>
            {
                entity.HasKey(e => new { e.IdDataTariff, e.IdTariff });

                entity.HasOne(d => d.IdDataTariffNavigation)
                    .WithMany(p => p.TariffDataTariffs)
                    .HasForeignKey(d => d.IdDataTariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tariff_DataTariff_DataTariff");

                entity.HasOne(d => d.IdTariffNavigation)
                    .WithMany(p => p.TariffDataTariffs)
                    .HasForeignKey(d => d.IdTariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tariff_DataTariff_Tariffs");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Client)
                    .HasConstraintName("FK_Users_Clients");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
