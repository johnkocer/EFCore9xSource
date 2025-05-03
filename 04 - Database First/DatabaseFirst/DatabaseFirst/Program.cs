using System;
using System.Linq;
using DatabaseFirst.EfDbFirstModels;
using SmartIT.DebugHelper;

namespace DatabaseFirst
{
  class Program
  {
    static void Main(string[] args)
    {
      EfDbFirstModels.EmployeeEfCodeFirstDBContext context = new EmployeeEfCodeFirstDBContext();
      var employees = context.Employee.ToList();
      employees.DDump("Employee List: ");
      //----------- Employee List:  ----------
      //[{"EmployeeId":1,"DepartmentId":null,"FirstName":"John","LastName":"Kocer","Department//":null},
      //{"EmployeeId":2,"DepartmentId":null,"FirstName":"Adam","LastName":"Lee","Depar//tment":null},
      //{"EmployeeId":3,"DepartmentId":null,"FirstName":"Jon","LastName":"Walker"
      //,"Department":null},{"EmployeeId":4,"DepartmentId":null,"FirstName":"Jen","LastName":"//Walker","Department":null}] 

    }
  }
}
