namespace EF6xCodeFirst.EF
{
  using System;
  using System.Data.Entity;
  using System.Linq;
    using EF6xCodeFirst.Models;

    public class EmployeeModel : DbContext
  {
    // Your context has been configured to use a 'EmployeeModel' connection string from your application's 
    // configuration file (App.config or Web.config). By default, this connection string targets the 
    // 'EF6xCodeFirst.EF.EmployeeModel' database on your LocalDb instance. 
    // 
    // If you wish to target a different database and/or database provider, modify the 'EmployeeModel' 
    // connection string in the application configuration file.
    public EmployeeModel()
        : base("name=EmployeeModel")
    {
    }

    // Add a DbSet for each entity type that you want to include in your model. For more information 
    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    // public virtual DbSet<MyEntity> MyEntities { get; set; }
    // public virtual DbSet<MyEntity> MyEntities { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<Department> Department { get; set; }

  }

  //public class MyEntity
  //{
  //    public int Id { get; set; }
  //    public string Name { get; set; }
  //}
}