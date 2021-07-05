USE [master]
GO
/****** Object:  Database [SIMS]    Script Date: 7/1/2021 7:32:32 AM ******/
CREATE DATABASE [SIMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SIMS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SIMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SIMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SIMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SIMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SIMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SIMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SIMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SIMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SIMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SIMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SIMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SIMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SIMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SIMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SIMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SIMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SIMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SIMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SIMS] SET RECOVERY FULL 
GO
ALTER DATABASE [SIMS] SET  MULTI_USER 
GO
ALTER DATABASE [SIMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SIMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SIMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SIMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SIMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SIMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SIMS] SET QUERY_STORE = OFF
GO
USE [SIMS]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 7/1/2021 7:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[adminID] [varchar](9) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [numeric](9, 2) NULL,
 CONSTRAINT [PK_admins] PRIMARY KEY CLUSTERED 
(
	[adminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classDetails]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classDetails](
	[classID] [varchar](9) NOT NULL,
	[studentID] [varchar](9) NOT NULL,
 CONSTRAINT [PK_classDetails] PRIMARY KEY CLUSTERED 
(
	[classID] ASC,
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[classID] [varchar](9) NOT NULL,
	[courseID] [varchar](6) NULL,
	[teacherID] [varchar](9) NULL,
	[numOfStudent] [int] NULL,
 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED 
(
	[classID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[courseID] [varchar](6) NOT NULL,
	[name] [varchar](100) NULL,
	[fee] [real] NULL,
 CONSTRAINT [PK_courses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedbacks]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedbacks](
	[studentID] [varchar](9) NOT NULL,
	[teacherID] [varchar](9) NOT NULL,
	[feedback] [text] NULL,
 CONSTRAINT [PK_feedbacks] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC,
	[teacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grades]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grades](
	[studentID] [varchar](9) NOT NULL,
	[courseID] [varchar](6) NULL,
	[componentGrade] [float] NULL,
	[component] [varchar](50) NULL,
 CONSTRAINT [PK_schedules] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parents]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parents](
	[studentID] [varchar](9) NOT NULL,
	[email] [varchar](50) NULL,
	[phone] [numeric](9, 2) NULL,
	[balance] [real] NULL,
 CONSTRAINT [PK_parent] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[studentID] [varchar](9) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [varchar](255) NULL,
	[email] [varchar](50) NULL,
	[parentsPhone] [numeric](9, 2) NULL,
	[dob] [date] NULL,
	[avatar] [varchar](50) NULL,
	[gpa] [float] NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teachers]    Script Date: 7/1/2021 7:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachers](
	[teacherID] [varchar](9) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [numeric](9, 2) NULL,
	[faculty] [varchar](255) NULL,
 CONSTRAINT [PK_teachers] PRIMARY KEY CLUSTERED 
(
	[teacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[admins] ([adminID], [name], [email], [phone]) VALUES (N'AD0', N'Nguyễn Tuấn Anh', N'anhntse150633@fpt.edu.vn', CAST(123456.00 AS Numeric(9, 2)))
GO
INSERT [dbo].[classDetails] ([classID], [studentID]) VALUES (N'SE1501', N'ST0')
GO
INSERT [dbo].[classes] ([classID], [courseID], [teacherID], [numOfStudent]) VALUES (N'SE1501', N'PRN192', N'TE0', 30)
GO
INSERT [dbo].[courses] ([courseID], [name], [fee]) VALUES (N'PRN192', N'C# Programming', 5000)
GO
INSERT [dbo].[feedbacks] ([studentID], [teacherID], [feedback]) VALUES (N'ST0', N'TE0', N'Well behave!')
GO
INSERT [dbo].[grades] ([studentID], [courseID], [componentGrade], [component]) VALUES (N'ST0', N'PRN192', 10, N'FE')
GO
INSERT [dbo].[parents] ([studentID], [email], [phone], [balance]) VALUES (N'ST0', NULL, CAST(123456.00 AS Numeric(9, 2)), 10000)
GO
INSERT [dbo].[students] ([studentID], [name], [address], [email], [parentsPhone], [dob], [avatar], [gpa]) VALUES (N'ST0', N'Nguyễn Trường Giang', N'nowhere', N'giangntse150746@fpt.edu.vn', CAST(123456.00 AS Numeric(9, 2)), CAST(N'2001-01-01' AS Date), N'giangnt', 10)
GO
INSERT [dbo].[teachers] ([teacherID], [name], [email], [phone], [faculty]) VALUES (N'TE0', N'Nguyễn Gia Bảo', N'	baongse150657@fpt.edu.vn', CAST(2345678.00 AS Numeric(9, 2)), N'SE')
GO
ALTER TABLE [dbo].[classDetails]  WITH CHECK ADD  CONSTRAINT [FK_classDetails_classes] FOREIGN KEY([classID])
REFERENCES [dbo].[classes] ([classID])
GO
ALTER TABLE [dbo].[classDetails] CHECK CONSTRAINT [FK_classDetails_classes]
GO
ALTER TABLE [dbo].[classDetails]  WITH CHECK ADD  CONSTRAINT [FK_classDetails_students] FOREIGN KEY([studentID])
REFERENCES [dbo].[students] ([studentID])
GO
ALTER TABLE [dbo].[classDetails] CHECK CONSTRAINT [FK_classDetails_students]
GO
ALTER TABLE [dbo].[classes]  WITH CHECK ADD  CONSTRAINT [FK_classes_courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[courses] ([courseID])
GO
ALTER TABLE [dbo].[classes] CHECK CONSTRAINT [FK_classes_courses]
GO
ALTER TABLE [dbo].[classes]  WITH CHECK ADD  CONSTRAINT [FK_classes_teachers] FOREIGN KEY([teacherID])
REFERENCES [dbo].[teachers] ([teacherID])
GO
ALTER TABLE [dbo].[classes] CHECK CONSTRAINT [FK_classes_teachers]
GO
ALTER TABLE [dbo].[feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_feedbacks_students] FOREIGN KEY([studentID])
REFERENCES [dbo].[students] ([studentID])
GO
ALTER TABLE [dbo].[feedbacks] CHECK CONSTRAINT [FK_feedbacks_students]
GO
ALTER TABLE [dbo].[feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_feedbacks_teachers] FOREIGN KEY([teacherID])
REFERENCES [dbo].[teachers] ([teacherID])
GO
ALTER TABLE [dbo].[feedbacks] CHECK CONSTRAINT [FK_feedbacks_teachers]
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[courses] ([courseID])
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_courses]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_grades] FOREIGN KEY([studentID])
REFERENCES [dbo].[grades] ([studentID])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_grades]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_parents] FOREIGN KEY([studentID])
REFERENCES [dbo].[parents] ([studentID])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_parents]
GO
USE [master]
GO
ALTER DATABASE [SIMS] SET  READ_WRITE 
GO
