﻿CREATE TABLE [dbo].[Alias]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Advertiser] NVARCHAR(100) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Rank] INT NOT NULL
)

GO

CREATE NONCLUSTERED INDEX IDX_ALIAS ON [dbo].[Alias] ([Advertiser], [Name], [Rank] ) 

GO