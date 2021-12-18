USE [master]
GO
/****** Object:  Database [WorkersOnSite2DB]    Script Date: 12/12/2021 4:54:58 PM ******/
CREATE DATABASE [WorkersOnSite2DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkersOnSite2DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkersOnSite2DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkersOnSite2DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkersOnSite2DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WorkersOnSite2DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkersOnSite2DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkersOnSite2DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkersOnSite2DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkersOnSite2DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkersOnSite2DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkersOnSite2DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkersOnSite2DB] SET  MULTI_USER 
GO
ALTER DATABASE [WorkersOnSite2DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkersOnSite2DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkersOnSite2DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkersOnSite2DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkersOnSite2DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkersOnSite2DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkersOnSite2DB', N'ON'
GO
ALTER DATABASE [WorkersOnSite2DB] SET QUERY_STORE = OFF
GO
USE [WorkersOnSite2DB]
GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 12/12/2021 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[PersonID] [uniqueidentifier] NOT NULL,
	[PersonFireBase] [nvarchar](50) NULL,
	[PersonFName] [nvarchar](50) NULL,
	[PersonMInitial] [nvarchar](50) NULL,
	[PersonLName] [nvarchar](50) NULL,
	[PersonSSN] [nvarchar](50) NULL,
	[PersonBirthday] [datetime] NULL,
	[PersonSalary] [int] NULL,
	[PersonPhoneNumber1] [nvarchar](50) NULL,
	[PersonPhoneNumber2] [nvarchar](50) NULL,
	[PersonType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONTEAM]    Script Date: 12/12/2021 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONTEAM](
	[PersonTeamID] [uniqueidentifier] NOT NULL,
	[PersonTeamPersonID] [uniqueidentifier] NOT NULL,
	[PersonTeamTeamID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonTeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SITES]    Script Date: 12/12/2021 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SITES](
	[SiteID] [uniqueidentifier] NOT NULL,
	[SiteName] [nvarchar](50) NULL,
	[SiteLocation] [nvarchar](50) NULL,
	[SiteNumber] [nvarchar](50) NULL,
	[SiteStartTime] [datetime] NULL,
	[SiteIsCompleted] [bit] NULL,
	[SitesTeamID] [uniqueidentifier] NULL,
	[SitesPersonID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEAMS]    Script Date: 12/12/2021 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEAMS](
	[TeamID] [uniqueidentifier] NOT NULL,
	[TeamName] [nvarchar](50) NULL,
	[TeamLocation] [nvarchar](50) NULL,
	[TeamPhoneNumber] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'0e11bba2-945b-ec11-8b56-5cea1db77666', N'1', N'Juan1', N'I', N'Davila', N'555555551', CAST(N'1976-07-13T00:00:00.000' AS DateTime), 60000, N'9105461061', N'9105453304', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'4f730cab-945b-ec11-8b56-5cea1db77666', N'2', N'Juan2', N'I', N'Davila', N'555555552', CAST(N'1976-07-13T00:00:00.000' AS DateTime), 60000, N'9105461061', N'9105453304', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'50730cab-945b-ec11-8b56-5cea1db77666', N'3', N'Juan3', N'I', N'Davila', N'555555553', CAST(N'1976-07-13T00:00:00.000' AS DateTime), 60000, N'9105461061', N'9105453304', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'c30df3b2-945b-ec11-8b56-5cea1db77666', N'4', N'Juan4', N'I', N'Davila', N'555555554', CAST(N'1976-07-13T00:00:00.000' AS DateTime), 60000, N'9105461061', N'9105453304', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'204ce9c2-945b-ec11-8b56-5cea1db77666', N'5', N'Danielle1', N'Y', N'Davila', N'777777771', CAST(N'1975-10-04T00:00:00.000' AS DateTime), 60000, N'9105453304', N'9105461061', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'10bc3dcc-945b-ec11-8b56-5cea1db77666', N'6', N'Danielle2', N'Y', N'Davila', N'777777772', CAST(N'1975-10-04T00:00:00.000' AS DateTime), 60000, N'9105453304', N'9105461061', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'0b0ccbd3-945b-ec11-8b56-5cea1db77666', N'7', N'Danielle3', N'Y', N'Davila', N'777777773', CAST(N'1975-10-04T00:00:00.000' AS DateTime), 60000, N'9105453304', N'9105461061', 0)
GO
INSERT [dbo].[PERSON] ([PersonID], [PersonFireBase], [PersonFName], [PersonMInitial], [PersonLName], [PersonSSN], [PersonBirthday], [PersonSalary], [PersonPhoneNumber1], [PersonPhoneNumber2], [PersonType]) VALUES (N'0c0ccbd3-945b-ec11-8b56-5cea1db77666', N'4', N'Danielle4', N'Y', N'Davila', N'777777774', CAST(N'1975-10-04T00:00:00.000' AS DateTime), 60000, N'9105453304', N'9105461061', 0)
GO
INSERT [dbo].[PERSONTEAM] ([PersonTeamID], [PersonTeamPersonID], [PersonTeamTeamID]) VALUES (N'ba25a8f5-945b-ec11-8b56-5cea1db77666', N'4f730cab-945b-ec11-8b56-5cea1db77666', N'dfdef0e1-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[PERSONTEAM] ([PersonTeamID], [PersonTeamPersonID], [PersonTeamTeamID]) VALUES (N'45be9306-955b-ec11-8b56-5cea1db77666', N'10bc3dcc-945b-ec11-8b56-5cea1db77666', N'dfdef0e1-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[PERSONTEAM] ([PersonTeamID], [PersonTeamPersonID], [PersonTeamTeamID]) VALUES (N'25a4eb12-955b-ec11-8b56-5cea1db77666', N'50730cab-945b-ec11-8b56-5cea1db77666', N'e0def0e1-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[PERSONTEAM] ([PersonTeamID], [PersonTeamPersonID], [PersonTeamTeamID]) VALUES (N'26a4eb12-955b-ec11-8b56-5cea1db77666', N'0b0ccbd3-945b-ec11-8b56-5cea1db77666', N'e0def0e1-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[SITES] ([SiteID], [SiteName], [SiteLocation], [SiteNumber], [SiteStartTime], [SiteIsCompleted], [SitesTeamID], [SitesPersonID]) VALUES (N'2ceeaf11-9c5b-ec11-8b56-5cea1db77666', N'Casa De Juan1', N'Murfressboro1', N'1', CAST(N'2022-01-01T16:37:22.140' AS DateTime), 0, NULL, N'c30df3b2-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[SITES] ([SiteID], [SiteName], [SiteLocation], [SiteNumber], [SiteStartTime], [SiteIsCompleted], [SitesTeamID], [SitesPersonID]) VALUES (N'2deeaf11-9c5b-ec11-8b56-5cea1db77666', N'Casa De Danielle1', N'Murfressboro1', N'1', CAST(N'2022-01-01T16:37:22.140' AS DateTime), 0, NULL, N'0c0ccbd3-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[SITES] ([SiteID], [SiteName], [SiteLocation], [SiteNumber], [SiteStartTime], [SiteIsCompleted], [SitesTeamID], [SitesPersonID]) VALUES (N'ae12a626-9d5b-ec11-8b56-5cea1db77666', N'Casa De Juan', N'Murfressboro', N'2', CAST(N'2022-01-01T16:45:06.803' AS DateTime), 0, N'dfdef0e1-945b-ec11-8b56-5cea1db77666', N'0e11bba2-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[SITES] ([SiteID], [SiteName], [SiteLocation], [SiteNumber], [SiteStartTime], [SiteIsCompleted], [SitesTeamID], [SitesPersonID]) VALUES (N'af12a626-9d5b-ec11-8b56-5cea1db77666', N'Casa De Danielle', N'Murfressboro', N'3', CAST(N'2022-01-01T16:45:06.803' AS DateTime), 0, N'e0def0e1-945b-ec11-8b56-5cea1db77666', N'204ce9c2-945b-ec11-8b56-5cea1db77666')
GO
INSERT [dbo].[TEAMS] ([TeamID], [TeamName], [TeamLocation], [TeamPhoneNumber]) VALUES (N'dedef0e1-945b-ec11-8b56-5cea1db77666', N'Team #1', N'Murfreesboro', N'1')
GO
INSERT [dbo].[TEAMS] ([TeamID], [TeamName], [TeamLocation], [TeamPhoneNumber]) VALUES (N'dfdef0e1-945b-ec11-8b56-5cea1db77666', N'Team #2', N'Murfreesboro2', N'2')
GO
INSERT [dbo].[TEAMS] ([TeamID], [TeamName], [TeamLocation], [TeamPhoneNumber]) VALUES (N'e0def0e1-945b-ec11-8b56-5cea1db77666', N'Team #3', N'Murfreesboro3', N'3')
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT (newsequentialid()) FOR [PersonID]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonFireBase]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonFName]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonMInitial]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonLName]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonSSN]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ((0)) FOR [PersonSalary]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonPhoneNumber1]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonPhoneNumber2]
GO
ALTER TABLE [dbo].[PERSON] ADD  DEFAULT ('') FOR [PersonType]
GO
ALTER TABLE [dbo].[PERSONTEAM] ADD  DEFAULT (newsequentialid()) FOR [PersonTeamID]
GO
ALTER TABLE [dbo].[PERSONTEAM] ADD  DEFAULT ('') FOR [PersonTeamPersonID]
GO
ALTER TABLE [dbo].[PERSONTEAM] ADD  DEFAULT ('') FOR [PersonTeamTeamID]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT (newsequentialid()) FOR [SiteID]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT ('') FOR [SiteName]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT ('') FOR [SiteLocation]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT ('') FOR [SiteNumber]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT (dateadd(month,(1),dateadd(day,( -datepart(day,getdate()))+(1),getdate()))) FOR [SiteStartTime]
GO
ALTER TABLE [dbo].[SITES] ADD  DEFAULT ((0)) FOR [SiteIsCompleted]
GO
ALTER TABLE [dbo].[TEAMS] ADD  DEFAULT (newsequentialid()) FOR [TeamID]
GO
ALTER TABLE [dbo].[TEAMS] ADD  DEFAULT ('') FOR [TeamName]
GO
ALTER TABLE [dbo].[TEAMS] ADD  DEFAULT ('') FOR [TeamLocation]
GO
ALTER TABLE [dbo].[TEAMS] ADD  DEFAULT ('') FOR [TeamPhoneNumber]
GO
ALTER TABLE [dbo].[PERSONTEAM]  WITH CHECK ADD FOREIGN KEY([PersonTeamPersonID])
REFERENCES [dbo].[PERSON] ([PersonID])
GO
ALTER TABLE [dbo].[PERSONTEAM]  WITH CHECK ADD FOREIGN KEY([PersonTeamTeamID])
REFERENCES [dbo].[TEAMS] ([TeamID])
GO
ALTER TABLE [dbo].[SITES]  WITH CHECK ADD FOREIGN KEY([SitesPersonID])
REFERENCES [dbo].[PERSON] ([PersonID])
GO
ALTER TABLE [dbo].[SITES]  WITH CHECK ADD FOREIGN KEY([SitesTeamID])
REFERENCES [dbo].[TEAMS] ([TeamID])
GO
USE [master]
GO
ALTER DATABASE [WorkersOnSite2DB] SET  READ_WRITE 
GO
