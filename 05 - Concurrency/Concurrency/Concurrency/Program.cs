using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Concurrency
{
  class Program
  {
    static void Main(string[] args)
    {
      string connection = @"Server=(localdb)\mssqllocaldb;Database=ConcurrencyDB;Trusted_Connection=True;";

      DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
           .UseSqlServer(connection)
           .Options;

      // Ensure database is created and has a employee in it
      using (var context = new DataContext(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Employee.Add(new Employee { FirstName = "John", LastName = "Walker" });
        context.SaveChanges();
      }

      using (var context = new DataContext(options))
      {
        // Fetch a employee from database and change phone number
        var employee = context.Employee.Single(p => p.EmployeeId == 1);
        employee.LastName = "WALKER18";

        // Change the employees name in the database (will cause a concurrency conflict)
        context.Database.ExecuteSqlRaw("UPDATE dbo.Employee SET FirstName = 'Amy' WHERE EmployeeId = 1");

        try
        {
          context.Database.ExecuteSqlRaw("UPDATE dbo.Employee SET FirstName = 'Amy' WHERE EmployeeId = 1");
          // Attempt to save changes to the database
          context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
          foreach (var entry in ex.Entries)
          {
            if (entry.Entity is Employee)
            {
              // Using a NoTracking query means we get the entity but it is not tracked by the context
              // and will not be merged with existing entities in the context.
              var databaseEntity = context.Employee.AsNoTracking().Single(p => p.EmployeeId == ((Employee)entry.Entity).EmployeeId);
              var databaseEntry = context.Entry(databaseEntity);

              foreach (var property in entry.Metadata.GetProperties())
              {
                var proposedValue = entry.Property(property.Name).CurrentValue;
                var originalValue = entry.Property(property.Name).OriginalValue;
                var databaseValue = databaseEntry.Property(property.Name).CurrentValue;

                // TODO: Logic to decide which value should be written to database
                // entry.Property(property.Name).CurrentValue = <value to be saved>;

                // Update original values to
                entry.Property(property.Name).OriginalValue = databaseEntry.Property(property.Name).CurrentValue;
              }
            }
            else
            {
              throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
            }
          }

          // Retry the save operation
          context.SaveChanges();
        }
      }
    }
  }
}