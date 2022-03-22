using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementDTOs
{
    public class DepartmentDTO
    {
        public int CompanyID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentLead { get; set; }
        public string DepartmentBranchAddress { get; set; }
        
        
        public List<EmployeeDTO> EmployeesList { get; set; }
        public DepartmentDTO()
        {
            EmployeesList = new List<EmployeeDTO>();
        }
    }
}
