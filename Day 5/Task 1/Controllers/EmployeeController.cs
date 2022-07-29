using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var empList = await _context.employees.ToListAsync();
            return Ok(empList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Employee obj = await _context.employees.FindAsync(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound("No Employee Details Found for the requested ID");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Employee Details Have been added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            _context.employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee Details have been Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _context.employees.FindAsync(id);
            _context.employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee Details have been deleted successfully");
        }
    }
}
