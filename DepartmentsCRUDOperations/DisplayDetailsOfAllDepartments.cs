using EmployeeManagementDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DepartmentsCRUDOperations
{
    public class DisplayDetailsOfAllDepartments
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public List<DepartmentDTO> DisplayDetailsOfDepartment()
        {
            List<DepartmentDTO> departmentsList = new List<DepartmentDTO>();
            DepartmentDTO department;
            EmployeeDTO employee;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select D.DepartmentID,D.DepartmentName,D.DepartmentBranchAddress,D.DepartmentLead," +
                                      "D.CompanyID,E.EmployeeID,E.EmployeeName,E.EmployeeUserName,E.EmployeeJoiningDate," +
                                      "E.EmployeeGender,E.EmployeeAddress,E.EmployeePhoneNo,E.EmployeeEmailID " +
                                      "from Departments D " +
                                      "left join Employees E " +
                                      "on E.DepartmentID = D.DepartmentID;",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        department = new DepartmentDTO();

                        department.CompanyID = sqlReader["CompanyID"] as int? ?? default(int);
                        department.DepartmentName = sqlReader["DepartmentName"] as string;
                        department.DepartmentBranchAddress = sqlReader["DepartmentBranchAddress"] as string;
                        department.DepartmentLead = sqlReader["DepartmentLead"] as int? ?? default(int);
                        department.DepartmentID = sqlReader["DepartmentID"] as int? ?? default(int);

                        employee = new EmployeeDTO();
                        employee.EmployeeID= sqlReader["EmployeeID"] as int? ?? default(int);
                        employee.EmployeeName= sqlReader["EmployeeName"] as string;
                        employee.EmployeeUserName = sqlReader["EmployeeUserName"] as string;
                        employee.EmployeeJoiningDate = sqlReader["EmployeeJoiningDate"] as string;
                        //string str=employee.EmployeeJoiningDate.ToShortDateString();
                        //if (str == "1/1/0001")
                        //{
                        //    employee.EmployeeJoiningDate = null;
                        //}
                        employee.EmployeeGender = sqlReader["EmployeeGender"] as string;
                        employee.EmployeeAddress = sqlReader["EmployeeAddress"] as string;
                        employee.EmployeePhoneNo = sqlReader["EmployeePhoneNo"] as string;
                        employee.EmployeeEmailID = sqlReader["EmployeeEmailID"] as string;

                        department.EmployeesList.Add(employee);
                        departmentsList.Add(department);
                    }
                    connection.Close();

                }
                return departmentsList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
