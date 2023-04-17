using Microsoft.EntityFrameworkCore;
using Tekus.Models;

namespace Tekus.Repository.SQLSERVER
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServicePortafolio> ServicePortafolios { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<VendorCustom> VendorCustoms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.HasIndex(e => e.Name, "UQ_Service")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hourprice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("hourprice");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ServicePortafolio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ServicePortafolio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdVendor).HasColumnName("idVendor");

                entity.Property(e => e.IdService).HasColumnName("idService");

                entity.Property(e => e.IdCountry).HasColumnName("idCountry");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.ServicePortafolios)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePortafolio_Country");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServicePortafolios)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePortafolio_Service");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.ServicePortafolios)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePortafolio_Vendor");

            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.HasIndex(e => e.Nit, "UK_vendor")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nit)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nit");
            });

            modelBuilder.Entity<VendorCustom>(entity =>
            {
                entity.HasIndex(e => e.Id, "UQ_VendorCustoms")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdVendor).HasColumnName("idVendor");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdNavigation)
                   .WithOne(p => p.VendorCustom)
                   .HasForeignKey<VendorCustom>(d => d.Id)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_VendorCustoms_vendor1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
