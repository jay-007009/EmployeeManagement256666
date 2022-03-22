using EmployeeManagementDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ValidationClasses;

namespace EmployeesCRUDOperations
{
    public class EmployeesUpdateOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string EmployeeUpdateOperation(int employeeID, EmployeeDTO employeeDTO)
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
                                         $"WHERE EmployeeID=@EmployeeID;",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command1.Parameters.AddWithValue("@EmployeeID", employeeID);

                        var rowReader = command1.ExecuteReader();
                        if (!rowReader.HasRows)
                        {
                            return "Enter Valid EmployeeID";
                        }
                        else
                        {
                            rowReader.Close();

                            var command = new SqlCommand
                            {
                                CommandText = $"UPDATE Employees " +
                                              $"SET EmployeeName=@EmployeeName,EmployeeJoiningDate=@EmployeeJoiningDate," +
                                              $"EmployeeGender=@EmployeeGender,EmployeeAddress=@EmployeeAddress," +
                                              $"EmployeePhoneNo=@EmployeePhoneNo,EmployeeEmailID=@EmployeeEmailID WHERE EmployeeID=@EmployeeID",
                                Connection = connection,
                                CommandType = CommandType.Text
                            };
                            command.Parameters.AddWithValue("@EmployeeName", employeeDTO.EmployeeName);
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            command.Parameters.AddWithValue("@EmployeeJoiningDate", employeeDTO.EmployeeJoiningDate);
                            command.Parameters.AddWithValue("@EmployeeGender", employeeDTO.EmployeeGender);
                            command.Parameters.AddWithValue("@EmployeeAddress", employeeDTO.EmployeeAddress);
                            command.Parameters.AddWithValue("@EmployeePhoneNo", employeeDTO.EmployeePhoneNo);
                            command.Parameters.AddWithValue("@EmployeeEmailID", employeeDTO.EmployeeEmailID);

                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                else
                {
                    return "Enter Valid Email or PhoneNumber or JoiningDate(YYYY/MM/DD).";
                }
                return "Employee Update Operation Success.";
            }
            catch (Exception updateException)
            {
                return updateException.Message;
            }
        }
    }
}
