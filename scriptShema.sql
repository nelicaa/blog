USE [master]
GO
/****** Object:  Database [projekat]    Script Date: 6/13/2022 18:05:30 ******/
CREATE DATABASE [projekat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projekat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\projekat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projekat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\projekat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [projekat] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projekat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projekat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projekat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projekat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projekat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projekat] SET ARITHABORT OFF 
GO
ALTER DATABASE [projekat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [projekat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projekat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projekat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projekat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projekat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projekat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projekat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projekat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projekat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [projekat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projekat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projekat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projekat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projekat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projekat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projekat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projekat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [projekat] SET  MULTI_USER 
GO
ALTER DATABASE [projekat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projekat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projekat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projekat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projekat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [projekat] SET QUERY_STORE = OFF
GO
USE [projekat]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[Comment] [nvarchar](250) NOT NULL,
	[Rate] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
	[PostId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](25) NOT NULL,
	[Text] [nvarchar](250) NOT NULL,
	[MainPic] [nvarchar](250) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTags]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTags](
	[PostId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_PostTags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](45) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UseCaseName] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[Identity] [nvarchar](max) NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](20) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCase]    Script Date: 6/13/2022 18:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCase](
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCase] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220601181842_Initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220606131841_Novo', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220606141037_Initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220606181958_novo', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220607114127_novije', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220607114445_najnovije', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220608111555_zaSliku', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220608111816_zaSlikunovo', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (10, N'Nauka', CAST(N'2022-06-11T10:36:40.3077668' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (11, N'Zabava', CAST(N'2022-06-11T10:36:45.2734281' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (12, N'IT oblast', CAST(N'2022-06-11T10:37:15.4454281' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [UserId], [PostId], [Comment], [Rate], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (10, 15, 34, N'Komentar za post.', 5, CAST(N'2022-06-11T10:47:22.1144670' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [PostId], [Comment], [Rate], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (11, 15, 33, N'Komentardrugi  za post.', 1, CAST(N'2022-06-11T10:47:31.6665912' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [PostId], [Comment], [Rate], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (12, 12, 33, N'Komentar treci  za post.', 3, CAST(N'2022-06-11T10:47:40.1554652' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [PostId], [Comment], [Rate], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (13, 12, 34, N'Komentar cetvrti  za post.', 3, CAST(N'2022-06-11T10:48:08.4360284' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [PostId], [Comment], [Rate], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (14, 15, 34, N'Komentar peti  za post.', 4, CAST(N'2022-06-11T10:48:27.0504624' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (21, N'299a7be2-bb97-42ec-8af6-5c5432a77b21.jpg', 32, CAST(N'2022-06-11T10:42:36.2042019' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (22, N'2566757a-c9c3-4f5f-a155-762f1b2c4bcf.jpg', 32, CAST(N'2022-06-11T10:42:36.2042021' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (23, N'328ae1fd-2df1-4d8c-be3c-90afb8126beb.jpg', 32, CAST(N'2022-06-11T10:42:36.2042023' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (24, N'9d345371-0986-4936-a07e-1be0581250bd.jpg', 32, CAST(N'2022-06-11T10:42:36.2042025' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (25, N'4865de62-7c69-4fde-a830-e0a52c3b83cb.jpg', 33, CAST(N'2022-06-11T10:43:02.0906482' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Image], [PostId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (26, N'666715ca-d4dc-446e-9340-ed685e5d12be.jpg', 34, CAST(N'2022-06-11T10:43:49.0726718' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (32, 12)
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (33, 12)
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (34, 12)
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (34, 13)
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (34, 14)
INSERT [dbo].[Likes] ([PostId], [UserId]) VALUES (34, 15)
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Text], [MainPic], [UserId], [CategoryId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (32, N'Prvi post', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', N'402b2d36-3438-4ade-b4af-c7ec55804dce.jpg', 13, 11, CAST(N'2022-06-11T10:42:36.2041994' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [MainPic], [UserId], [CategoryId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (33, N'Drugi post', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', N'518082b6-c152-4351-9ba6-c9f01f6e5fac.jpg', 12, 10, CAST(N'2022-06-11T10:43:02.0906473' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [Text], [MainPic], [UserId], [CategoryId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (34, N'Treci post', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', N'2cd8a357-1a67-43e4-8f7f-992c03620844.jpg', 12, 10, CAST(N'2022-06-11T10:43:49.0726708' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
INSERT [dbo].[PostTags] ([PostId], [TagId]) VALUES (32, 14)
INSERT [dbo].[PostTags] ([PostId], [TagId]) VALUES (32, 16)
INSERT [dbo].[PostTags] ([PostId], [TagId]) VALUES (33, 17)
INSERT [dbo].[PostTags] ([PostId], [TagId]) VALUES (34, 18)
INSERT [dbo].[PostTags] ([PostId], [TagId]) VALUES (34, 19)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'User', CAST(N'2022-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Admin', CAST(N'2022-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'test', CAST(N'2022-06-05T10:53:03.4764496' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (14, N'Pozitivno', CAST(N'2022-06-11T10:38:56.5793243' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (15, N'Negativno', CAST(N'2022-06-11T10:39:01.7763282' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (16, N'Neocekivano', CAST(N'2022-06-11T10:39:07.6827937' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (17, N'Ocekivano', CAST(N'2022-06-11T10:39:11.5303230' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (18, N'Iznenadjujuce', CAST(N'2022-06-11T10:39:17.3770977' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (19, N'Vedro', CAST(N'2022-06-11T10:39:24.0725052' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [Name], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (20, N'Tuzno', CAST(N'2022-06-11T10:39:35.5802721' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (367, CAST(N'2022-06-11T12:26:05.4593253' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Nelica","LastName":"Stojadinovic","Username":"nelka2","Email":"nelica@gmail.com","Password":"Sifra2*","Active":false,"RoleId":2}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (368, CAST(N'2022-06-11T12:26:19.7904637' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Nelica","LastName":"Stojadinovic","Username":"nelka2","Email":"nelica@gmail.com","Password":"Sifra123*","Active":false,"RoleId":2}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (369, CAST(N'2022-06-11T12:27:23.2455864' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Milica","LastName":"Mikic","Username":"mica54","Email":"mica@gmail.com","Password":"Sifra123*","Active":false,"RoleId":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (370, CAST(N'2022-06-11T12:27:40.0637577' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Petar","LastName":"Petrovic","Username":"peca","Email":"peca@gmail.com","Password":"Sifra123*","Active":false,"RoleId":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (371, CAST(N'2022-06-11T12:28:03.6743612' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Petar","LastName":"Petrovic","Username":"peca","Email":"peca@gmail.com","Password":"Sifra123*","Active":false,"RoleId":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (372, CAST(N'2022-06-11T12:28:22.8877828' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Milica","LastName":"Mikic","Username":"mica54","Email":"mica@gmail.com","Password":"Sifra123*","Active":false,"RoleId":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (373, CAST(N'2022-06-11T12:28:49.8466012' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Nelica","LastName":"Stojadinovic","Username":"nelka2","Email":"nelica@gmail.com","Password":"Sifra123*","Active":false,"RoleId":2}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (374, CAST(N'2022-06-11T12:32:22.3829394' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Mika","LastName":"Mikic","Username":"mika","Email":"mika@gmail.com","Password":"Sifra123*","Active":false,"RoleId":2}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (375, CAST(N'2022-06-11T12:33:07.1332006' AS DateTime2), N'Register user', N'{"Id":0,"FirstName":"Mika","LastName":"Mikic","Username":"mika","Email":"mika@gmail.com","Password":"Sifra123*","Active":false,"RoleId":2}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (376, CAST(N'2022-06-11T12:33:30.8225569' AS DateTime2), N'Edit usera', N'{"Id":3,"FirstName":null,"LastName":null,"Username":null,"Email":null,"Password":null,"Active":false,"RoleId":2}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (377, CAST(N'2022-06-11T12:33:43.2179978' AS DateTime2), N'Edit usera', N'{"Id":14,"FirstName":null,"LastName":null,"Username":null,"Email":null,"Password":null,"Active":false,"RoleId":2}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (378, CAST(N'2022-06-11T12:34:17.0129344' AS DateTime2), N'Edit usera', N'{"Id":14,"FirstName":null,"LastName":null,"Username":null,"Email":null,"Password":null,"Active":false,"RoleId":1}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (379, CAST(N'2022-06-11T12:34:22.2978070' AS DateTime2), N'Edit usera', N'{"Id":14,"FirstName":null,"LastName":null,"Username":null,"Email":null,"Password":null,"Active":false,"RoleId":2}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (380, CAST(N'2022-06-11T12:34:43.0161362' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"Kultura"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (381, CAST(N'2022-06-11T12:34:50.0526956' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"Obrazovanje"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (382, CAST(N'2022-06-11T12:34:54.3514266' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"Zabava"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (383, CAST(N'2022-06-11T12:36:40.2846472' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"Nauka"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (384, CAST(N'2022-06-11T12:36:45.2315348' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"Zabava"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (385, CAST(N'2022-06-11T12:36:55.9126235' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"IT"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (386, CAST(N'2022-06-11T12:37:15.4106510' AS DateTime2), N'Create new category', N'{"Id":0,"Name":"IT oblast"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (387, CAST(N'2022-06-11T12:38:56.5046705' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Pozitivno"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (388, CAST(N'2022-06-11T12:39:01.7677563' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Negativno"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (389, CAST(N'2022-06-11T12:39:07.6449941' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Neocekivano"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (390, CAST(N'2022-06-11T12:39:11.5229731' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Ocekivano"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (391, CAST(N'2022-06-11T12:39:17.3703808' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Iznenadjujuce"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (392, CAST(N'2022-06-11T12:39:24.0646322' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Vedro"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (393, CAST(N'2022-06-11T12:39:35.5359159' AS DateTime2), N'Create new tag', N'{"Id":0,"Name":"Tuzno"}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (394, CAST(N'2022-06-11T12:42:09.8622497' AS DateTime2), N'Create new post', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"Image","FileName":"prostor3.jpg"},"ImagesUpload":[{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"nova.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"nova.jpg\""],"Content-Type":["image/jpeg"]},"Length":745211,"Name":"ImagesUpload","FileName":"nova.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor1.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor1.jpg\""],"Content-Type":["image/jpeg"]},"Length":745211,"Name":"ImagesUpload","FileName":"prostor1.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\""],"Content-Type":["image/jpeg"]},"Length":649745,"Name":"ImagesUpload","FileName":"prostor2.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"ImagesUpload","FileName":"prostor3.jpg"}],"Id":0,"Title":"Prvi post","Text":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.","MainPic":"a4c05676-b8c0-4dc8-82ee-05c07238e482.jpg","UserId":13,"CategoryId":15,"Images":["468cf546-9eb0-49eb-8d0f-ca28ee91b063.jpg","b74453cf-98d1-4852-aaa2-df4f091288b8.jpg","0a369e73-db40-469f-8d8a-8fbd83161c46.jpg","b2d97ab6-7ca5-4960-ab7a-947540507d7e.jpg"],"PostTag":[14,16]}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (395, CAST(N'2022-06-11T12:42:36.0906372' AS DateTime2), N'Create new post', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"Image","FileName":"prostor3.jpg"},"ImagesUpload":[{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"nova.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"nova.jpg\""],"Content-Type":["image/jpeg"]},"Length":745211,"Name":"ImagesUpload","FileName":"nova.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor1.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor1.jpg\""],"Content-Type":["image/jpeg"]},"Length":745211,"Name":"ImagesUpload","FileName":"prostor1.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\""],"Content-Type":["image/jpeg"]},"Length":649745,"Name":"ImagesUpload","FileName":"prostor2.jpg"},{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"ImagesUpload","FileName":"prostor3.jpg"}],"Id":0,"Title":"Prvi post","Text":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.","MainPic":"402b2d36-3438-4ade-b4af-c7ec55804dce.jpg","UserId":13,"CategoryId":11,"Images":["299a7be2-bb97-42ec-8af6-5c5432a77b21.jpg","2566757a-c9c3-4f5f-a155-762f1b2c4bcf.jpg","328ae1fd-2df1-4d8c-be3c-90afb8126beb.jpg","9d345371-0986-4936-a07e-1be0581250bd.jpg"],"PostTag":[14,16]}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (396, CAST(N'2022-06-11T12:43:02.0799501' AS DateTime2), N'Create new post', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"Image","FileName":"prostor3.jpg"},"ImagesUpload":[{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\""],"Content-Type":["image/jpeg"]},"Length":649745,"Name":"ImagesUpload","FileName":"prostor2.jpg"}],"Id":0,"Title":"Drugi post","Text":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.","MainPic":"518082b6-c152-4351-9ba6-c9f01f6e5fac.jpg","UserId":12,"CategoryId":10,"Images":["4865de62-7c69-4fde-a830-e0a52c3b83cb.jpg"],"PostTag":[17]}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (397, CAST(N'2022-06-11T12:43:28.5005215' AS DateTime2), N'Create new post', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"Image","FileName":"prostor3.jpg"},"ImagesUpload":[{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\""],"Content-Type":["image/jpeg"]},"Length":649745,"Name":"ImagesUpload","FileName":"prostor2.jpg"}],"Id":0,"Title":"Treci post","Text":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.","MainPic":"5258c55a-f6b6-4cab-96a4-f937063abd89.jpg","UserId":12,"CategoryId":13,"Images":["6b446f79-12b0-485e-89c9-4589d637a8e9.jpg"],"PostTag":[18,19]}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (398, CAST(N'2022-06-11T12:43:49.0415616' AS DateTime2), N'Create new post', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"prostor3.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"prostor3.jpg\""],"Content-Type":["image/jpeg"]},"Length":310435,"Name":"Image","FileName":"prostor3.jpg"},"ImagesUpload":[{"ContentDisposition":"form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImagesUpload\"; filename=\"prostor2.jpg\""],"Content-Type":["image/jpeg"]},"Length":649745,"Name":"ImagesUpload","FileName":"prostor2.jpg"}],"Id":0,"Title":"Treci post","Text":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.","MainPic":"2cd8a357-1a67-43e4-8f7f-992c03620844.jpg","UserId":12,"CategoryId":10,"Images":["666715ca-d4dc-446e-9340-ed685e5d12be.jpg"],"PostTag":[18,19]}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (399, CAST(N'2022-06-11T12:45:20.6942337' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":12,"PostId":32}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (400, CAST(N'2022-06-11T12:45:24.3307725' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":12,"PostId":33}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (401, CAST(N'2022-06-11T12:45:28.1440721' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":12,"PostId":34}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (402, CAST(N'2022-06-11T12:45:32.1892370' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":13,"PostId":34}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (403, CAST(N'2022-06-11T12:45:35.6960530' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":14,"PostId":34}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (404, CAST(N'2022-06-11T12:45:41.5468261' AS DateTime2), N'Like for post.', N'{"User":null,"UserId":15,"PostId":34}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (405, CAST(N'2022-06-11T12:46:13.9678825' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":34,"UserId":15,"User":null,"Comment":"Komentar za post.","Rate":0}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (406, CAST(N'2022-06-11T12:47:22.0837654' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":34,"UserId":15,"User":null,"Comment":"Komentar za post.","Rate":5}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (407, CAST(N'2022-06-11T12:47:31.6197076' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":33,"UserId":15,"User":null,"Comment":"Komentardrugi  za post.","Rate":1}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (408, CAST(N'2022-06-11T12:47:40.1148254' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":33,"UserId":12,"User":null,"Comment":"Komentar treci  za post.","Rate":3}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (409, CAST(N'2022-06-11T12:47:46.3856323' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":31,"UserId":12,"User":null,"Comment":"Komentar cetvrti  za post.","Rate":3}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (410, CAST(N'2022-06-11T12:48:08.4241414' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":34,"UserId":12,"User":null,"Comment":"Komentar cetvrti  za post.","Rate":3}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (411, CAST(N'2022-06-11T12:48:16.6683760' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":34,"UserId":11,"User":null,"Comment":"Komentar peti  za post.","Rate":4}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (412, CAST(N'2022-06-11T12:48:27.0130345' AS DateTime2), N'Create comment', N'{"Id":0,"TitlePost":null,"PostId":34,"UserId":15,"User":null,"Comment":"Komentar peti  za post.","Rate":4}', N'mika@gmail.com')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (413, CAST(N'2022-06-11T12:48:34.8576262' AS DateTime2), N'Get all users and search them', N'{"Keyword":null,"PerPage":10,"Page":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (414, CAST(N'2022-06-11T12:48:50.3540621' AS DateTime2), N'Get all posts.', N'{"CreatedAtFrom":null,"CreatedAtTo":null,"NumberOfLikesGreater":null,"NumberOfLikesLower":null,"CategoriesList":[],"TagsList":[],"Keyword":null,"PerPage":10,"Page":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (415, CAST(N'2022-06-11T12:50:23.9674528' AS DateTime2), N'Get all categories.', N'{"Keyword":null,"PerPage":10,"Page":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (416, CAST(N'2022-06-11T12:50:27.2331806' AS DateTime2), N'Get roles', N'{"Keyword":null,"PerPage":10,"Page":1}', N'Anonymous')
INSERT [dbo].[UseCaseLogs] ([Id], [CreatedAt], [UseCaseName], [Data], [Identity]) VALUES (417, CAST(N'2022-06-11T12:50:35.3882086' AS DateTime2), N'Get all tags', N'{"Keyword":null,"PerPage":10,"Page":1}', N'Anonymous')
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [Active], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (12, N'Petar', N'Petrovic', N'peca', N'peca@gmail.com', N'$2a$11$mqiGHlrmB9mG2iiPPuPtBeGn0MlHhH6.hJEUZlwkv.JYmIqb/crSm', 1, 1, CAST(N'2022-06-11T10:28:03.8772318' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [Active], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (13, N'Milica', N'Mikic', N'mica54', N'mica@gmail.com', N'$2a$11$FTXljRibfsh9RAffv4qIn.BYKM35yZ337zuPd9sbjJl7HWOLrjuJ6', 1, 1, CAST(N'2022-06-11T10:28:23.0816551' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [Active], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (14, N'Nelica', N'Stojadinovic', N'nelka2', N'nelica@gmail.com', N'$2a$11$vQuu6Qw4mrtWSt7lw2oN7u8vsv9k2YfCK3tBGo6XLlCL3NVVErdMC', 1, 2, CAST(N'2022-06-11T10:28:50.0645235' AS DateTime2), NULL, NULL, CAST(N'2022-06-11T10:34:22.3367672' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [Active], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (15, N'Mika', N'Mikic', N'mika', N'mika@gmail.com', N'$2a$11$o9YDVwrenREqkSP3aF.uFe60cXOuSon2ugwPL5mr5vQgjlNLDgULC', 1, 2, CAST(N'2022-06-11T10:32:24.6684152' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 1)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 2)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 3)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 4)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 5)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 6)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 7)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 8)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 9)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 10)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 11)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 12)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 13)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 14)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 15)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 16)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 17)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 18)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 19)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 20)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 21)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 22)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 23)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 24)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 25)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 26)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 27)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (14, 28)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 1)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 2)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 3)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 4)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 5)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 6)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 7)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 8)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 9)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 10)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 11)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 12)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 13)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 14)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 15)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 16)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 17)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 18)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 19)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 20)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 21)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 22)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 23)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 24)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 25)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 26)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 27)
INSERT [dbo].[UserUseCase] ([UserId], [UseCaseId]) VALUES (15, 28)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 6/13/2022 18:05:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_PostId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_PostId] ON [dbo].[Comments]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_PostId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Images_PostId] ON [dbo].[Images]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Likes_PostId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Likes_PostId] ON [dbo].[Likes]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_CategoryId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Posts_CategoryId] ON [dbo].[Posts]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Posts_Title]    Script Date: 6/13/2022 18:05:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Posts_Title] ON [dbo].[Posts]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_UserId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Posts_UserId] ON [dbo].[Posts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PostTags_PostId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_PostTags_PostId] ON [dbo].[PostTags]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tags_Name]    Script Date: 6/13/2022 18:05:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_Name] ON [dbo].[Tags]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/13/2022 18:05:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_FirstName]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Users_FirstName] ON [dbo].[Users]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_LastName]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Users_LastName] ON [dbo].[Users]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/13/2022 18:05:31 ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 6/13/2022 18:05:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_PostId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Posts_PostId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Posts_PostId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Users_UserId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTags_Posts_PostId]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserUseCase]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCase_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCase] CHECK CONSTRAINT [FK_UserUseCase_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [projekat] SET  READ_WRITE 
GO
