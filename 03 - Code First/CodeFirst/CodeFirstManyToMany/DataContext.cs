using CodeFirstManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstManyToMany
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<EmployeeProject> EmployeeProject { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EmployeeProject>()
         .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

      modelBuilder.Entity<EmployeeProject>()
                  .HasOne(ep => ep.Employee)
                  .WithMany(e => e.EmployeeProject)
                  .HasForeignKey(ep => ep.EmployeeId);

      modelBuilder.Entity<EmployeeProject>()
                  .HasOne(ep => ep.Project)
                  .WithMany(p => p.EmployeeProject)
                  .HasForeignKey(ep => ep.ProjectId);

      base.OnModelCreating(modelBuilder);
    }
  }
}


