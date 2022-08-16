using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Controllers.Data;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext context;

        public EmployeeController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> addEmp(Employee emp)
        {
            context.Employees.Add(emp);
            await context.SaveChangesAsync();
            return Ok(await context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> Update(Employee req)
        {
            var emp = await context.Employees.FindAsync(req.EmployeeId);
            if (emp == null) return BadRequest("Employee not Found");
            emp.EmployeeId = req.EmployeeId;    
            emp.DateOfJoining = req.DateOfJoining;
            emp.EmployeeName = req.EmployeeName;
            emp.photofilename = req.photofilename;
            emp.Department = req.Department;

            await context.SaveChangesAsync();
            return Ok(await context.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> delete(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null) return BadRequest("Employee not Found");
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return Ok(await context.Employees.ToListAsync());
        }
    }
}
