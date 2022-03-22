using DepartmentsCRUDOperations;
using EmployeeManagementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesManagementDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentOperationsController : ControllerBase
    {
        // GET: api/<DepartmentOperationsController>
        /// <summary>
        /// Display List of all Departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DepartmentDTO> Get()
        {
            DisplayDetailsOfAllDepartments displayDetailsOfAllDepartments = new DisplayDetailsOfAllDepartments();
            return displayDetailsOfAllDepartments.DisplayDetailsOfDepartment();
        }

        // GET api/<DepartmentOperationsController>/5
        /// <summary>
        /// Display Detail of Department by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public DepartmentDTO Get(int id)
        {
            DisplayDetailsOfDepartmentById detailsOfDepartmentById = new DisplayDetailsOfDepartmentById();
            return detailsOfDepartmentById.DisplayDetailsOfDepartment(id);
        }

        // POST api/<DepartmentOperationsController>
        /// <summary>
        /// Insert the details of a Department.
        /// </summary>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] DepartmentDTO departmentDTO)
        {
            DepartmentInsertOperation departmentInsertOperation = new DepartmentInsertOperation();
            return departmentInsertOperation.InsertDepartmentDetails(departmentDTO);
        }

        // PUT api/<DepartmentOperationsController>/5
        /// <summary>
        /// Update the details of a Department by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] DepartmentDTO departmentDTO)
        {
            DepartmentUpdateOperation departmentUpdateOperation = new DepartmentUpdateOperation();
            return departmentUpdateOperation.UpdateDepartmentDetails(id,departmentDTO);
        }

        // DELETE api/<DepartmentOperationsController>/5
        /// <summary>
        /// Delete the details of Department by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            DepartmentDeleteOperation deleteDepartment = new DepartmentDeleteOperation();
            return deleteDepartment.DeleteDepartmentById(id);
        }
    }
}
