--
-- Script To Update Data In EPM\SQLEXPRESS.backlog
-- Generated Wednesday, October 12, 2011, at 01:31 PM
--
-- Please backup EPM\SQLEXPRESS.backlog before executing this script
--


SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, QUOTED_IDENTIFIER, CONCAT_NULL_YIELDS_NULL, XACT_ABORT ON
GO
SET NUMERIC_ROUNDABORT OFF
GO

BEGIN TRANSACTION

IF @@ERROR <> 0
   IF @@TRANCOUNT = 1 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT = 1
   ALTER TABLE [dbo].[tblDIEStatus] DROP CONSTRAINT [PK_tblDIEStatus]
GO

IF @@ERROR <> 0
   IF @@TRANCOUNT = 1 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT = 1
   COMMIT TRANSACTION
GO

BEGIN TRANSACTION

SET IDENTITY_INSERT [dbo].[tblDIEStatus] ON
GO
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (1, N'Submitted', 0, 1, 0, 0, '../Images/DIEStatus/IDEAddNew.gif', 0, '#736f6e', N'gray      ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (2, N'Pending', 0, 1, 1, 0, '../Images/DIEStatus/IDENewWorkItem.gif', 0, '#F88017', N'orange    ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (3, N'Working on', 89, 0, 0, 0, '../Images/DIEStatus/IDEInProgess.gif', 0, '#00FF00', N'green     ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (4, N'Completed', 0, 1, 0, 0, '../Images/DIEStatus/IDEComplete.gif', 1, '#6698FF', N'blue      ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (5, N'Rejected', 0, 1, 1, 1, '../Images/DIEStatus/IDEReject.gif', 0, '#000000', N'black     ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (6, N'AGAAHAH', 341, 0, 0, 0, '../Images/DIEStatus/back.gif', 0, '#cc00cc', N'pink      ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (19, N'agag', 0, 0, 0, 0, '../Images/DIEStatus/active.gif', 0, '#ffff00', N'yellow    ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (23, N'dfd', 2, 0, 0, 0, '', 0, '#00cc00', N'green     ')
INSERT INTO [dbo].[tblDIEStatus]([DIEStatus], [DIENameStatus], [Order], [Visible], [Selected], [IsDefault], [IconLink], [IsCompleted], [Color], [ColorName]) VALUES (24, N'Test', 6, 0, 0, 0, '../Images/DIEStatus/IDEReject.gif', 0, '#cc0000', N'red       ')
SET IDENTITY_INSERT [dbo].[tblDIEStatus] OFF
GO
IF @@ERROR <> 0
   IF @@TRANCOUNT = 1 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT = 1
BEGIN
   PRINT 'Data Update Of [dbo].[tblDIEStatus] Successfully Completed'
   COMMIT TRANSACTION
END ELSE
BEGIN
   PRINT 'Data Update Of [dbo].[tblDIEStatus] Failed'
END
GO

BEGIN TRANSACTION

IF @@ERROR <> 0
   IF @@TRANCOUNT = 1 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT = 1
   ALTER TABLE [dbo].[tblDIEStatus] ADD CONSTRAINT [PK_tblDIEStatus] PRIMARY KEY CLUSTERED ([DIEStatus])
GO

IF @@ERROR <> 0
   IF @@TRANCOUNT = 1 ROLLBACK TRANSACTION
GO

IF @@TRANCOUNT = 1
   COMMIT TRANSACTION
GO
