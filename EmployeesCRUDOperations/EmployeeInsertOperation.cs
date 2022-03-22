using EmployeeManagementDTOs;
using System;
using System.Data;
using System.Data.SqlClient;
using ValidationClasses;

namespace EmployeesCRUDOperations
{
    public class EmployeeInsertOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string EmployeesInsertOperation(EmployeeDTO employeeDTO)
        {
            try
            {
                
                EmailValidation email_Validation = new EmailValidation();
                PhoneNumberValidation phoneNumberValidation = new PhoneNumberValidation();
                JoiningDateValidation joiningDateValidation = new JoiningDateValidation();

                var IsEmailIdValid = email_Validation.IsEmailIdValid(employeeDTO.EmployeeEmailID);
                var IsPhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(employeeDTO.EmployeePhoneNo);
                var IsJoiningDateValid = joiningDateValidation.IsJoiningDateValid(employeeDTO.EmployeeJoiningDate);

                if (IsEmailIdValid && IsPhoneNumberValid && IsJoiningDateValid)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        var command1 = new SqlCommand
                        {
                            CommandText = $"SELECT EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender,EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID " +
                                          $"FROM Employees " +
                                          $"WHERE EmployeeUserName=@EmployeeUserName;",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command1.Parameters.AddWithValue("@EmployeeUserName",employeeDTO.EmployeeUserName);
                        var rowReader =command1.ExecuteReader();
                        if (rowReader.HasRows)
                        {
                            return "Enter Valid UserName";


                        }
                        else
                        {
                            rowReader.Close();
                            var command = new SqlCommand
                            {
                                CommandText = $"INSERT INTO Employees" +
                                              $"(EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender,EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID) " +
                                              $"VALUES (@EmployeeName,@EmployeeUserName,@EmployeeJoiningDate,@EmployeeGender,@EmployeeAddress,@EmployeePhoneNo,@EmployeeEmailID,@DepartmentID,@CompanyID)",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@EmployeeName", employeeDTO.EmployeeName);
                            command.Parameters.AddWithValue("@EmployeeUserName", employeeDTO.EmployeeUserName);
                            command.Parameters.AddWithValue("@EmployeeJoiningDate", employeeDTO.EmployeeJoiningDate);
                            command.Parameters.AddWithValue("@EmployeeGender", employeeDTO.EmployeeGender);
                            command.Parameters.AddWithValue("@EmployeeAddress", employeeDTO.EmployeeAddress);
                            command.Parameters.AddWithValue("@EmployeePhoneNo", employeeDTO.EmployeePhoneNo);
                            command.Parameters.AddWithValue("@EmployeeEmailID", employeeDTO.EmployeeEmailID);
                            command.Parameters.AddWithValue("@DepartmentID", employeeDTO.DepartmentID);
                            command.Parameters.AddWithValue("@CompanyID", employeeDTO.CompanyID);


                            command.ExecuteNonQuery();
                        }

                        connection.Close();

                    }

                }
                else
                {
                    return "Enter Valid Email or PhoneNumber or JoiningDate(YYYY/MM/DD)";
                }
                return "Employee Insert Operation Success";
            }
            catch (Exception insertException)
            {
                return insertException.Message;
            }
        }
    }
}
