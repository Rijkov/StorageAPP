

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Last_Name] [nvarchar](50) NULL,
	[First_Name] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [int] NULL,
	[Role] [nvarchar](50) NULL,
	[Date_Registr] [datetime] NULL
)

CREATE TABLE [dbo].[WorkAreas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[URL] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Coments] [nvarchar](50) NULL,
	[DateCreate] [datetime] NULL,
) 



