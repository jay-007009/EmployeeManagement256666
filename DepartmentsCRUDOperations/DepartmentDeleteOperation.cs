using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DepartmentsCRUDOperations
{
    public class DepartmentDeleteOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string DeleteDepartmentById(int departmentID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var command = new SqlCommand
                    {
                        CommandText = $"DELETE " +
                                      $"FROM Departments " +
                                      $"WHERE DepartmentID=@DepartmentID",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                }
                return $"Delete Operation with DepartmentID:{departmentID} successfull";
            }
            catch (Exception DeleteException)
            {
                return DeleteException.Message;
            }
        }
    }
    
}
