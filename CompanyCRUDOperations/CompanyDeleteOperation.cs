using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CompanyCRUDOperations
{
    public class CompanyDeleteOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string CompanyDeleteOperationByID(int CompanyID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var command = new SqlCommand
                    {
                        CommandText = $"DELETE " +
                                      $"FROM Companies " +
                                      $"WHERE CompanyID=@CompanyID",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@CompanyID", CompanyID);
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                }
                return $"Delete Operation with CompanyID:{CompanyID} successfull";
            }
            catch (Exception DeleteException)
            {
                return DeleteException.Message;
            }
        }
    }
}
