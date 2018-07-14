using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Smart-Delivery.Models
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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Repository> Repositories { get; set; }
        public virtual DbSet<Scale> Scales { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShipmentGood> ShipmentGoods { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                entity.ToTable("Admin");

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
                entity.ToTable("Cabinet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Cabinets)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("FK_Cabinet_Goods");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Cabinets)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Cabinet_Repositories");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_User");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scale>(entity =>
            {
                entity.ToTable("Scale");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Scales)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scale_Goods");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.ShipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shipment_Shipper");
            });

            modelBuilder.Entity<ShipmentGood>(entity =>
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
                entity.ToTable("Shipper");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Shipper)
                    .HasForeignKey<Shipper>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shipper_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
