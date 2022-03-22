using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using CompanyCRUDOperations;
using EmployeeManagementDTOs;
using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace GenerateExcelFileOperations
{
    public class GenerateXLFormat
    {
        public string GenerateXL()
        {
           

            AllCompanyInformationDisplay allCompany = new AllCompanyInformationDisplay();
            var listOfCompanies = allCompany.AllCompaniesInformationDisplay();
            string filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Company_Report.xlsx";

            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            //else
            //{
            var workbook = new XSSFWorkbook();
            var sheet = (XSSFSheet)workbook.CreateSheet("Company Details");


            int DVRowLimit = Int16.MaxValue;
            
            XSSFDataValidationHelper dvHelper = new XSSFDataValidationHelper(sheet);
            XSSFDataValidationConstraint constraint = (XSSFDataValidationConstraint)dvHelper.CreateDateConstraint(OperatorType.BETWEEN, "Date(1900,1,1)", "Date(2119,12,31)", "mm-dd-yyyy");
            CellRangeAddressList addressList = new CellRangeAddressList(1, DVRowLimit, 12, 12);
            XSSFDataValidation validation = (XSSFDataValidation)dvHelper.CreateValidation(constraint, addressList);
            validation.ShowErrorBox = true;
            validation.SuppressDropDownArrow = true;
            validation.CreateErrorBox("Error", "select correct date");
            sheet.AddValidationData(validation);

            List<string> res = new List<string>();
            foreach (var company in listOfCompanies)
            {
                foreach (var department in company.DepartmentList)
                {

                    res.Add(department.DepartmentID.ToString());
                }
            }
            var ser = res.ToArray();
            XSSFDataValidationHelper dvHelper1 = new XSSFDataValidationHelper(sheet);
            XSSFDataValidationConstraint dvConstraint = (XSSFDataValidationConstraint)
              dvHelper1.CreateExplicitListConstraint(ser);
            CellRangeAddressList addressList1 = new CellRangeAddressList(1, DVRowLimit, 0, 0);
            XSSFDataValidation validation1 = (XSSFDataValidation)dvHelper1.CreateValidation(
              dvConstraint, addressList1);
            validation1.ShowErrorBox = true;
            sheet.AddValidationData(validation1);




            var headerRow = sheet.CreateRow(0);
            
            headerRow.CreateCell(0).SetCellValue("CompanyID");
            headerRow.CreateCell(1).SetCellValue("CompanyName");
            headerRow.CreateCell(2).SetCellValue("CompanyPhoneNo");
            headerRow.CreateCell(3).SetCellValue("CompanyEmailID");
            headerRow.CreateCell(4).SetCellValue("CompanyAddress");
            headerRow.CreateCell(5).SetCellValue("DepartmentID");
            headerRow.CreateCell(6).SetCellValue("DepartmentName");
            headerRow.CreateCell(7).SetCellValue("DepartmentLead");
            headerRow.CreateCell(8).SetCellValue("DepartmentBranchAddress");
            headerRow.CreateCell(9).SetCellValue("EmployeeID");
            headerRow.CreateCell(10).SetCellValue("EmployeeName");
            headerRow.CreateCell(11).SetCellValue("EmployeeUserName");
            headerRow.CreateCell(12).SetCellValue("EmployeeJoiningDate");
            headerRow.CreateCell(13).SetCellValue("EmployeeGender");
            headerRow.CreateCell(14).SetCellValue("EmployeeEmailID");
            headerRow.CreateCell(15).SetCellValue("EmployeePhoneNo");
            headerRow.CreateCell(16).SetCellValue("EmployeeAddress");
            sheet.CreateFreezePane(0, 1, 0, 1);
            int rowNumber = 1;
           // double? data;

            foreach (var company in listOfCompanies)
            {

                var row = sheet.CreateRow(rowNumber++);


                row.CreateCell(0).SetCellValue(company.CompanyID);
                row.CreateCell(1).SetCellValue(company.CompanyName);
                row.CreateCell(2).SetCellValue(company.CompanyPhoneNo);
                row.CreateCell(3).SetCellValue(company.CompanyEmailID);
                row.CreateCell(4).SetCellValue(company.CompanyAddress);
                foreach (var department in company.DepartmentList)
                {
                    row.CreateCell(5).SetCellValue(department.DepartmentID);
                    row.CreateCell(6).SetCellValue(department.DepartmentName);
                    row.CreateCell(7).SetCellValue(department.DepartmentLead);
                    row.CreateCell(8).SetCellValue(department.DepartmentBranchAddress);

                    foreach (var employee in department.EmployeesList)
                    {
                        row.CreateCell(9).SetCellValue(employee.EmployeeID);
                        row.CreateCell(10).SetCellValue(employee.EmployeeName);
                        row.CreateCell(11).SetCellValue(employee.EmployeeUserName);
                        //data = employee.EmployeeJoiningDate as double? ?? default;
                        row.CreateCell(12).SetCellValue(employee.EmployeeJoiningDate);
                        row.CreateCell(13).SetCellValue(employee.EmployeeGender);
                        row.CreateCell(14).SetCellValue(employee.EmployeeEmailID);
                        row.CreateCell(15).SetCellValue(employee.EmployeePhoneNo);
                        row.CreateCell(16).SetCellValue(employee.EmployeeAddress);
                    }
                }
            }
            for (int column = 0; column <= 16; column++)
            {
                sheet.AutoSizeColumn(column);
            }
           
           
            //sheet.GetRow(1).GetCell(12).
           



            //XSSFWorkbook workbook1 = new XSSFWorkbook();
         
           
            //int DVRowLimit = Int16.MaxValue;
            //CellRangeAddressList joiningDataValiadtion = new CellRangeAddressList(1, DVRowLimit, 12, 12);
            //////CellRangeAddressList cellRangeFieldsType1 = new CellRangeAddressList(1, DVRowLimit, 12, 12);
            ////CT_DataValidation cT_DataValidation = new CT_DataValidation();
            ////cT_DataValidation.showDropDown = true;

            //XSSFDataValidation dataValidation=null;
            //XSSFDataValidationConstraint dvConstraint=null;
            //XSSFDataValidationHelper validationHelper= null;

            ////int DVRowLimit = (Int16.MaxValue);
            ////XSSFCellStyle numberCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            ////XSSFDataFormat numberDataFormat = (XSSFDataFormat)workbook.CreateDataFormat();
            ////numberCellStyle.SetDataFormat(numberDataFormat.GetFormat("#,###,###"));


            ////CellRangeAddressList cellRangeFieldsType1 = new CellRangeAddressList(1, DVRowLimit, headerCount, headerCount);
            ////dvConstraint = (XSSFDataValidationConstraint)validationHelper.CreateintConstraint(OperatorType.BETWEEN, "0", Int64.MaxValue.ToString());
            //dvConstraint = (XSSFDataValidationConstraint)validationHelper.CreateDateConstraint(OperatorType.BETWEEN, "=DATE(1900,1,1)", "=DATE(2119,12,31)","DD/MM/YYYY");
            //dataValidation = (XSSFDataValidation)validationHelper.CreateValidation(dvConstraint, joiningDataValiadtion);
            //dataValidation.ShowErrorBox = true;

            //dataValidation.SuppressDropDownArrow = true;
            ////dataValidation.ErrorStyle = 0;
            ////dataValidation.CreateErrorBox("InvalidValue", "Number Should be a integer.");
            ////dataValidation.ShowErrorBox = true;
            ////dataValidation.CreatePromptBox("Number Data Validation", "Enter Number.");
            ////dataValidation.ShowPromptBox = true;
            //sheet.AddValidationData(dataValidation);
            //sheet.SetDefaultColumnStyle(column, numberCellStyle);
            //XSSFDataValidationConstraint dvConstraint = workbook.CreateDateConstraint(OperatorType.BETWEEN, "=DATE(1900,1,1)", "=DATE(2119,12,31)", "mm/dd/yyyyy");
            //IDataValidation validation = new XSSFDataValidation(joiningDataValiadtion, dvConstraint, cT_DataValidation);
            //workbook.GetSheetAt(0).
            //string[] countryDV = ConfigurationManager.AppSettings["countryDV"].Split(',').Select(s => s.Trim().ToUpper()).ToArray();
            //int DVRowLimit = (Int16.MaxValue);
            //CellRangeAddressList countryDVAddList = new CellRangeAddressList(1, DVRowLimit, 0, 0);
            //var dvConstraint = (XSSFDataValidationConstraint)ValidationHelper.CreateExplicitListConstraint(countryDV);
            //// In case of Inline list values 
            //// use this approach:  dvConstraint = (XSSFDataValidationConstraint)validationHelper.CreateExplicitListConstraint(new string[] { "USA", "CANADA"});
            //dataValidation = (XSSFDataValidation)validationHelper.CreateValidation(dvConstraint, countryDVAddList);
            //dataValidation.ShowErrorBox = true;
            //dataValidation.SuppressDropDownArrow = true;
            //dataValidation.ErrorStyle = 0;
            //dataValidation.CreateErrorBox("InvalidValue", "Select Valid country.");
            //dataValidation.ShowErrorBox = true;
            //dataValidation.CreatePromptBox("country Data Validation", "Enter country.");
            //dataValidation.ShowPromptBox = true;
            //sheet.AddValidationData(dataValidation);
            //IDataValidationHelper dataValidation = new X(sheet);



            //XSSFDataValidationHelper dvHelper = new XSSFDataValidationHelper(sheet);
            //XSSFDataValidationConstraint constraint = (XSSFDataValidationConstraint)dvHelper.CreateDateConstraint(OperatorType.BETWEEN, "Date(1900,1,1)", "Date(2119,12,31)", "mm/dd/yyyy");
            //CellRangeAddressList addressList = new CellRangeAddressList(1, DVRowLimit, 12, 12);
            //XSSFDataValidation validation = (XSSFDataValidation)dvHelper.CreateValidation(constraint, addressList);
            //validation.ShowErrorBox = true;
            //validation.SuppressDropDownArrow = true;
            //validation.CreateErrorBox("Error", "select correct date");
            //sheet.AddValidationData(validation);








            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(fileStream);
                fileStream.Dispose();
            }
            //}

            return filePath;

        }
    }
}
