using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirstMany2Many.EfDbFirstMany2ManyModels
{
    public partial class EmployeeEfCodeFirstMany2ManyDBContext : DbContext
    {
        public EmployeeEfCodeFirstMany2ManyDBContext()
        {
        }

        public EmployeeEfCodeFirstMany2ManyDBContext(DbContextOptions<EmployeeEfCodeFirstMany2ManyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProject { get; set; }
        public virtual DbSet<Project> Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeEfCodeFirstMany2ManyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId });

                entity.HasIndex(e => e.ProjectId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProject)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeeProject)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
