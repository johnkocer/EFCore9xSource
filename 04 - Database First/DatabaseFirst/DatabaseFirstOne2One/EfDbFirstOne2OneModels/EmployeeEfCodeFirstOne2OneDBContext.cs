using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirstOne2One.EfDbFirstOne2OneModels
{
    public partial class EmployeeEfCodeFirstOne2OneDBContext : DbContext
    {
        public EmployeeEfCodeFirstOne2OneDBContext()
        {
        }

        public EmployeeEfCodeFirstOne2OneDBContext(DbContextOptions<EmployeeEfCodeFirstOne2OneDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database= EmployeeEfCodeFirstOne2OneDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .IsUnique();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.HomeAddress).HasMaxLength(100);

                entity.Property(e => e.Sate).HasMaxLength(2);

                entity.Property(e => e.Zip).HasMaxLength(5);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.EmployeeId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
