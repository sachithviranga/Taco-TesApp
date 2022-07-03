PRINT 'PRICE DATA INSERT'

PRINT 'INSERT TABLE - [dbo].[PC_Price]'

INSERT INTO [dbo].[PC_Price]([PC_PaperSizeId],[PC_JobTypeId],[Cost],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,1,15,1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_Price] WHERE [PC_JobTypeId] = 1 AND [PC_PaperSizeId] = 1)

INSERT INTO [dbo].[PC_Price]([PC_PaperSizeId],[PC_JobTypeId],[Cost],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,2,10,1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_Price] WHERE [PC_JobTypeId] = 2 AND [PC_PaperSizeId] = 1)

INSERT INTO [dbo].[PC_Price]([PC_PaperSizeId],[PC_JobTypeId],[Cost],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,3,25,1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_Price] WHERE [PC_JobTypeId] = 3 AND [PC_PaperSizeId] = 1)

INSERT INTO [dbo].[PC_Price]([PC_PaperSizeId],[PC_JobTypeId],[Cost],[IsActive],[CreatedDate],[CreatedBy])
SELECT 1,4,20,1,GETDATE(),'SYSTEM'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[PC_Price] WHERE [PC_JobTypeId] = 4 AND [PC_PaperSizeId] = 1)

PRINT 'END - [dbo].[PC_Price]'

PRINT 'END COST DATA'