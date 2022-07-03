CREATE TABLE [dbo].[PC_JobType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Code] NVARCHAR(10) NOT NULL , 
	[Name] NVARCHAR(100) NOT NULL , 
	[IsActive] Bit NOT NULL DEFAULT 1,
	[CreatedDate] Datetime2 NOT NULL,
    [CreatedBy] varchar(128) NOT NULL,
    [UpdatedDate] Datetime2 NULL,
    [UpdatedBy] varchar(128) NULL
)
