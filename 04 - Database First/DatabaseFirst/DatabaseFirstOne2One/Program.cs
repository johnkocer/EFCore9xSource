using System;
using System.Linq;
using DatabaseFirstOne2One.EfDbFirstOne2OneModels;
using SmartIT.DebugHelper;

namespace DatabaseFirstOne2One
{
  class Program
  {
    static void Main(string[] args)
    {
      EmployeeEfCodeFirstOne2OneDBContext context = new EmployeeEfCodeFirstOne2OneDBContext();
      var employees = context.Employee.ToList();
      employees.DDump("Employee List: ");
// output
//[{"EmployeeId":1,"LastName":"Kocer","FirstName":"John","Address":null},
//{"EmployeeId":2,"LastName":"Lee","FirstName":"Adam","Address":null},
//{"EmployeeId":3,"LastName":"Walker","FirstName":"Jon","Address":null},
//{"EmployeeId":4,"LastName":"Walker","FirstName":"Jen","Address":null}]
    }
  }
}
