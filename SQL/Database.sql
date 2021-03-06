USE [master]
GO
/****** Object:  Database [Raptor]    Script Date: 9/1/2016 4:34:09 PM ******/
CREATE DATABASE [Raptor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Raptor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Raptor.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Raptor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Raptor_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Raptor] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Raptor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Raptor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Raptor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Raptor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Raptor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Raptor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Raptor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Raptor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Raptor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Raptor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Raptor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Raptor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Raptor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Raptor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Raptor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Raptor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Raptor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Raptor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Raptor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Raptor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Raptor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Raptor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Raptor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Raptor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Raptor] SET  MULTI_USER 
GO
ALTER DATABASE [Raptor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Raptor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Raptor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Raptor] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Raptor] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Raptor]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 9/1/2016 4:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Filename] [varchar](255) NOT NULL,
	[Fileversion] [int] NOT NULL,
	[JSONData] [varchar](max) NOT NULL,
	[ContentTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentTypes]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_ContentTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Errors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Source] [varchar](255) NOT NULL,
	[Exception] [varchar](max) NOT NULL,
	[PlatformID] [int] NOT NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HighScores]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HighScores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[HighScore] [int] NOT NULL,
	[LevelID] [int] NOT NULL,
 CONSTRAINT [PK_HighScores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Levels]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Levels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[LevelName] [varchar](255) NOT NULL,
	[LevelDescription] [varchar](255) NOT NULL,
	[LevelData] [varchar](max) NOT NULL,
	[UserGUID] [uniqueidentifier] NOT NULL,
	[ReleaseID] [int] NOT NULL,
 CONSTRAINT [PK_Levels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Platforms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Releases]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Releases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[ReleaseNotes] [varchar](max) NOT NULL,
	[LevelFormatChange] [bit] NOT NULL,
 CONSTRAINT [PK_Releases] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebAPIRequestLog]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebAPIRequestLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[WebAPIRequestID] [int] NOT NULL,
	[UserGUID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_WebAPIRequestLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WebAPIRequests]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebAPIRequests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modified] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WebAPIRequests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ContentTypes] ON 

INSERT [dbo].[ContentTypes] ([ID], [Modified], [Created], [Active], [Description]) VALUES (1, CAST(N'2016-08-06T16:28:42.9166667+00:00' AS DateTimeOffset), CAST(N'2016-08-06T16:28:42.9166667+00:00' AS DateTimeOffset), 1, N'Level')
INSERT [dbo].[ContentTypes] ([ID], [Modified], [Created], [Active], [Description]) VALUES (2, CAST(N'2016-08-06T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'0616-08-01T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'Menu')
SET IDENTITY_INSERT [dbo].[ContentTypes] OFF
SET IDENTITY_INSERT [dbo].[WebAPIRequests] ON 

INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (1, CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), 1, N'HIGHSCORE_ADD')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (2, CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), 1, N'HIGHSCORE_GET')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (3, CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), 1, N'SERVERCONTENT_GET')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (4, CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), CAST(N'2016-08-18T00:49:23.4800000+00:00' AS DateTimeOffset), 1, N'SERVERCONTENT_PULLDOWN')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (5, CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'LEVELCREATION_UPDATE')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (6, CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'LEVELCREATION_DELETE')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (7, CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2016-08-19T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'LEVELCREATION_GET')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (8, CAST(N'2016-08-20T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2016-08-20T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'LEVELCREATION_CREATE')
INSERT [dbo].[WebAPIRequests] ([ID], [Modified], [Created], [Active], [Description]) VALUES (9, CAST(N'2016-09-01T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2016-09-01T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'LEVELCREATION_BROWSER_GET_LISTING')
SET IDENTITY_INSERT [dbo].[WebAPIRequests] OFF
ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_Content_ContentTypes] FOREIGN KEY([ContentTypeID])
REFERENCES [dbo].[ContentTypes] ([ID])
GO
ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_Content_ContentTypes]
GO
ALTER TABLE [dbo].[Errors]  WITH CHECK ADD  CONSTRAINT [FK_Errors_Platforms] FOREIGN KEY([PlatformID])
REFERENCES [dbo].[Platforms] ([ID])
GO
ALTER TABLE [dbo].[Errors] CHECK CONSTRAINT [FK_Errors_Platforms]
GO
ALTER TABLE [dbo].[HighScores]  WITH CHECK ADD  CONSTRAINT [FK_HighScores_Levels] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Levels] ([ID])
GO
ALTER TABLE [dbo].[HighScores] CHECK CONSTRAINT [FK_HighScores_Levels]
GO
ALTER TABLE [dbo].[Levels]  WITH CHECK ADD  CONSTRAINT [FK_Levels_Releases] FOREIGN KEY([ReleaseID])
REFERENCES [dbo].[Releases] ([ID])
GO
ALTER TABLE [dbo].[Levels] CHECK CONSTRAINT [FK_Levels_Releases]
GO
/****** Object:  StoredProcedure [dbo].[WEBAPI_getHighScoreListSP]    Script Date: 9/1/2016 4:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WEBAPI_getHighScoreListSP]
(@LevelID INT)
AS
	SELECT
		TOP 10 
		dbo.HighScores.Username,
		dbo.HighScores.HighScore
	FROM dbo.HighScores
	WHERE dbo.HighScores.LevelID = @LevelID AND
		dbo.HighScores.Active = 1
	ORDER BY dbo.HighScores.HighScore DESC

GO
USE [master]
GO
ALTER DATABASE [Raptor] SET  READ_WRITE 
GO
