using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeesCRUDOperations
{
    public class EmployeeDeleteOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string DeleteEmployeeById(int employeeID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command1 = new SqlCommand
                    {
                        CommandText = $"SELECT EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender,EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID " +
                                         $"FROM Employees " +
                                         $"WHERE EmployeeID=@EmployeeID;",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command1.Parameters.AddWithValue("@EmployeeID", employeeID);

                    var rowReader = command1.ExecuteReader();
                    if (!rowReader.HasRows)
                    {
                        return "Enter Valid EmployeeID.";
                    }
                    else
                    {
                        rowReader.Close();

                        var command = new SqlCommand
                        {
                            CommandText = $"DELETE " +
                                      $"FROM Employees " +
                                      $"WHERE EmployeeID=@EmployeeID",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();

                }
                return $"Delete Operation with EmployeeID:{employeeID} successfull.";
            }
            catch (Exception DeleteException)
            {
                return DeleteException.Message;
            }
        }
    }
}
