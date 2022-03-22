using EmployeeManagementDTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using ValidationClasses;
using System.Configuration;

namespace CompanyCRUDOperations
{
    public class CompanyInsertOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        //string connectionString = ConfigurationManager.ConnectionStrings["CompanyDBConnect"].ConnectionString;
      
        public string CompaniesInsertOperation(CompanyDTO companyDTO)
        {
            try
            {
              
                EmailValidation email_Validation = new EmailValidation();
                PhoneNumberValidation phoneNumberValidation = new PhoneNumberValidation();
                JoiningDateValidation joiningDateValidation = new JoiningDateValidation();

                var IsEmailIdValid = email_Validation.IsEmailIdValid(companyDTO.CompanyEmailID);
                var IsPhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(companyDTO.CompanyPhoneNo);

                if (IsEmailIdValid && IsPhoneNumberValid)
                {
                        foreach (var department in companyDTO.DepartmentList)
                        {
                            foreach (var employee in department.EmployeesList)
                            {
                                var IsEmployeeEmailIdValid = email_Validation.IsEmailIdValid(employee.EmployeeEmailID);
                                var IsEmployeePhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(employee.EmployeePhoneNo);
                                var IsEmployeeJoiningDateValid = joiningDateValidation.IsJoiningDateValid(employee.EmployeeJoiningDate);
                                if (IsEmployeeEmailIdValid && IsEmployeePhoneNumberValid && IsEmployeeJoiningDateValid)
                                {
                                    continue;
                                }
                                else
                                {
                                    return "Enter Valid EmailId or PhoneNumber or Joining Date(YYYY/MM/DD) of Employee";
                                }
                            }
                        }

                    using (var connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand
                        {
                            CommandText = $"INSERT INTO Companies" +
                                          $"(CompanyName,CompanyAddress,CompanyEmailID,CompanyPhoneNo) " +
                                          $"VALUES (@CompanyName,@CompanyAddress,@CompanyEmailID,@CompanyPhoneNo) select Scope_Identity()",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@CompanyName", companyDTO.CompanyName);
                        command.Parameters.AddWithValue("@CompanyAddress", companyDTO.CompanyAddress);
                        command.Parameters.AddWithValue("@CompanyEmailID", companyDTO.CompanyEmailID);
                        command.Parameters.AddWithValue("@CompanyPhoneNo", companyDTO.CompanyPhoneNo);
                        
                        connection.Open();
                        companyDTO.CompanyID = Convert.ToInt32(command.ExecuteScalar());

                        foreach (var department in companyDTO.DepartmentList)
                        {
                            var command1 = new SqlCommand
                            {
                                CommandText = $"INSERT INTO Departments " +
                                              $"(DepartmentName,DepartmentBranchAddress,DepartmentLead,CompanyID) " +
                                              $"VALUES (@DepartmentName,@DepartmentBranchAddress,@DepartmentLead,@CompanyID) " +
                                              $"Select SCOPE_IDENTITY()",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command1.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                            command1.Parameters.AddWithValue("@DepartmentBranchAddress", department.DepartmentBranchAddress);
                            command1.Parameters.AddWithValue("@DepartmentLead", department.DepartmentLead);
                            command1.Parameters.AddWithValue("@CompanyID", companyDTO.CompanyID);

                            var lastIdInserted = command1.ExecuteScalar();
                            department.DepartmentID = Convert.ToInt32(lastIdInserted);


                            foreach (var employee in department.EmployeesList)
                            {
                                var command2 = new SqlCommand
                                {
                                    CommandText = $"INSERT INTO Employees " +
                                         $"(EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender," +
                                         $"EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID) " +
                                         $"VALUES (@EmployeeName,@EmployeeUserName,@EmployeeJoiningDate,@EmployeeGender," +
                                         $"@EmployeeAddress,@EmployeePhoneNo,@EmployeeEmailID,@DepartmentID,@CompanyID)",
                                    Connection = connection,
                                    CommandType = CommandType.Text
                                };
                                command2.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                                command2.Parameters.AddWithValue("@EmployeeUserName", employee.EmployeeUserName);
                                command2.Parameters.AddWithValue("@EmployeeJoiningDate", employee.EmployeeJoiningDate);
                                command2.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                                command2.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                                command2.Parameters.AddWithValue("@EmployeePhoneNo", employee.EmployeePhoneNo);
                                command2.Parameters.AddWithValue("@EmployeeEmailID", employee.EmployeeEmailID);
                                command2.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                                command2.Parameters.AddWithValue("@CompanyID", companyDTO.CompanyID);

                                command2.ExecuteNonQuery();
                                command2.Parameters.Clear();
                            }
                            command1.Parameters.Clear();
                        }
                        command.Parameters.Clear();
                        connection.Close();

                    }

                }
                else
                {
                    return "Enter Valid Company Email or phoneNumber";
                }
                return "Company Insert Operation Success";
            }
            catch (Exception insertException)
            {
                return insertException.Message;
            }
        }
    }
}
