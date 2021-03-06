USE [BazaZZadatak2]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/29/2020 8:55:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ispit]    Script Date: 12/29/2020 8:55:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ispit](
	[BI] [int] NOT NULL,
	[PredmetId] [int] NOT NULL,
	[Oena] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Ispit] PRIMARY KEY CLUSTERED 
(
	[BI] ASC,
	[PredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 12/29/2020 8:55:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmet](
	[PredmetId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.Predmet] PRIMARY KEY CLUSTERED 
(
	[PredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/29/2020 8:55:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[BI] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](20) NULL,
	[Prezime] [nvarchar](20) NULL,
	[Adresa] [nvarchar](30) NULL,
	[Grad] [nvarchar](20) NULL,
	[BrojIndexa] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED 
(
	[BI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ispit]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ispit_dbo.Predmet_PredmetId] FOREIGN KEY([PredmetId])
REFERENCES [dbo].[Predmet] ([PredmetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ispit] CHECK CONSTRAINT [FK_dbo.Ispit_dbo.Predmet_PredmetId]
GO
ALTER TABLE [dbo].[Ispit]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ispit_dbo.Student_BI] FOREIGN KEY([BI])
REFERENCES [dbo].[Student] ([BI])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ispit] CHECK CONSTRAINT [FK_dbo.Ispit_dbo.Student_BI]
GO
