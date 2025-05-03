using BusinessLayer.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeJquery.Ui.Controllers
{
   [Produces("application/json")]
   [ApiController]
   [Route("api/Employee")]
   public class EmployeeController : ControllerBase
   {
      private readonly EmployeeDataContext _context;

      public EmployeeController(EmployeeDataContext context)
      {
         _context = context;
      }

      [Route("~/api/GetEmployees")]
      [HttpGet]
      public IEnumerable<Employee> GetEmployees()
      {
         return _context.Employee;
      }

      [HttpGet("{id}")]
      public ActionResult<Employee> Get(int id)
      {
         var employee = _context.Employee.Find(id);
         if (employee == null)
         {
             return NotFound();
         }
         return employee;
      }

      [Route("~/api/AddEmployee")]
      [HttpPost]
      public IActionResult AddEmployee([FromBody]Employee obj)
      {
         _context.Employee.Add(obj);
         _context.SaveChanges();
         return new ObjectResult("Employee added successfully!");
      }

      [Route("~/api/UpdateEmployee")]
      [HttpPut]
      public IActionResult UpdateEmployee([FromBody]Employee obj)
      {
         _context.Employee.Update(obj);
         _context.SaveChanges();
         return new ObjectResult("Employee modified successfully!");
      }

      [Route("~/api/DeleteEmployee/{id}")]
      [HttpDelete]
      public IActionResult Delete(int id)
      {
         var employee = _context.Employee.Find(id);
         if (employee == null)
         {
             return NotFound();
         }
         _context.Employee.Remove(employee);
         _context.SaveChanges();
         return new ObjectResult("Employee deleted successfully!");
      }
   }
}