using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagementDTOs
{
    public class EmployeeDTO
    {
        
        public int EmployeeID { get; set; }
        public int CompanyID { get; set; }
        public int DepartmentID { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeUserName { get; set; }

        public string EmployeeGender { get; set; }


        public string EmployeeJoiningDate { get; set; }
        public string EmployeeEmailID { get; set; }
        public string EmployeePhoneNo { get; set; }
        public string EmployeeAddress { get; set; }
        
        
        
        
    }
}
