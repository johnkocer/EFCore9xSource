using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using CodeFirstOne2One.Models;

namespace CodeFirstOne2One
{
  internal class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>()
                  .HasOne(e => e.Address) // Mark Address property optional in Student entity
                  .WithOne(ad => ad.Employee) // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
                  .HasForeignKey<Address>(a => a.EmployeeId);
      base.OnModelCreating(modelBuilder);
    }
  }
}
