using System;
using System.Linq;
using DatabaseFirstMany2Many.EfDbFirstMany2ManyModels;
using SmartIT.DebugHelper;

namespace DatabaseFirstMany2Many
{
  class Program
  {
    static void Main(string[] args)
    {
      EmployeeEfCodeFirstMany2ManyDBContext context = new EmployeeEfCodeFirstMany2ManyDBContext();
      var employees = context.Employee.ToList();
     employees.DDump("Employee List: ");
// output:
// [{"EmployeeId":1,"LastName":"Kocer","FirstName":"John","EmployeeProject":[]},
//{"EmployeeId":2,"LastName":"Lee","FirstName":"Adam","EmployeeProject":[]},
//{"EmployeeId":3,"LastName":"Walker","FirstName":"Jon","EmployeeProject":[]},
//{"EmployeeId":4,"LastName":"Walker","FirstName":"Jen","EmployeeProject":[]}]
    }
  }
}
