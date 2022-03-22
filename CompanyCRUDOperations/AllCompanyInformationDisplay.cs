using EmployeeManagementDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CompanyCRUDOperations
{
    public class AllCompanyInformationDisplay
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public List<CompanyDTO> AllCompaniesInformationDisplay()
        {
            List<CompanyDTO> companyList = new List<CompanyDTO>();
            CompanyDTO company;
            DepartmentDTO department;
            EmployeeDTO employee;
            //DateTime? dateTime;
            //string Str;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand
                    {
                        CommandText = "Select C.CompanyID,C.CompanyName,C.CompanyAddress,C.CompanyEmailID,C.CompanyPhoneNo," +
                                      "D.DepartmentID,D.DepartmentName,D.DepartmentBranchAddress,D.DepartmentLead,D.CompanyID," +
                                      "E.EmployeeID,E.EmployeeName,E.EmployeeUserName,E.EmployeeJoiningDate,E.EmployeeGender,E.EmployeeAddress," +
                                      "E.EmployeePhoneNo,E.EmployeeEmailID " +
                                      "From Companies C " +
                                      "Left join Departments D " +
                                      "On D.CompanyID = C.CompanyID  " +
                                      "Left join Employees E " +
                                      "On E.DepartmentID = D.DepartmentID;",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        company = new CompanyDTO();

                        company.CompanyID = sqlReader["CompanyID"] as int? ?? default(int);
                        company.CompanyName = sqlReader["CompanyName"] as string;
                        company.CompanyAddress = sqlReader["CompanyAddress"] as string;
                        company.CompanyEmailID = sqlReader["CompanyEmailID"] as string;
                        company.CompanyPhoneNo = sqlReader["CompanyPhoneNo"] as string;

                        department = new DepartmentDTO();

                        department.CompanyID = sqlReader["CompanyID"] as int? ?? default(int);
                        department.DepartmentName = sqlReader["DepartmentName"] as string;
                        department.DepartmentBranchAddress = sqlReader["DepartmentBranchAddress"] as string;
                        department.DepartmentLead = sqlReader["DepartmentLead"] as int? ?? default(int);
                        department.DepartmentID = sqlReader["DepartmentID"] as int? ?? default(int);

                        employee = new EmployeeDTO();
                        employee.EmployeeID = sqlReader["EmployeeID"] as int? ?? default(int);
                        employee.EmployeeName = sqlReader["EmployeeName"] as string;
                        employee.EmployeeUserName = sqlReader["EmployeeUserName"] as string;
                        employee.EmployeeJoiningDate = sqlReader["EmployeeJoiningDate"] as string;
                        //dateTime = employee.EmployeeJoiningDate;
                        //Str = dateTime.Value.ToShortDateString();
                        //if (Str == "1/1/0001")
                        //{
                        //    employee.EmployeeJoiningDate = null;
                        //}
                        employee.EmployeeGender = sqlReader["EmployeeGender"] as string;
                        employee.EmployeeAddress = sqlReader["EmployeeAddress"] as string;
                        employee.EmployeePhoneNo = sqlReader["EmployeePhoneNo"] as string;
                        employee.EmployeeEmailID = sqlReader["EmployeeEmailID"] as string;
                        employee.DepartmentID = sqlReader["DepartmentID"] as int? ?? default(int);
                        employee.CompanyID = sqlReader["CompanyID"] as int? ?? default(int);

                        department.EmployeesList.Add(employee);
                        company.DepartmentList.Add(department);

                        companyList.Add(company);
                    }
                    connection.Close();

                }
                return companyList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
