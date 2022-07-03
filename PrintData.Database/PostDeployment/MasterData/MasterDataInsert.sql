
PRINT 'MASTER DATA INSERT'

PRINT 'INSERT TABLE - [dbo].[PC_PaperSize]'

INSERT INTO [dbo].[PC_PaperSize]([Id],[Code],[Name],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,'A4','A4 Paper',1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_PaperSize] WHERE [Id] = 1)

PRINT 'END - [dbo].[PC_PaperSize]'

PRINT 'INSERT TABLE - [dbo].[PC_JobType]'

INSERT INTO [dbo].[PC_JobType]([Id],[Code],[Name],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,'S-B&W','Black and White - Single',1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_JobType] WHERE [Id] = 1)

INSERT INTO [dbo].[PC_JobType]([Id],[Code],[Name],[IsActive],[CreatedDate],[CreatedBy])
SELECT 2,'D-B&W','Black and White - Double',1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_JobType] WHERE [Id] = 2)

INSERT INTO [dbo].[PC_JobType]([Id],[Code],[Name],[IsActive],[CreatedDate],[CreatedBy])
SELECT 3,'S-C','Colour - Single',1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_JobType] WHERE [Id] = 3)

INSERT INTO [dbo].[PC_JobType]([Id],[Code],[Name],[IsActive],[CreatedDate],[CreatedBy])
SELECT 4,'D-C','Colour - Double',1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_JobType] WHERE [Id] = 4)

PRINT 'END - [dbo].[PC_JobType]'

PRINT 'END MASTER DATA'