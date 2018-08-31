USE [OPIM]
GO
IF EXISTS (SELECT * FROM sys.objects where name = 'Announcement')  
DROP TABLE Announcement  
GO

/****** Object:  Table [dbo].[Announcement]    Script Date: 2018/5/8 19:07:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Announcement](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Contents] [nvarchar](500) NOT NULL,
	[CreateOn] [datetime] NOT NULL,
	[CreateBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
-----------------------------------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects where name = 'Budget')  
DROP TABLE Budget  
GO
/****** Object:  Table [dbo].[Budget]    Script Date: 2018/5/8 19:13:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Budget](
	[Id] [uniqueidentifier] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[Money] [decimal](18, 0) NOT NULL CONSTRAINT [DF_Budget_Money]  DEFAULT ((0.00)),
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[CreateBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
-----------------------------------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects where name = 'MemberShips')  
DROP TABLE MemberShips  
GO


/****** Object:  Table [dbo].[MemberShips]    Script Date: 2018/5/8 19:19:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MemberShips](
	[Id] [uniqueidentifier] NOT NULL,
	[Account] [varchar](60) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[NickName] [varchar](20) NULL,
	[Sex] [nvarchar](2) NULL,
	[BirthOn] [datetime] NULL,
	[CreateOn] [datetime] NOT NULL,
	[LimitLevel] [int] NOT NULL,
	[Icon] [varchar](200) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nchar](11) NULL,
 CONSTRAINT [PK_MemberShips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
-----------------------------------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects where name = 'Records')  
DROP TABLE Records  
GO


/****** Object:  Table [dbo].[Records]    Script Date: 2018/5/8 19:21:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Records](
	[Id] [uniqueidentifier] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[Source] [varchar](20) NOT NULL,
	[Money] [decimal](18, 0) NOT NULL,
	[Remark] [nvarchar](300) NULL,
	[CreateOn] [nvarchar](20) NOT NULL,
	[CreateBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-----------------------------------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects where name = 'Types')  
DROP TABLE Types  
GO


/****** Object:  Table [dbo].[Types]    Script Date: 2018/5/8 19:21:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Types](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[InOrOut] [int] NOT NULL,
	[CreateOn] [datetime] NOT NULL,
	[CreateBy] [uniqueidentifier] NOT NULL,
	[Remark] [nvarchar](300) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects where name = 'BudgetWithType')  
DROP View BudgetWithType
GO

/****** Object:  View [dbo].[BudgetWithType]    Script Date: 2018/5/8 19:22:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BudgetWithType]
AS
SELECT   dbo.Budget.Id, dbo.Types.Name AS TypeName, dbo.Types.InOrOut, dbo.Budget.Money, dbo.Budget.Year, 
                dbo.Budget.Month, dbo.Budget.CreateBy
FROM      dbo.Budget LEFT OUTER JOIN
                dbo.Types ON dbo.Budget.TypeId = dbo.Types.Id

GO


-----------------------------------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects where name = 'RecordsWithTypes')  
DROP View RecordsWithTypes
GO

/****** Object:  View [dbo].[RecordsWithTypes]    Script Date: 2018/5/8 19:24:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[RecordsWithTypes]
AS
SELECT   dbo.Records.Id, dbo.Records.TypeId, dbo.Records.Source, dbo.Records.Money, dbo.Records.Remark, 
                dbo.Records.CreateOn, dbo.Records.CreateBy, dbo.Types.Name AS TypesName, dbo.Types.InOrOut
FROM      dbo.Records LEFT OUTER JOIN
                dbo.Types ON dbo.Records.TypeId = dbo.Types.Id

GO