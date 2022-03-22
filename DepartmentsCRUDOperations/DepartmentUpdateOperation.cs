using EmployeeManagementDTOs;
using EmployeesCRUDOperations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ValidationClasses;

namespace DepartmentsCRUDOperations
{
    public class DepartmentUpdateOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string UpdateDepartmentDetails(int departmentID, DepartmentDTO departmentDTO)
        {
            try
            {
                //EmailValidation email_Validation = new EmailValidation();
                //PhoneNumberValidation phoneNumberValidation = new PhoneNumberValidation();
                //JoiningDateValidation joiningDateValidation = new JoiningDateValidation();


                //foreach (var employee in departmentDTO.EmployeesList)
                //{
                //    var IsEmailIdValid = email_Validation.IsEmailIdValid(employee.EmployeeEmailID);
                //    var IsPhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(employee.EmployeePhoneNo);
                //    var IsJoiningDateValid = joiningDateValidation.IsJoiningDateValid(employee.EmployeeJoiningDate);
                //    if (IsEmailIdValid && IsPhoneNumberValid && IsJoiningDateValid)
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        return "Enter Valid EmailId or PhoneNumber or Joining Date(YYYY/MM/DD) of Employee";
                //    }
                //}

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    var command1 = new SqlCommand
                    {
                        CommandText = $"SELECT DepartmentID,DepartmentName,DepartmentBranchAddress,DepartmentLead,CompanyID " +
                                      $"FROM Departments " +
                                      $"WHERE DepartmentID=@DepartmentID;",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command1.Parameters.AddWithValue("@DepartmentID", departmentID);

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
                            CommandText = $"UPDATE Departments " +
                                          $"SET DepartmentName=@DepartmentName,DepartmentBranchAddress=@DepartmentBranchAddress," +
                                          $"DepartmentLead=@DepartmentLead " +
                                          $"WHERE DepartmentID = @DepartmentID",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@DepartmentName", departmentDTO.DepartmentName);
                        command.Parameters.AddWithValue("@DepartmentBranchAddress", departmentDTO.DepartmentBranchAddress);
                        command.Parameters.AddWithValue("@DepartmentLead", departmentDTO.DepartmentLead);
                  
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                      
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "Department Update Operation Success.";
            }
            catch (Exception updateException)
            {
                return updateException.Message;
            }
        }
    }
}
