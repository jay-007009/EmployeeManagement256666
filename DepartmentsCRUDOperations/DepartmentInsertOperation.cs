using EmployeeManagementDTOs;
using EmployeesCRUDOperations;
using System;
using System.Data;
using System.Data.SqlClient;
using ValidationClasses;

namespace DepartmentsCRUDOperations
{
    public class DepartmentInsertOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string InsertDepartmentDetails(DepartmentDTO departmentDTO)
        {
            try
            {

                EmailValidation email_Validation = new EmailValidation();
                PhoneNumberValidation phoneNumberValidation = new PhoneNumberValidation();
                JoiningDateValidation joiningDateValidation = new JoiningDateValidation();
             
             
                foreach (var employee in departmentDTO.EmployeesList)
                {
                    var IsEmailIdValid = email_Validation.IsEmailIdValid(employee.EmployeeEmailID);
                    var IsPhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(employee.EmployeePhoneNo);
                    var IsJoiningDateValid = joiningDateValidation.IsJoiningDateValid(employee.EmployeeJoiningDate);
                    if (IsEmailIdValid && IsPhoneNumberValid && IsJoiningDateValid)
                    {
                        continue;
                    }
                    else
                    {
                        return "Enter Valid EmailId or PhoneNumber or Joining Date(YYYY/MM/DD) of Employee";
                    }
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand
                    {
                        CommandText = $"INSERT INTO Departments " +
                                  $"(DepartmentName,DepartmentBranchAddress,DepartmentLead,CompanyID) " +
                                  $"VALUES (@DepartmentName,@DepartmentBranchAddress,@DepartmentLead,@CompanyID) Select SCOPE_IDENTITY()",
                        Connection = connection,
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@DepartmentName", departmentDTO.DepartmentName);
                    command.Parameters.AddWithValue("@DepartmentBranchAddress", departmentDTO.DepartmentBranchAddress);
                    command.Parameters.AddWithValue("@DepartmentLead", departmentDTO.DepartmentLead);
                    command.Parameters.AddWithValue("@CompanyID", departmentDTO.CompanyID);

                    var lastIdInserted = command.ExecuteScalar();
                    departmentDTO.DepartmentID = Convert.ToInt32(lastIdInserted);

                    foreach (var employee in departmentDTO.EmployeesList)
                    {
                        var command1 = new SqlCommand
                        {
                            CommandText = $"INSERT INTO Employees " +
                                          $"(EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender," +
                                          $"EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID) " +
                                          $"VALUES (@EmployeeName,@EmployeeUserName,@EmployeeJoiningDate,@EmployeeGender," +
                                          $"@EmployeeAddress,@EmployeePhoneNo,@EmployeeEmailID,@DepartmentID,@CompanyID)",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command1.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        command1.Parameters.AddWithValue("@EmployeeUserName", employee.EmployeeUserName);
                        command1.Parameters.AddWithValue("@EmployeeJoiningDate", employee.EmployeeJoiningDate);
                        command1.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                        command1.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                        command1.Parameters.AddWithValue("@EmployeePhoneNo", employee.EmployeePhoneNo);
                        command1.Parameters.AddWithValue("@EmployeeEmailID", employee.EmployeeEmailID);
                        command1.Parameters.AddWithValue("@DepartmentID", departmentDTO.DepartmentID);
                        command1.Parameters.AddWithValue("@CompanyID", departmentDTO.CompanyID);

                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                    }

                    connection.Close();

                }
                return "Department Insert operation Success";
            }
            catch (Exception insertException)
            {
                return insertException.Message;
            }
        }
    }
}
