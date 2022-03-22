using EmployeeManagementDTOs;
using Moq;
using NUnit.Framework;

namespace CompanyCRUDOperations.UnitTests
{
    public class CompanyInsertOperationUnitTesting
    { 
        private  CompanyDTO service;
        
        [SetUp]
        public void Setup()
        {
           
            //insertClassObject = new Mock<CompanyInsertOperation>();
        }

        [Test]
        public void TC1_InsertCompanyDetails_IfSuccessfull_ReturnsCompanyInsertoperationSuccess()
        {
            service = new CompanyDTO()
            {
                CompanyID=10,
                CompanyName="Micros",
                CompanyAddress="surat",
                CompanyEmailID="hgh@werih.srj",
                CompanyPhoneNo="7779744678"
                //DepartmentList= new DepartmentDTO { 
                //    DepartmentID=9,
                //    DepartmentName="backend",
                //    DepartmentBranchAddress="valsad",
                //    DepartmentLead="",

                //}

            };
            Mock<CompanyInsertOperation> insertClassObject = new Mock<CompanyInsertOperation>();
            var ExpectedOutput = insertClassObject.Setup(x=>x.CompaniesInsertOperation(service)).Returns("Company Insert Operation Success");
            Assert.That(ExpectedOutput.Equals("Company Insert Operation Success"));
        }
    }
}