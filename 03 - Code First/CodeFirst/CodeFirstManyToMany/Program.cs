using CodeFirstManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstManyToMany
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string connection = @"Server=(localdb)\mssqllocaldb;Database=EmployeeEfCodeFirstMany2ManyDB;Trusted_Connection=True;";

      DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
           .UseSqlServer(connection)
           .Options;

      DataContext context = new DataContext(options);
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      if (!context.Employee.Any())
      {
        // Seed the database with employees
        context.Employee.Add(new Employee() { FirstName = "John", LastName = "Kocer", EmployeeProject = new List<EmployeeProject>() });
        context.Employee.Add(new Employee() { FirstName = "Adam", LastName = "Lee", EmployeeProject = new List<EmployeeProject>() });
        context.Employee.Add(new Employee() { FirstName = "Jon", LastName = "Walker", EmployeeProject = new List<EmployeeProject>() });
        context.Employee.Add(new Employee() { FirstName = "Jen", LastName = "Walker", EmployeeProject = new List<EmployeeProject>() });
        context.SaveChanges();
      }

      var employees = context.Employee.ToList();
      Console.WriteLine("Employee List:");
      foreach (var emp in employees)
      {
        Console.WriteLine($"{emp.EmployeeId}: {emp.FirstName} {emp.LastName}");
      }
    }
  }

  // Extension method for easy debugging output (alternative to the missing DDump)
  public static class ConsoleExtensions
  {
    public static void DDump<T>(this IEnumerable<T> items, string title)
    {
      Console.WriteLine(title);
      foreach (var item in items)
      {
          Console.WriteLine(item);
      }
    }
  }
}
