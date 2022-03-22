using System;
using System.Collections.Generic;

namespace EmployeeManagementDTOs
{
    public class CompanyDTO
    {
        public int CompanyID{ get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmailID { get; set; }
        public string CompanyPhoneNo { get; set; }
        public string CompanyAddress { get; set; }
        public List<DepartmentDTO> DepartmentList { get; set; }
  
        public CompanyDTO()
        {
            DepartmentList = new List<DepartmentDTO>();
        }
    }
}
