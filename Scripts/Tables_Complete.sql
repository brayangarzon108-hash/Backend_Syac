USE [master]
GO
/****** Object:  Database [StudentRegistrationDB]    Script Date: 1/02/2026 7:08:13 p. m. ******/
CREATE DATABASE [StudentRegistrationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentRegistrationDB', FILENAME = N'C:\Users\BRYAM CAMILO\StudentRegistrationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentRegistrationDB_log', FILENAME = N'C:\Users\BRYAM CAMILO\StudentRegistrationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StudentRegistrationDB] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentRegistrationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentRegistrationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentRegistrationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentRegistrationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentRegistrationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentRegistrationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentRegistrationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentRegistrationDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentRegistrationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentRegistrationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentRegistrationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentRegistrationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentRegistrationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StudentRegistrationDB] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [StudentRegistrationDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StudentRegistrationDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StudentRegistrationDB]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 1/02/2026 7:08:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programs]    Script Date: 1/02/2026 7:08:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programs](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TotalCredits] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/02/2026 7:08:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[ProgramId] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubjects]    Script Date: 1/02/2026 7:08:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubjects](
	[StudentSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/02/2026 7:08:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Professors] ON 
GO
INSERT [dbo].[Professors] ([ProfessorId], [FullName], [CreatedAt], [UpdateAt]) VALUES (1, N'Profesor 1', CAST(N'2026-01-29T13:24:03.517' AS DateTime), CAST(N'2026-01-29T13:24:03.517' AS DateTime))
GO
INSERT [dbo].[Professors] ([ProfessorId], [FullName], [CreatedAt], [UpdateAt]) VALUES (2, N'Profesor 2', CAST(N'2026-01-29T13:24:03.517' AS DateTime), CAST(N'2026-01-29T13:24:03.517' AS DateTime))
GO
INSERT [dbo].[Professors] ([ProfessorId], [FullName], [CreatedAt], [UpdateAt]) VALUES (3, N'Profesor 3', CAST(N'2026-01-29T13:24:03.517' AS DateTime), CAST(N'2026-01-29T13:24:03.517' AS DateTime))
GO
INSERT [dbo].[Professors] ([ProfessorId], [FullName], [CreatedAt], [UpdateAt]) VALUES (4, N'Profesor 4', CAST(N'2026-01-29T13:24:03.517' AS DateTime), CAST(N'2026-01-29T13:24:03.517' AS DateTime))
GO
INSERT [dbo].[Professors] ([ProfessorId], [FullName], [CreatedAt], [UpdateAt]) VALUES (5, N'Profesor 5', CAST(N'2026-01-29T13:24:03.517' AS DateTime), CAST(N'2026-01-29T13:24:03.517' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Professors] OFF
GO
SET IDENTITY_INSERT [dbo].[Programs] ON 
GO
INSERT [dbo].[Programs] ([ProgramId], [Name], [TotalCredits], [CreatedAt], [UpdateAt]) VALUES (1, N'Ingeniero de Sistemas', 9, CAST(N'2026-01-29T18:41:25.023' AS DateTime), CAST(N'2026-01-29T18:41:25.023' AS DateTime))
GO
INSERT [dbo].[Programs] ([ProgramId], [Name], [TotalCredits], [CreatedAt], [UpdateAt]) VALUES (2, N'Ingeniero Electrónico', 9, CAST(N'2026-01-29T18:41:25.023' AS DateTime), CAST(N'2026-01-29T18:41:25.023' AS DateTime))
GO
INSERT [dbo].[Programs] ([ProgramId], [Name], [TotalCredits], [CreatedAt], [UpdateAt]) VALUES (3, N'Ingeniero Mecatrónico', 9, CAST(N'2026-01-29T18:41:25.023' AS DateTime), CAST(N'2026-01-29T18:41:25.023' AS DateTime))
GO
INSERT [dbo].[Programs] ([ProgramId], [Name], [TotalCredits], [CreatedAt], [UpdateAt]) VALUES (5, N'Ingeniero Industrial', 9, CAST(N'2026-01-29T18:41:25.023' AS DateTime), CAST(N'2026-01-29T18:41:25.023' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Programs] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (1, N'Bryam Garcia Jimenez', N'brayangarzon108@gmail.com', 5, CAST(N'2026-01-29T23:55:16.350' AS DateTime), CAST(N'2026-01-29T23:55:16.350' AS DateTime))
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (2, N'Diana Gomez', N'dgomez@grupoj.com.co', 2, CAST(N'2026-01-30T00:05:47.087' AS DateTime), CAST(N'2026-01-30T00:05:47.087' AS DateTime))
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (3, N'Camilo Garzon', N'', 2, CAST(N'2026-02-01T04:35:06.373' AS DateTime), CAST(N'2026-02-01T04:35:06.373' AS DateTime))
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (4, N'Catalina Jimenez', N'prueba@gmail.com', 3, CAST(N'2026-02-01T04:43:03.497' AS DateTime), CAST(N'2026-02-01T04:43:03.497' AS DateTime))
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (5, N'Claudia Jimenez Quesada', N'claupatri@gmail.com', 1, CAST(N'2026-02-01T23:51:50.993' AS DateTime), CAST(N'2026-02-01T23:51:50.993' AS DateTime))
GO
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [ProgramId], [CreatedAt], [UpdateAt]) VALUES (6, N'Catalina', N'wual2205@gmail.com', 5, CAST(N'2026-02-01T23:54:36.163' AS DateTime), CAST(N'2026-02-01T23:54:36.163' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentSubjects] ON 
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (2, 4, 4, CAST(N'2026-02-01T11:49:20.157' AS DateTime), CAST(N'2026-02-01T11:49:20.157' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (4, 2, 9, CAST(N'2026-02-01T11:52:09.673' AS DateTime), CAST(N'2026-02-01T11:52:09.673' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (5, 3, 1, CAST(N'2026-02-01T13:47:51.913' AS DateTime), CAST(N'2026-02-01T13:47:51.913' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (6, 3, 3, CAST(N'2026-02-01T13:49:21.427' AS DateTime), CAST(N'2026-02-01T13:49:21.427' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (7, 2, 1, CAST(N'2026-02-01T14:27:07.623' AS DateTime), CAST(N'2026-02-01T14:27:07.623' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (10, 1, 1, CAST(N'2026-02-01T18:21:48.480' AS DateTime), CAST(N'2026-02-01T18:21:48.480' AS DateTime))
GO
INSERT [dbo].[StudentSubjects] ([StudentSubjectId], [StudentId], [SubjectId], [CreatedAt], [UpdateAt]) VALUES (11, 2, 8, CAST(N'2026-02-01T18:38:11.813' AS DateTime), CAST(N'2026-02-01T18:38:11.813' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[StudentSubjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (1, N'Matemáticas I', 3, 1, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (2, N'Matemáticas II', 3, 1, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (3, N'Física I', 3, 2, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (4, N'Física II', 3, 2, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (5, N'Química I', 3, 3, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (6, N'Química II', 3, 3, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (7, N'Programación I', 3, 4, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (8, N'Programación II', 3, 4, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (9, N'Bases de Datos', 3, 5, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
INSERT [dbo].[Subjects] ([SubjectId], [Name], [Credits], [ProfessorId], [CreatedAt], [UpdateAt]) VALUES (10, N'Redes', 3, 5, CAST(N'2026-01-29T13:24:03.530' AS DateTime), CAST(N'2026-01-29T13:24:03.530' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Students__A9D10534F50DF586]    Script Date: 1/02/2026 7:08:14 p. m. ******/
ALTER TABLE [dbo].[Students] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Student_Subject]    Script Date: 1/02/2026 7:08:14 p. m. ******/
ALTER TABLE [dbo].[StudentSubjects] ADD  CONSTRAINT [UQ_Student_Subject] UNIQUE NONCLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Professors] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Professors] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Programs] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Programs] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[StudentSubjects] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[StudentSubjects] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ((3)) FOR [Credits]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Programs] ([ProgramId])
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
USE [master]
GO
ALTER DATABASE [StudentRegistrationDB] SET  READ_WRITE 
GO
