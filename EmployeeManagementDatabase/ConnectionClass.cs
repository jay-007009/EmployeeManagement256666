using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeesManagementDatabase
{
    public class ConnectionClass
    {
        private readonly IConfiguration _configuration;
        protected ConnectionClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("CompanyDBConnect"));
        }
    }
}
