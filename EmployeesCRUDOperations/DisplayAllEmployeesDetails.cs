using EmployeeManagementDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeesCRUDOperations
{
    public class DisplayAllEmployeesDetails
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public List<EmployeeDTO> DisplayAllEmployees()
        {
            List<EmployeeDTO> employeeDTOsList = new List<EmployeeDTO>();
            EmployeeDTO employeeDTO;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select EmployeeID,EmployeeName,EmployeeUserName,EmployeeJoiningDate," +
                                      "EmployeeGender,EmployeeAddress,EmployeePhoneNo,EmployeeEmailID," +
                                      "DepartmentID,CompanyID " +
                                      "from Employees",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        employeeDTO = new EmployeeDTO()
                        {
                            EmployeeID = Convert.ToInt32(sqlReader["EmployeeID"]),
                            CompanyID = Convert.ToInt32(sqlReader["CompanyID"]),
                            DepartmentID = Convert.ToInt32(sqlReader["DepartmentID"]),
                            EmployeeName = sqlReader["EmployeeName"].ToString(),
                            EmployeeUserName = sqlReader["EmployeeUserName"].ToString(),
                            EmployeeEmailID = sqlReader["EmployeeEmailID"].ToString(),
                           

                        EmployeeJoiningDate = sqlReader["EmployeeJoiningDate"] as string,
                            EmployeeGender = sqlReader["EmployeeGender"].ToString(),
                            EmployeeAddress = sqlReader["EmployeeAddress"].ToString(),
                            EmployeePhoneNo = sqlReader["EmployeePhoneNo"].ToString()
                        };
                        employeeDTOsList.Add(employeeDTO);
                    }
                    connection.Close();

                }
                return employeeDTOsList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
