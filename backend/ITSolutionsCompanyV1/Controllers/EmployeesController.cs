using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Service.ApplicationUserService;
using Microsoft.AspNetCore.Authorization;

namespace ITSolutionsCompanyV1.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationUserService _applicationUserService;

        public EmployeesController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        // GET: api/employees
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return _applicationUserService.GetAllEmployees();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = _applicationUserService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                _applicationUserService.UpdateEmployee(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                _applicationUserService.InsertEmployee(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        {
            var employee = _applicationUserService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee = _applicationUserService.DeleteEmployee(id);

            return employee;
        }

       /// <summary>
       /// Deactivate account
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>

        private bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
