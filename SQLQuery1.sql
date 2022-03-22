--EmployeeManagementDatabase

Create Table Companies(
	CompanyID int IDENTITY(1,1) Primary key,
	CompanyName varchar(50) unique NOT NULL,
	CompanyAddress varchar(200) unique NOT NULL,
	CompanyEmailID varchar(50) unique NOT NULL,
	CompanyPhoneNo varchar(15) NOT NULL
);
--drop Table Companies;
--drop Table Departments;


Create Table Departments(
	DepartmentID int IDENTITY(1,1) Primary key,
	DepartmentName varchar(30)  NOT NULL,
	DepartmentBranchAddress varchar(200) NOT NULL,
	DepartmentLead int ,
	CompanyID int NOT NULL foreign key references Companies(CompanyID) On delete cascade on update cascade	
);



Create Table Employees(
	EmployeeID int IDENTITY(1,1) Primary key,
	EmployeeName varchar(30) NOT NULL,
	EmployeeUserName varchar(30) unique NOT NULL,
	EmployeeJoiningDate varchar(10) Not Null,
	EmployeeGender varchar(10) NOT NULL check  (EmployeeGender in ('Male','Female','male','female')) ,
	EmployeeAddress varchar(200) NOT NULL,
	EmployeePhoneNo varchar(15) NOT NULL,
	EmployeeEmailID varchar(50) Unique NOT NULL,
	DepartmentID int NOT NULL foreign key references Departments(DepartmentID) On delete cascade on update cascade,
	CompanyID int NOT NULL foreign key references Companies(CompanyID) 
);

--alter table Departments 
--add foreign key (DepartmentLead) references Employees(EmployeeID)

--insert into Companies(CompanyName,CompanyAddress,CompanyEmailID,CompanyPhoneNo) 
--values('1ivet','alsad','r@1r.com','5234567890');
--insert into Departments(DepartmentName,DepartmentBranchAddress,DepartmentLead,CompanyID) 
--values('frontend','valsad',2);
--insert into Employees(EmployeeName,EmployeeUserName,EmployeeJoiningDate,EmployeeGender,EmployeeAddress,EmployeePhoneNo,EmployeeEmailID,DepartmentID,CompanyID) 
--values('fred','fred1','2020/08/21','male','valsa','1234557989','fred@gmail.com',1,2);

--UPDATE Departments SET DepartmentLead=2 WHERE DepartmentID = 1
 
select * from Companies;
select * from Departments;
select * from Employees;
--select * from Employees where EmployeeUserName=@EmployeeUserName;

--{
--    "CompanyName":"microsoft",
--    "CompanyAddress":"usa",
--    "CompanyEmailID":"mic@g.com",
--    "CompanyPhoneNo":"+(12)-456-7-90"
--}

--{
    --"EmployeeName":"joy",
    --"EmployeeUserName":"joy1",
    --"EmployeeJoiningDate":"2000/08/06",
    --"EmployeeGender":"male",
    --"EmployeeAddress":"surat",
    --"EmployeePhoneNo":"4865629478",
    --"EmployeeEmailID":"svj@jwbu.in",
    --"DepartmentID":3,
    --"CompanyID":2
--}

--{

--    "DepartmentName":"IT",
--    "DepartmentBranchAddress":"valsad",
--    "DepartmentLead":"rujev",
--    "CompanyID":1,
--    "EmployeesList":[
--        {
--            "EmployeeName":"jopy",
--            "EmployeeUserName":"jopy1",
--            "EmployeeJoiningDate":"2000/07/06",
--            "EmployeeGender":"male",
--            "EmployeeAddress":"surat",
--            "EmployeePhoneNo":"4865628478",
--            "EmployeeEmailID":"sjj@jwbou.in",
--            "DepartmentID":1,
--            "CompanyID":1
--        },
        
--    ]
--}

--Scaffold-DbContext 'Data Source=(local);Initial Catalog=StudentCollegeDatabase;Integrated Security=sspi' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

--Students}/{action=Index}/{id?}");


--UPDATE Employees SET EmployeeName=@EmployeeName,EmployeeJoiningDate=@EmployeeJoiningDate,EmployeeGender=@EmployeeGender,EmployeeAddress=@EmployeeAddress,EmployeePhoneNo=@EmployeePhoneNo,EmployeeEmailID=@EmployeeEmailID WHERE EmployeeID=@EmployeeID

--UPDATE Companies SET  CompanyName= @CompanyName, CompanyAddress = @CompanyAddress, CompanyEmailID=@CompanyEmailID, CompanyPhoneNo=@CompanyPhoneNo WHERE CompanyID = @CompanyID

--UPDATE Departments SET DepartmentName=@DepartmentName,DepartmentBranchAddress=@DepartmentBranchAddress,DepartmentLead=@DepartmentLead,CompanyID=@CompanyID WHERE DepartmentID = @DepartmentID

--Select D.DepartmentID,D.DepartmentName,D.DepartmentBranchAddress,D.DepartmentLead,D.CompanyID,E.EmployeeName,E.EmployeeUserName,E.EmployeeJoiningDate,E.EmployeeGender,E.EmployeeAddress,E.EmployeePhoneNo,E.EmployeeEmailID  
--from Departments D   join Employees E on E.DepartmentID=D.DepartmentID where D.DepartmentID=1;

--{
--    "CompanyName":"zon",
--    "CompanyEmailID":"am@g.com",
--    "CompanyPhoneNo":"2647678932",
--    "CompanyAddress":"cfornia",
--    "DepartmentList":[
--        {
--            "DepartmentName":"aws",
--            "DepartmentBranchAddress":"surat",
--            "DepartmentLead":"hiren",
--            "EmployeesList":[
--                {
--                    "EmployeeName":"jkile",
--                    "EmployeeUserName":"kile",
--                    "EmployeeJoiningDate":"2000/02/06",
--                    "EmployeeGender":"male",
--                    "EmployeeAddress":"kuwait",
--                    "EmployeePhoneNo":"4965628478",
--                    "EmployeeEmailID":"sj4j@jwbou.in"
--                }
        
--            ]
--        }
--    ]
--}

Select C.CompanyID,C.CompanyName,C.CompanyAddress,C.CompanyEmailID,C.CompanyPhoneNo,D.DepartmentID,D.DepartmentName,D.DepartmentBranchAddress,D.DepartmentLead,D.CompanyID,E.EmployeeName,E.EmployeeUserName,E.EmployeeJoiningDate,E.EmployeeGender,E.EmployeeAddress,E.EmployeePhoneNo,E.EmployeeEmailID  
from Companies C left join Departments D on D.CompanyID=C.CompanyID  left join Employees E on E.DepartmentID=D.DepartmentID ;


--https://poi.apache.org/components/spreadsheet/quick-guide.html



--ALTER TABLE [dbo].[Student]   ADD  FOREIGN KEY([CollegeId])
--REFERENCES [dbo].[College] ([CollegeId])


insert into College(CollegeId,CollegeName) values(1,'VNSGU');
insert into Course(CourseId,CourseName) values(1,'.net');
insert into Student(StudentId,StudentName,CollegeId) values(1,'sarfaraz',1);
insert into StudentCourse(StudentCourseId,StudentId,CourseId) values(1,1,1);

