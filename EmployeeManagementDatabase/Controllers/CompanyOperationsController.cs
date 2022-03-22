using CompanyCRUDOperations;
using EmployeeManagementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyOperationsController : ControllerBase
    {
        // GET: api/<CompanyOperationsController>
        /// <summary>
        /// Display List of all Companies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CompanyDTO> Get()
        {
            AllCompanyInformationDisplay allCompanyInformationDisplay = new AllCompanyInformationDisplay();
            return allCompanyInformationDisplay.AllCompaniesInformationDisplay();
        }



        /// <summary>
        /// Display Detail of Company by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<CompanyOperationsController>/5
        [HttpGet("{id}")]
        public CompanyDTO Get(int id)
        {
            DisplayCompaniesInformationById displayCompaniesInformationById = new DisplayCompaniesInformationById();
            return displayCompaniesInformationById.DisplayCompanyInformationById(id);
        }



        /// <summary>
        /// Insert the details of a company.
        /// </summary>
        /// <param name="companyDTO"></param>
        /// <returns></returns>
        // POST api/<CompanyOperationsController>
        [HttpPost]
        public string Post([FromBody] CompanyDTO companyDTO)
        {
            CompanyInsertOperation companyInsertOperation = new CompanyInsertOperation();
            return companyInsertOperation.CompaniesInsertOperation(companyDTO);
        }



        /// <summary>
        /// Update the details of a Company by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyDTO"></param>
        /// <returns></returns>
        // PUT api/<CompanyOperationsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] CompanyDTO companyDTO)
        {
            CompanyUpdateOperation companyUpdateOperation = new CompanyUpdateOperation();
            return companyUpdateOperation.ComapaniesUpdateOperation(id, companyDTO);
        }



        /// <summary>
        /// Delete the details of Company by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<CompanyOperationsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            CompanyDeleteOperation companyDeleteOperation = new CompanyDeleteOperation();
            return companyDeleteOperation.CompanyDeleteOperationByID(id);
        }
    }
}
