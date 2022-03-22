using GenerateExcelFileOperations;
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
    public class GenerateXLController : ControllerBase
    {
        // GET: api/<GenerateXLController>
        /// <summary>
        /// Generates Excel File of all companies with departments and employees
        /// </summary>
        /// <returns>Filepath of the file in string</returns>
        [HttpGet]
        public string Get()
        {
            GenerateXLFormat generateXL = new GenerateXLFormat();
            return generateXL.GenerateXL();
        }

        // GET api/<GenerateXLController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenerateXLController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GenerateXLController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenerateXLController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
