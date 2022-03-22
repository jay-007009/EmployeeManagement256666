using EmployeeManagementDTOs;
using EmployeesCRUDOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesManagementDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeOperationsController : ControllerBase
    {
        // GET: api/<EmployeeOperationsController>
        /// <summary>
        /// Display List of all Employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            DisplayAllEmployeesDetails displayAllEmployeesDetails = new DisplayAllEmployeesDetails();
            return displayAllEmployeesDetails.DisplayAllEmployees();
        }

        // GET api/<EmployeeOperationsController>/5
        /// <summary>
        /// Display Detail of Employee by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public List<EmployeeDTO> Get(int id)
        {
            DisplayEmployeeDetailsById displayEmployeeDetailsById = new DisplayEmployeeDetailsById();
            return displayEmployeeDetailsById.DisplayEmployeeDetails(id);
        }

        // POST api/<EmployeeOperationsController>
        /// <summary>
        /// Insert the details of a Employee.
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] EmployeeDTO employeeDTO)
        {
            EmployeeInsertOperation employeeInsertOperation = new EmployeeInsertOperation();
            return employeeInsertOperation.EmployeesInsertOperation(employeeDTO);
        }

        // PUT api/<EmployeeOperationsController>/5
        /// <summary>
        /// Update the details of a Employee by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            EmployeesUpdateOperation employeesUpdateOperation = new EmployeesUpdateOperation();
            return employeesUpdateOperation.EmployeeUpdateOperation(id,employeeDTO);
        }

        // DELETE api/<EmployeeOperationsController>/5
        /// <summary>
        /// Delete the details of Employee by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            EmployeeDeleteOperation employeeDeleteOperation = new EmployeeDeleteOperation();
            return employeeDeleteOperation.DeleteEmployeeById(id);
        }
    }
}
