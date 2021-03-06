USE [master]
GO
/****** Object:  Database [EmployeeManagementDatabase]    Script Date: 2/23/2022 6:27:20 PM ******/
CREATE DATABASE [EmployeeManagementDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagementDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeManagementDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeManagementDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeManagementDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeManagementDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagementDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagementDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeManagementDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeManagementDatabase', N'ON'
GO
ALTER DATABASE [EmployeeManagementDatabase] SET QUERY_STORE = OFF
GO
USE [EmployeeManagementDatabase]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 2/23/2022 6:27:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[CompanyAddress] [varchar](200) NOT NULL,
	[CompanyEmailID] [varchar](50) NOT NULL,
	[CompanyPhoneNo] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CompanyEmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CompanyAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/23/2022 6:27:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](30) NOT NULL,
	[DepartmentBranchAddress] [varchar](200) NOT NULL,
	[DepartmentLead] [int] NULL,
	[CompanyID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/23/2022 6:27:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](30) NOT NULL,
	[EmployeeUserName] [varchar](30) NOT NULL,
	[EmployeeJoiningDate] [varchar](10) NOT NULL,
	[EmployeeGender] [varchar](10) NOT NULL,
	[EmployeeAddress] [varchar](200) NOT NULL,
	[EmployeePhoneNo] [varchar](15) NOT NULL,
	[EmployeeEmailID] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EmployeeUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EmployeeEmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD FOREIGN KEY([DepartmentLead])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD CHECK  (([EmployeeGender]='female' OR [EmployeeGender]='male' OR [EmployeeGender]='Female' OR [EmployeeGender]='Male'))
GO
USE [master]
GO
ALTER DATABASE [EmployeeManagementDatabase] SET  READ_WRITE 
GO
