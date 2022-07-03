CREATE TABLE [dbo].[PC_Price]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
	[PC_PaperSizeId] INT NOT NULL ,
	[PC_JobTypeId] INT NOT NULL ,
	[Cost] DECIMAL(18,2) NOT NULL DEFAULT 0 ,
	[IsActive] Bit NOT NULL DEFAULT 1,
	[CreatedDate] Datetime2 NOT NULL,
    [CreatedBy] varchar(128) NOT NULL,
    [UpdatedDate] Datetime2 NULL,
    [UpdatedBy] varchar(128) NULL,
	CONSTRAINT FK_PC_Price_PC_PaperSizeId FOREIGN KEY (PC_PaperSizeId) REFERENCES [dbo].[PC_PaperSize](Id) , 
	CONSTRAINT FK_PC_Price_PC_JobTypeId FOREIGN KEY (PC_JobTypeId) REFERENCES [dbo].[PC_JobType](Id)
)
