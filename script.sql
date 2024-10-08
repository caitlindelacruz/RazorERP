USE [RazorERP]
GO
/****** Object:  User [dev]    Script Date: 12/08/2024 3:38:23 pm ******/
CREATE USER [dev] FOR LOGIN [dev] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dev]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [dev]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [dev]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [dev]
GO
ALTER ROLE [db_datareader] ADD MEMBER [dev]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [dev]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/08/2024 3:38:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](10) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Email], [Name], [Role], [PasswordHash]) VALUES (1, N'admin@company.com', N'Admin User', N'Admin', N'AQAAAAIAAYagAAAAEJEW/lLuVfN4g5owjc+1eDaNYoyonQocFi28vg2w48/nQbF3EFb2oOpg0n0dxnCiMQ==')
INSERT [dbo].[Users] ([ID], [Email], [Name], [Role], [PasswordHash]) VALUES (2, N'user@company.com', N'User User', N'User', N'AQAAAAIAAYagAAAAEJkwMfyINxrip5k7ns8UFLOIrZ9yiDbAXuszC/Aj1J+C+eoQYB6Zv/rywq1XLJhe/w==')
INSERT [dbo].[Users] ([ID], [Email], [Name], [Role], [PasswordHash]) VALUES (3, N'guest@company.com', N'Guest User', N'User', N'AQAAAAIAAYagAAAAEJW+hFFw3Gduw73PCPQeDyuKUSvJOfVJ6ladeBRcxhqqrs9NlmoyQd4vzFN6vhtZEQ==')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
