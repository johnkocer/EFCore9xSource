using CodeFirst.Customized.Models;
using Microsoft.EntityFrameworkCore;
using SmartIT.DebugHelper;

namespace CodeFirst.Customized
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string connection = @"Server=(localdb)\mssqllocaldb;Database= EmployeeEfCodeFirstCustDB ;Trusted_Connection=True;";

      DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
           .UseSqlServer(connection)
           .Options;

      DataContext context = new DataContext(options);
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      if (!context.Department.Any())
      {
        context.Department.Add(new Department() { Name = "IT" });
      }

      if (!context.Employee.Any())
      {
        // Seed the database with employees
        context.Employee.Add(new Employee() { FirstName = "John", LastName = "Kocer", DepartmentId = 1 });
        context.Employee.Add(new Employee() { FirstName = "Adam", LastName = "Lee", DepartmentId = 1 });
        context.Employee.Add(new Employee() { FirstName = "Jon", LastName = "Walker", DepartmentId = 1 });
        context.Employee.Add(new Employee() { FirstName = "Jen", LastName = "Walker", DepartmentId = 1 });
        context.SaveChanges();
      }

      var employees = context.Employee.ToList();
      employees.DDump("Employee List: ");
    }
    //       ----------- Employee List:  ----------
    //[{"EmployeeId":1,"DepartmentId":1,"LastName":"Kocer","FirstName":"John","FullName":"John Kocer"},
    //{"EmployeeId":2,"DepartmentId":1,"LastName":"Lee","FirstName":"Adam","FullName":"Adam Lee"},
    //{"EmployeeId":3,"DepartmentId":1,"LastName":"Walker","FirstName":"Jon","FullName":"Jon Walker"},
    //{"EmployeeId":4,"DepartmentId":1,"LastName":"Walker","FirstName":"Jen","FullName":"Jen Walker"}]

  }
}
