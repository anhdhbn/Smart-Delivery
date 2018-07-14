using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartDelivery.Models
{
    public partial class SmartDeliveryContext : DbContext
    {
        public SmartDeliveryContext()
        {
        }

        public SmartDeliveryContext(DbContextOptions<SmartDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Cabinet> Cabinet { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Repositories> Repositories { get; set; }
        public virtual DbSet<Scale> Scale { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<ShipmentGoods> ShipmentGoods { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=den1.mssql2.gear.host;initial catalog=SmartDelivery;persist security info=True;user id=smartdelivery;password=smartdelivery^^;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fullname).HasMaxLength(10);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_User1");
            });

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Cabinet)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("FK_Cabinet_Goods");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Cabinet)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Cabinet_Repositories");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_User");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressRecive)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Repositories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scale>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Scale)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scale_Goods");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.ShipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shipment_Shipper");
            });

            modelBuilder.Entity<ShipmentGoods>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.ShipmentGoods)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentGoods_Goods");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentGoods)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentGoods_Shipment");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Shipper)
                    .HasForeignKey<Shipper>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shipper_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
