using EmployeeManagementDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ValidationClasses;

namespace CompanyCRUDOperations
{
    public class CompanyUpdateOperation
    {
        private readonly string connectionString = "server=.;Initial catalog=EmployeeManagementDatabase;Integrated security=SSPI";
        public string ComapaniesUpdateOperation(int CompanyID, CompanyDTO companyDTO)
        {
            try
            {
                EmailValidation email_Validation = new EmailValidation();
                PhoneNumberValidation phoneNumberValidation = new PhoneNumberValidation();

                var IsEmailIdValid = email_Validation.IsEmailIdValid(companyDTO.CompanyEmailID);
                var IsPhoneNumberValid = phoneNumberValidation.IsPhoneNumberValid(companyDTO.CompanyPhoneNo);

                if (IsEmailIdValid && IsPhoneNumberValid)
                {

                    using (var connection = new SqlConnection(connectionString))
                    {

                        var command = new SqlCommand
                        {
                            CommandText = $" UPDATE Companies " +
                                          $"SET  CompanyName= @CompanyName, CompanyAddress = @CompanyAddress, CompanyEmailID=@CompanyEmailID, CompanyPhoneNo=@CompanyPhoneNo " +
                                          $"WHERE CompanyID = @CompanyID",
                            Connection = connection,
                            CommandType = CommandType.Text
                        };
                        command.Parameters.AddWithValue("@CompanyName", companyDTO.CompanyName);
                        command.Parameters.AddWithValue("@CompanyAddress", companyDTO.CompanyAddress);
                        command.Parameters.AddWithValue("@CompanyEmailID", companyDTO.CompanyEmailID);
                        command.Parameters.AddWithValue("@CompanyPhoneNo", companyDTO.CompanyPhoneNo);
                        command.Parameters.AddWithValue("@CompanyID", CompanyID);
                        connection.Open();
                        command.ExecuteNonQuery();

                        connection.Close();

                    }
                }
                else
                {
                    return "Enter Valid Email or phoneNumber of Company";
                }
                return "Company Update operation Success";
            }
            catch (Exception updateException)
            {
                return updateException.Message;
            }
        }
    }
}
