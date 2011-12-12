
USE [backlog]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblActionType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_Get_List

AS


				
				SELECT
					[ActionTypeID],
					[ActionTypeName]
				FROM
					[dbo].[tblActionType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblActionType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ActionTypeID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ActionTypeID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ActionTypeID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblActionType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ActionTypeID], O.[ActionTypeName]
				FROM
				    [dbo].[tblActionType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ActionTypeID] = PageIndex.[ActionTypeID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblActionType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblActionType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_Insert
(

	@ActionTypeId int    OUTPUT,

	@ActionTypeName nvarchar (100)  
)
AS


				
				INSERT INTO [dbo].[tblActionType]
					(
					[ActionTypeName]
					)
				VALUES
					(
					@ActionTypeName
					)
				
				-- Get the identity value
				SET @ActionTypeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblActionType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_Update
(

	@ActionTypeId int   ,

	@ActionTypeName nvarchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblActionType]
				SET
					[ActionTypeName] = @ActionTypeName
				WHERE
[ActionTypeID] = @ActionTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblActionType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_Delete
(

	@ActionTypeId int   
)
AS


				DELETE FROM [dbo].[tblActionType] WITH (ROWLOCK) 
				WHERE
					[ActionTypeID] = @ActionTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_GetByActionTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_GetByActionTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_GetByActionTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblActionType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_GetByActionTypeId
(

	@ActionTypeId int   
)
AS


				SELECT
					[ActionTypeID],
					[ActionTypeName]
				FROM
					[dbo].[tblActionType]
				WHERE
					[ActionTypeID] = @ActionTypeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblActionType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblActionType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblActionType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblActionType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblActionType_Find
(

	@SearchUsingOR bit   = null ,

	@ActionTypeId int   = null ,

	@ActionTypeName nvarchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ActionTypeID]
	, [ActionTypeName]
    FROM
	[dbo].[tblActionType]
    WHERE 
	 ([ActionTypeID] = @ActionTypeId OR @ActionTypeId IS NULL)
	AND ([ActionTypeName] = @ActionTypeName OR @ActionTypeName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ActionTypeID]
	, [ActionTypeName]
    FROM
	[dbo].[tblActionType]
    WHERE 
	 ([ActionTypeID] = @ActionTypeId AND @ActionTypeId is not null)
	OR ([ActionTypeName] = @ActionTypeName AND @ActionTypeName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblPriorityDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_Get_List

AS


				
				SELECT
					[PriorityDIERequestID],
					[PriorityDIERequestName],
					[PriorityDIERequestDescription],
					[Color],
					[ColorName],
					[PriorityDIERequestOrder]
				FROM
					[dbo].[tblPriorityDIERequest]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblPriorityDIERequest table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [PriorityDIERequestID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([PriorityDIERequestID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [PriorityDIERequestID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblPriorityDIERequest]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[PriorityDIERequestID], O.[PriorityDIERequestName], O.[PriorityDIERequestDescription], O.[Color], O.[ColorName], O.[PriorityDIERequestOrder]
				FROM
				    [dbo].[tblPriorityDIERequest] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[PriorityDIERequestID] = PageIndex.[PriorityDIERequestID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblPriorityDIERequest]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblPriorityDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_Insert
(

	@PriorityDieRequestId int    OUTPUT,

	@PriorityDieRequestName nvarchar (400)  ,

	@PriorityDieRequestDescription ntext   ,

	@Color nchar (50)  ,

	@ColorName nvarchar (150)  ,

	@PriorityDieRequestOrder int   
)
AS


				
				INSERT INTO [dbo].[tblPriorityDIERequest]
					(
					[PriorityDIERequestName]
					,[PriorityDIERequestDescription]
					,[Color]
					,[ColorName]
					,[PriorityDIERequestOrder]
					)
				VALUES
					(
					@PriorityDieRequestName
					,@PriorityDieRequestDescription
					,@Color
					,@ColorName
					,@PriorityDieRequestOrder
					)
				
				-- Get the identity value
				SET @PriorityDieRequestId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblPriorityDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_Update
(

	@PriorityDieRequestId int   ,

	@PriorityDieRequestName nvarchar (400)  ,

	@PriorityDieRequestDescription ntext   ,

	@Color nchar (50)  ,

	@ColorName nvarchar (150)  ,

	@PriorityDieRequestOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblPriorityDIERequest]
				SET
					[PriorityDIERequestName] = @PriorityDieRequestName
					,[PriorityDIERequestDescription] = @PriorityDieRequestDescription
					,[Color] = @Color
					,[ColorName] = @ColorName
					,[PriorityDIERequestOrder] = @PriorityDieRequestOrder
				WHERE
[PriorityDIERequestID] = @PriorityDieRequestId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblPriorityDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_Delete
(

	@PriorityDieRequestId int   
)
AS


				DELETE FROM [dbo].[tblPriorityDIERequest] WITH (ROWLOCK) 
				WHERE
					[PriorityDIERequestID] = @PriorityDieRequestId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_GetByPriorityDieRequestId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_GetByPriorityDieRequestId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_GetByPriorityDieRequestId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblPriorityDIERequest table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_GetByPriorityDieRequestId
(

	@PriorityDieRequestId int   
)
AS


				SELECT
					[PriorityDIERequestID],
					[PriorityDIERequestName],
					[PriorityDIERequestDescription],
					[Color],
					[ColorName],
					[PriorityDIERequestOrder]
				FROM
					[dbo].[tblPriorityDIERequest]
				WHERE
					[PriorityDIERequestID] = @PriorityDieRequestId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPriorityDIERequest_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPriorityDIERequest_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPriorityDIERequest_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblPriorityDIERequest table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPriorityDIERequest_Find
(

	@SearchUsingOR bit   = null ,

	@PriorityDieRequestId int   = null ,

	@PriorityDieRequestName nvarchar (400)  = null ,

	@PriorityDieRequestDescription ntext   = null ,

	@Color nchar (50)  = null ,

	@ColorName nvarchar (150)  = null ,

	@PriorityDieRequestOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PriorityDIERequestID]
	, [PriorityDIERequestName]
	, [PriorityDIERequestDescription]
	, [Color]
	, [ColorName]
	, [PriorityDIERequestOrder]
    FROM
	[dbo].[tblPriorityDIERequest]
    WHERE 
	 ([PriorityDIERequestID] = @PriorityDieRequestId OR @PriorityDieRequestId IS NULL)
	AND ([PriorityDIERequestName] = @PriorityDieRequestName OR @PriorityDieRequestName IS NULL)
	AND ([Color] = @Color OR @Color IS NULL)
	AND ([ColorName] = @ColorName OR @ColorName IS NULL)
	AND ([PriorityDIERequestOrder] = @PriorityDieRequestOrder OR @PriorityDieRequestOrder IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PriorityDIERequestID]
	, [PriorityDIERequestName]
	, [PriorityDIERequestDescription]
	, [Color]
	, [ColorName]
	, [PriorityDIERequestOrder]
    FROM
	[dbo].[tblPriorityDIERequest]
    WHERE 
	 ([PriorityDIERequestID] = @PriorityDieRequestId AND @PriorityDieRequestId is not null)
	OR ([PriorityDIERequestName] = @PriorityDieRequestName AND @PriorityDieRequestName is not null)
	OR ([Color] = @Color AND @Color is not null)
	OR ([ColorName] = @ColorName AND @ColorName is not null)
	OR ([PriorityDIERequestOrder] = @PriorityDieRequestOrder AND @PriorityDieRequestOrder is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_Get_List

AS


				
				SELECT
					[ProjectID],
					[ProjectName],
					[StartDate],
					[Deadline],
					[Description],
					[Active]
				FROM
					[dbo].[tblProject]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblProject table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ProjectID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ProjectID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ProjectID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblProject]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ProjectID], O.[ProjectName], O.[StartDate], O.[Deadline], O.[Description], O.[Active]
				FROM
				    [dbo].[tblProject] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ProjectID] = PageIndex.[ProjectID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblProject]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_Insert
(

	@ProjectId int    OUTPUT,

	@ProjectName nvarchar (255)  ,

	@StartDate datetime   ,

	@Deadline datetime   ,

	@Description nvarchar (400)  ,

	@Active bit   
)
AS


				
				INSERT INTO [dbo].[tblProject]
					(
					[ProjectName]
					,[StartDate]
					,[Deadline]
					,[Description]
					,[Active]
					)
				VALUES
					(
					@ProjectName
					,@StartDate
					,@Deadline
					,@Description
					,@Active
					)
				
				-- Get the identity value
				SET @ProjectId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_Update
(

	@ProjectId int   ,

	@ProjectName nvarchar (255)  ,

	@StartDate datetime   ,

	@Deadline datetime   ,

	@Description nvarchar (400)  ,

	@Active bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblProject]
				SET
					[ProjectName] = @ProjectName
					,[StartDate] = @StartDate
					,[Deadline] = @Deadline
					,[Description] = @Description
					,[Active] = @Active
				WHERE
[ProjectID] = @ProjectId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_Delete
(

	@ProjectId int   
)
AS


				DELETE FROM [dbo].[tblProject] WITH (ROWLOCK) 
				WHERE
					[ProjectID] = @ProjectId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_GetByProjectId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_GetByProjectId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_GetByProjectId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblProject table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_GetByProjectId
(

	@ProjectId int   
)
AS


				SELECT
					[ProjectID],
					[ProjectName],
					[StartDate],
					[Deadline],
					[Description],
					[Active]
				FROM
					[dbo].[tblProject]
				WHERE
					[ProjectID] = @ProjectId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblProject_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblProject_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblProject_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblProject table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblProject_Find
(

	@SearchUsingOR bit   = null ,

	@ProjectId int   = null ,

	@ProjectName nvarchar (255)  = null ,

	@StartDate datetime   = null ,

	@Deadline datetime   = null ,

	@Description nvarchar (400)  = null ,

	@Active bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProjectID]
	, [ProjectName]
	, [StartDate]
	, [Deadline]
	, [Description]
	, [Active]
    FROM
	[dbo].[tblProject]
    WHERE 
	 ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
	AND ([ProjectName] = @ProjectName OR @ProjectName IS NULL)
	AND ([StartDate] = @StartDate OR @StartDate IS NULL)
	AND ([Deadline] = @Deadline OR @Deadline IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProjectID]
	, [ProjectName]
	, [StartDate]
	, [Deadline]
	, [Description]
	, [Active]
    FROM
	[dbo].[tblProject]
    WHERE 
	 ([ProjectID] = @ProjectId AND @ProjectId is not null)
	OR ([ProjectName] = @ProjectName AND @ProjectName is not null)
	OR ([StartDate] = @StartDate AND @StartDate is not null)
	OR ([Deadline] = @Deadline AND @Deadline is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([Active] = @Active AND @Active is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblRelease table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_Get_List

AS


				
				SELECT
					[ReleaseID],
					[ProjectID],
					[ReleaseDate],
					[ReleaseName],
					[ReleaseNote],
					[Active],
					[UserID],
					[LastUserUpdate],
					[LastDateUpdate]
				FROM
					[dbo].[tblRelease]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblRelease table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ReleaseID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ReleaseID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ReleaseID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblRelease]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ReleaseID], O.[ProjectID], O.[ReleaseDate], O.[ReleaseName], O.[ReleaseNote], O.[Active], O.[UserID], O.[LastUserUpdate], O.[LastDateUpdate]
				FROM
				    [dbo].[tblRelease] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ReleaseID] = PageIndex.[ReleaseID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblRelease]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblRelease table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_Insert
(

	@ReleaseId int    OUTPUT,

	@ProjectId int   ,

	@ReleaseDate datetime   ,

	@ReleaseName nvarchar (100)  ,

	@ReleaseNote nvarchar (255)  ,

	@Active bit   ,

	@UserId int   ,

	@LastUserUpdate int   ,

	@LastDateUpdate datetime   
)
AS


				
				INSERT INTO [dbo].[tblRelease]
					(
					[ProjectID]
					,[ReleaseDate]
					,[ReleaseName]
					,[ReleaseNote]
					,[Active]
					,[UserID]
					,[LastUserUpdate]
					,[LastDateUpdate]
					)
				VALUES
					(
					@ProjectId
					,@ReleaseDate
					,@ReleaseName
					,@ReleaseNote
					,@Active
					,@UserId
					,@LastUserUpdate
					,@LastDateUpdate
					)
				
				-- Get the identity value
				SET @ReleaseId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblRelease table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_Update
(

	@ReleaseId int   ,

	@ProjectId int   ,

	@ReleaseDate datetime   ,

	@ReleaseName nvarchar (100)  ,

	@ReleaseNote nvarchar (255)  ,

	@Active bit   ,

	@UserId int   ,

	@LastUserUpdate int   ,

	@LastDateUpdate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblRelease]
				SET
					[ProjectID] = @ProjectId
					,[ReleaseDate] = @ReleaseDate
					,[ReleaseName] = @ReleaseName
					,[ReleaseNote] = @ReleaseNote
					,[Active] = @Active
					,[UserID] = @UserId
					,[LastUserUpdate] = @LastUserUpdate
					,[LastDateUpdate] = @LastDateUpdate
				WHERE
[ReleaseID] = @ReleaseId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblRelease table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_Delete
(

	@ReleaseId int   
)
AS


				DELETE FROM [dbo].[tblRelease] WITH (ROWLOCK) 
				WHERE
					[ReleaseID] = @ReleaseId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_GetByReleaseId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_GetByReleaseId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_GetByReleaseId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblRelease table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_GetByReleaseId
(

	@ReleaseId int   
)
AS


				SELECT
					[ReleaseID],
					[ProjectID],
					[ReleaseDate],
					[ReleaseName],
					[ReleaseNote],
					[Active],
					[UserID],
					[LastUserUpdate],
					[LastDateUpdate]
				FROM
					[dbo].[tblRelease]
				WHERE
					[ReleaseID] = @ReleaseId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblRelease_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblRelease_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblRelease_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblRelease table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblRelease_Find
(

	@SearchUsingOR bit   = null ,

	@ReleaseId int   = null ,

	@ProjectId int   = null ,

	@ReleaseDate datetime   = null ,

	@ReleaseName nvarchar (100)  = null ,

	@ReleaseNote nvarchar (255)  = null ,

	@Active bit   = null ,

	@UserId int   = null ,

	@LastUserUpdate int   = null ,

	@LastDateUpdate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ReleaseID]
	, [ProjectID]
	, [ReleaseDate]
	, [ReleaseName]
	, [ReleaseNote]
	, [Active]
	, [UserID]
	, [LastUserUpdate]
	, [LastDateUpdate]
    FROM
	[dbo].[tblRelease]
    WHERE 
	 ([ReleaseID] = @ReleaseId OR @ReleaseId IS NULL)
	AND ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
	AND ([ReleaseDate] = @ReleaseDate OR @ReleaseDate IS NULL)
	AND ([ReleaseName] = @ReleaseName OR @ReleaseName IS NULL)
	AND ([ReleaseNote] = @ReleaseNote OR @ReleaseNote IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([UserID] = @UserId OR @UserId IS NULL)
	AND ([LastUserUpdate] = @LastUserUpdate OR @LastUserUpdate IS NULL)
	AND ([LastDateUpdate] = @LastDateUpdate OR @LastDateUpdate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ReleaseID]
	, [ProjectID]
	, [ReleaseDate]
	, [ReleaseName]
	, [ReleaseNote]
	, [Active]
	, [UserID]
	, [LastUserUpdate]
	, [LastDateUpdate]
    FROM
	[dbo].[tblRelease]
    WHERE 
	 ([ReleaseID] = @ReleaseId AND @ReleaseId is not null)
	OR ([ProjectID] = @ProjectId AND @ProjectId is not null)
	OR ([ReleaseDate] = @ReleaseDate AND @ReleaseDate is not null)
	OR ([ReleaseName] = @ReleaseName AND @ReleaseName is not null)
	OR ([ReleaseNote] = @ReleaseNote AND @ReleaseNote is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([UserID] = @UserId AND @UserId is not null)
	OR ([LastUserUpdate] = @LastUserUpdate AND @LastUserUpdate is not null)
	OR ([LastDateUpdate] = @LastDateUpdate AND @LastDateUpdate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblResolutions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_Get_List

AS


				
				SELECT
					[ResolutionsID],
					[ResolutionsName]
				FROM
					[dbo].[tblResolutions]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblResolutions table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ResolutionsID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ResolutionsID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ResolutionsID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblResolutions]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ResolutionsID], O.[ResolutionsName]
				FROM
				    [dbo].[tblResolutions] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ResolutionsID] = PageIndex.[ResolutionsID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblResolutions]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblResolutions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_Insert
(

	@ResolutionsId int    OUTPUT,

	@ResolutionsName nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[tblResolutions]
					(
					[ResolutionsName]
					)
				VALUES
					(
					@ResolutionsName
					)
				
				-- Get the identity value
				SET @ResolutionsId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblResolutions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_Update
(

	@ResolutionsId int   ,

	@ResolutionsName nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblResolutions]
				SET
					[ResolutionsName] = @ResolutionsName
				WHERE
[ResolutionsID] = @ResolutionsId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblResolutions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_Delete
(

	@ResolutionsId int   
)
AS


				DELETE FROM [dbo].[tblResolutions] WITH (ROWLOCK) 
				WHERE
					[ResolutionsID] = @ResolutionsId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_GetByResolutionsId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_GetByResolutionsId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_GetByResolutionsId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblResolutions table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_GetByResolutionsId
(

	@ResolutionsId int   
)
AS


				SELECT
					[ResolutionsID],
					[ResolutionsName]
				FROM
					[dbo].[tblResolutions]
				WHERE
					[ResolutionsID] = @ResolutionsId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblResolutions_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblResolutions_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblResolutions_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblResolutions table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblResolutions_Find
(

	@SearchUsingOR bit   = null ,

	@ResolutionsId int   = null ,

	@ResolutionsName nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ResolutionsID]
	, [ResolutionsName]
    FROM
	[dbo].[tblResolutions]
    WHERE 
	 ([ResolutionsID] = @ResolutionsId OR @ResolutionsId IS NULL)
	AND ([ResolutionsName] = @ResolutionsName OR @ResolutionsName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ResolutionsID]
	, [ResolutionsName]
    FROM
	[dbo].[tblResolutions]
    WHERE 
	 ([ResolutionsID] = @ResolutionsId AND @ResolutionsId is not null)
	OR ([ResolutionsName] = @ResolutionsName AND @ResolutionsName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblMileStole table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_Get_List

AS


				
				SELECT
					[MileStoleID],
					[MileStoleName],
					[OriginalDueDate],
					[RevisedDueDate],
					[CompleteDate],
					[Progress],
					[ProjectID],
					[Enabled],
					[MileStoleOrder]
				FROM
					[dbo].[tblMileStole]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblMileStole table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [MileStoleID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MileStoleID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [MileStoleID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblMileStole]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[MileStoleID], O.[MileStoleName], O.[OriginalDueDate], O.[RevisedDueDate], O.[CompleteDate], O.[Progress], O.[ProjectID], O.[Enabled], O.[MileStoleOrder]
				FROM
				    [dbo].[tblMileStole] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MileStoleID] = PageIndex.[MileStoleID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblMileStole]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblMileStole table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_Insert
(

	@MileStoleId int    OUTPUT,

	@MileStoleName nvarchar (1000)  ,

	@OriginalDueDate datetime   ,

	@RevisedDueDate datetime   ,

	@CompleteDate datetime   ,

	@Progress float   ,

	@ProjectId int   ,

	@Enabled bit   ,

	@MileStoleOrder int   
)
AS


				
				INSERT INTO [dbo].[tblMileStole]
					(
					[MileStoleName]
					,[OriginalDueDate]
					,[RevisedDueDate]
					,[CompleteDate]
					,[Progress]
					,[ProjectID]
					,[Enabled]
					,[MileStoleOrder]
					)
				VALUES
					(
					@MileStoleName
					,@OriginalDueDate
					,@RevisedDueDate
					,@CompleteDate
					,@Progress
					,@ProjectId
					,@Enabled
					,@MileStoleOrder
					)
				
				-- Get the identity value
				SET @MileStoleId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblMileStole table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_Update
(

	@MileStoleId int   ,

	@MileStoleName nvarchar (1000)  ,

	@OriginalDueDate datetime   ,

	@RevisedDueDate datetime   ,

	@CompleteDate datetime   ,

	@Progress float   ,

	@ProjectId int   ,

	@Enabled bit   ,

	@MileStoleOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblMileStole]
				SET
					[MileStoleName] = @MileStoleName
					,[OriginalDueDate] = @OriginalDueDate
					,[RevisedDueDate] = @RevisedDueDate
					,[CompleteDate] = @CompleteDate
					,[Progress] = @Progress
					,[ProjectID] = @ProjectId
					,[Enabled] = @Enabled
					,[MileStoleOrder] = @MileStoleOrder
				WHERE
[MileStoleID] = @MileStoleId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblMileStole table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_Delete
(

	@MileStoleId int   
)
AS


				DELETE FROM [dbo].[tblMileStole] WITH (ROWLOCK) 
				WHERE
					[MileStoleID] = @MileStoleId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_GetByMileStoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_GetByMileStoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_GetByMileStoleId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblMileStole table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_GetByMileStoleId
(

	@MileStoleId int   
)
AS


				SELECT
					[MileStoleID],
					[MileStoleName],
					[OriginalDueDate],
					[RevisedDueDate],
					[CompleteDate],
					[Progress],
					[ProjectID],
					[Enabled],
					[MileStoleOrder]
				FROM
					[dbo].[tblMileStole]
				WHERE
					[MileStoleID] = @MileStoleId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblMileStole_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblMileStole_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblMileStole_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblMileStole table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblMileStole_Find
(

	@SearchUsingOR bit   = null ,

	@MileStoleId int   = null ,

	@MileStoleName nvarchar (1000)  = null ,

	@OriginalDueDate datetime   = null ,

	@RevisedDueDate datetime   = null ,

	@CompleteDate datetime   = null ,

	@Progress float   = null ,

	@ProjectId int   = null ,

	@Enabled bit   = null ,

	@MileStoleOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MileStoleID]
	, [MileStoleName]
	, [OriginalDueDate]
	, [RevisedDueDate]
	, [CompleteDate]
	, [Progress]
	, [ProjectID]
	, [Enabled]
	, [MileStoleOrder]
    FROM
	[dbo].[tblMileStole]
    WHERE 
	 ([MileStoleID] = @MileStoleId OR @MileStoleId IS NULL)
	AND ([MileStoleName] = @MileStoleName OR @MileStoleName IS NULL)
	AND ([OriginalDueDate] = @OriginalDueDate OR @OriginalDueDate IS NULL)
	AND ([RevisedDueDate] = @RevisedDueDate OR @RevisedDueDate IS NULL)
	AND ([CompleteDate] = @CompleteDate OR @CompleteDate IS NULL)
	AND ([Progress] = @Progress OR @Progress IS NULL)
	AND ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
	AND ([Enabled] = @Enabled OR @Enabled IS NULL)
	AND ([MileStoleOrder] = @MileStoleOrder OR @MileStoleOrder IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MileStoleID]
	, [MileStoleName]
	, [OriginalDueDate]
	, [RevisedDueDate]
	, [CompleteDate]
	, [Progress]
	, [ProjectID]
	, [Enabled]
	, [MileStoleOrder]
    FROM
	[dbo].[tblMileStole]
    WHERE 
	 ([MileStoleID] = @MileStoleId AND @MileStoleId is not null)
	OR ([MileStoleName] = @MileStoleName AND @MileStoleName is not null)
	OR ([OriginalDueDate] = @OriginalDueDate AND @OriginalDueDate is not null)
	OR ([RevisedDueDate] = @RevisedDueDate AND @RevisedDueDate is not null)
	OR ([CompleteDate] = @CompleteDate AND @CompleteDate is not null)
	OR ([Progress] = @Progress AND @Progress is not null)
	OR ([ProjectID] = @ProjectId AND @ProjectId is not null)
	OR ([Enabled] = @Enabled AND @Enabled is not null)
	OR ([MileStoleOrder] = @MileStoleOrder AND @MileStoleOrder is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIEType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_Get_List

AS


				
				SELECT
					[DIETypeID],
					[Initial],
					[DIETypeName],
					[Description],
					[IsDefault],
					[Selected],
					[Active],
					[Order],
					[ProjectID]
				FROM
					[dbo].[tblDIEType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIEType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIETypeID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIETypeID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIETypeID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIETypeID], O.[Initial], O.[DIETypeName], O.[Description], O.[IsDefault], O.[Selected], O.[Active], O.[Order], O.[ProjectID]
				FROM
				    [dbo].[tblDIEType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIETypeID] = PageIndex.[DIETypeID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIEType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_Insert
(

	@DieTypeId int    OUTPUT,

	@Initial char (10)  ,

	@DieTypeName nvarchar (250)  ,

	@Description nvarchar (4000)  ,

	@IsDefault bit   ,

	@Selected bit   ,

	@Active bit   ,

	@Order int   ,

	@ProjectId int   
)
AS


				
				INSERT INTO [dbo].[tblDIEType]
					(
					[Initial]
					,[DIETypeName]
					,[Description]
					,[IsDefault]
					,[Selected]
					,[Active]
					,[Order]
					,[ProjectID]
					)
				VALUES
					(
					@Initial
					,@DieTypeName
					,@Description
					,@IsDefault
					,@Selected
					,@Active
					,@Order
					,@ProjectId
					)
				
				-- Get the identity value
				SET @DieTypeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIEType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_Update
(

	@DieTypeId int   ,

	@Initial char (10)  ,

	@DieTypeName nvarchar (250)  ,

	@Description nvarchar (4000)  ,

	@IsDefault bit   ,

	@Selected bit   ,

	@Active bit   ,

	@Order int   ,

	@ProjectId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIEType]
				SET
					[Initial] = @Initial
					,[DIETypeName] = @DieTypeName
					,[Description] = @Description
					,[IsDefault] = @IsDefault
					,[Selected] = @Selected
					,[Active] = @Active
					,[Order] = @Order
					,[ProjectID] = @ProjectId
				WHERE
[DIETypeID] = @DieTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIEType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_Delete
(

	@DieTypeId int   
)
AS


				DELETE FROM [dbo].[tblDIEType] WITH (ROWLOCK) 
				WHERE
					[DIETypeID] = @DieTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_GetByDieTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_GetByDieTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_GetByDieTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIEType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_GetByDieTypeId
(

	@DieTypeId int   
)
AS


				SELECT
					[DIETypeID],
					[Initial],
					[DIETypeName],
					[Description],
					[IsDefault],
					[Selected],
					[Active],
					[Order],
					[ProjectID]
				FROM
					[dbo].[tblDIEType]
				WHERE
					[DIETypeID] = @DieTypeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIEType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEType_Find
(

	@SearchUsingOR bit   = null ,

	@DieTypeId int   = null ,

	@Initial char (10)  = null ,

	@DieTypeName nvarchar (250)  = null ,

	@Description nvarchar (4000)  = null ,

	@IsDefault bit   = null ,

	@Selected bit   = null ,

	@Active bit   = null ,

	@Order int   = null ,

	@ProjectId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIETypeID]
	, [Initial]
	, [DIETypeName]
	, [Description]
	, [IsDefault]
	, [Selected]
	, [Active]
	, [Order]
	, [ProjectID]
    FROM
	[dbo].[tblDIEType]
    WHERE 
	 ([DIETypeID] = @DieTypeId OR @DieTypeId IS NULL)
	AND ([Initial] = @Initial OR @Initial IS NULL)
	AND ([DIETypeName] = @DieTypeName OR @DieTypeName IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([IsDefault] = @IsDefault OR @IsDefault IS NULL)
	AND ([Selected] = @Selected OR @Selected IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Order] = @Order OR @Order IS NULL)
	AND ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIETypeID]
	, [Initial]
	, [DIETypeName]
	, [Description]
	, [IsDefault]
	, [Selected]
	, [Active]
	, [Order]
	, [ProjectID]
    FROM
	[dbo].[tblDIEType]
    WHERE 
	 ([DIETypeID] = @DieTypeId AND @DieTypeId is not null)
	OR ([Initial] = @Initial AND @Initial is not null)
	OR ([DIETypeName] = @DieTypeName AND @DieTypeName is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([IsDefault] = @IsDefault AND @IsDefault is not null)
	OR ([Selected] = @Selected AND @Selected is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Order] = @Order AND @Order is not null)
	OR ([ProjectID] = @ProjectId AND @ProjectId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIEStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_Get_List

AS


				
				SELECT
					[DIEStatus],
					[DIENameStatus],
					[Order],
					[Visible],
					[Selected],
					[IsDefault],
					[IconLink],
					[IsCompleted],
					[Color],
					[ColorName],
					[ProjectID]
				FROM
					[dbo].[tblDIEStatus]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIEStatus table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIEStatus] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIEStatus])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIEStatus]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIEStatus], O.[DIENameStatus], O.[Order], O.[Visible], O.[Selected], O.[IsDefault], O.[IconLink], O.[IsCompleted], O.[Color], O.[ColorName], O.[ProjectID]
				FROM
				    [dbo].[tblDIEStatus] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIEStatus] = PageIndex.[DIEStatus]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIEStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_Insert
(

	@DieStatus int    OUTPUT,

	@DieNameStatus nvarchar (500)  ,

	@Order int   ,

	@Visible bit   ,

	@Selected bit   ,

	@IsDefault bit   ,

	@IconLink varchar (100)  ,

	@IsCompleted bit   ,

	@Color varchar (50)  ,

	@ColorName nchar (10)  ,

	@ProjectId int   
)
AS


				
				INSERT INTO [dbo].[tblDIEStatus]
					(
					[DIENameStatus]
					,[Order]
					,[Visible]
					,[Selected]
					,[IsDefault]
					,[IconLink]
					,[IsCompleted]
					,[Color]
					,[ColorName]
					,[ProjectID]
					)
				VALUES
					(
					@DieNameStatus
					,@Order
					,@Visible
					,@Selected
					,@IsDefault
					,@IconLink
					,@IsCompleted
					,@Color
					,@ColorName
					,@ProjectId
					)
				
				-- Get the identity value
				SET @DieStatus = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIEStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_Update
(

	@DieStatus int   ,

	@DieNameStatus nvarchar (500)  ,

	@Order int   ,

	@Visible bit   ,

	@Selected bit   ,

	@IsDefault bit   ,

	@IconLink varchar (100)  ,

	@IsCompleted bit   ,

	@Color varchar (50)  ,

	@ColorName nchar (10)  ,

	@ProjectId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIEStatus]
				SET
					[DIENameStatus] = @DieNameStatus
					,[Order] = @Order
					,[Visible] = @Visible
					,[Selected] = @Selected
					,[IsDefault] = @IsDefault
					,[IconLink] = @IconLink
					,[IsCompleted] = @IsCompleted
					,[Color] = @Color
					,[ColorName] = @ColorName
					,[ProjectID] = @ProjectId
				WHERE
[DIEStatus] = @DieStatus 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIEStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_Delete
(

	@DieStatus int   
)
AS


				DELETE FROM [dbo].[tblDIEStatus] WITH (ROWLOCK) 
				WHERE
					[DIEStatus] = @DieStatus
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_GetByDieStatus procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_GetByDieStatus') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_GetByDieStatus
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIEStatus table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_GetByDieStatus
(

	@DieStatus int   
)
AS


				SELECT
					[DIEStatus],
					[DIENameStatus],
					[Order],
					[Visible],
					[Selected],
					[IsDefault],
					[IconLink],
					[IsCompleted],
					[Color],
					[ColorName],
					[ProjectID]
				FROM
					[dbo].[tblDIEStatus]
				WHERE
					[DIEStatus] = @DieStatus
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEStatus_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEStatus_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEStatus_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIEStatus table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEStatus_Find
(

	@SearchUsingOR bit   = null ,

	@DieStatus int   = null ,

	@DieNameStatus nvarchar (500)  = null ,

	@Order int   = null ,

	@Visible bit   = null ,

	@Selected bit   = null ,

	@IsDefault bit   = null ,

	@IconLink varchar (100)  = null ,

	@IsCompleted bit   = null ,

	@Color varchar (50)  = null ,

	@ColorName nchar (10)  = null ,

	@ProjectId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIEStatus]
	, [DIENameStatus]
	, [Order]
	, [Visible]
	, [Selected]
	, [IsDefault]
	, [IconLink]
	, [IsCompleted]
	, [Color]
	, [ColorName]
	, [ProjectID]
    FROM
	[dbo].[tblDIEStatus]
    WHERE 
	 ([DIEStatus] = @DieStatus OR @DieStatus IS NULL)
	AND ([DIENameStatus] = @DieNameStatus OR @DieNameStatus IS NULL)
	AND ([Order] = @Order OR @Order IS NULL)
	AND ([Visible] = @Visible OR @Visible IS NULL)
	AND ([Selected] = @Selected OR @Selected IS NULL)
	AND ([IsDefault] = @IsDefault OR @IsDefault IS NULL)
	AND ([IconLink] = @IconLink OR @IconLink IS NULL)
	AND ([IsCompleted] = @IsCompleted OR @IsCompleted IS NULL)
	AND ([Color] = @Color OR @Color IS NULL)
	AND ([ColorName] = @ColorName OR @ColorName IS NULL)
	AND ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIEStatus]
	, [DIENameStatus]
	, [Order]
	, [Visible]
	, [Selected]
	, [IsDefault]
	, [IconLink]
	, [IsCompleted]
	, [Color]
	, [ColorName]
	, [ProjectID]
    FROM
	[dbo].[tblDIEStatus]
    WHERE 
	 ([DIEStatus] = @DieStatus AND @DieStatus is not null)
	OR ([DIENameStatus] = @DieNameStatus AND @DieNameStatus is not null)
	OR ([Order] = @Order AND @Order is not null)
	OR ([Visible] = @Visible AND @Visible is not null)
	OR ([Selected] = @Selected AND @Selected is not null)
	OR ([IsDefault] = @IsDefault AND @IsDefault is not null)
	OR ([IconLink] = @IconLink AND @IconLink is not null)
	OR ([IsCompleted] = @IsCompleted AND @IsCompleted is not null)
	OR ([Color] = @Color AND @Color is not null)
	OR ([ColorName] = @ColorName AND @ColorName is not null)
	OR ([ProjectID] = @ProjectId AND @ProjectId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIECategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_Get_List

AS


				
				SELECT
					[DIECategoryID],
					[DIECategoryName],
					[DEICategoryDescription]
				FROM
					[dbo].[tblDIECategory]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIECategory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIECategoryID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIECategoryID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIECategoryID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIECategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIECategoryID], O.[DIECategoryName], O.[DEICategoryDescription]
				FROM
				    [dbo].[tblDIECategory] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIECategoryID] = PageIndex.[DIECategoryID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIECategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIECategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_Insert
(

	@DieCategoryId int    OUTPUT,

	@DieCategoryName nvarchar (1000)  ,

	@DeiCategoryDescription nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[tblDIECategory]
					(
					[DIECategoryName]
					,[DEICategoryDescription]
					)
				VALUES
					(
					@DieCategoryName
					,@DeiCategoryDescription
					)
				
				-- Get the identity value
				SET @DieCategoryId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIECategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_Update
(

	@DieCategoryId int   ,

	@DieCategoryName nvarchar (1000)  ,

	@DeiCategoryDescription nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIECategory]
				SET
					[DIECategoryName] = @DieCategoryName
					,[DEICategoryDescription] = @DeiCategoryDescription
				WHERE
[DIECategoryID] = @DieCategoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIECategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_Delete
(

	@DieCategoryId int   
)
AS


				DELETE FROM [dbo].[tblDIECategory] WITH (ROWLOCK) 
				WHERE
					[DIECategoryID] = @DieCategoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_GetByDieCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_GetByDieCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_GetByDieCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIECategory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_GetByDieCategoryId
(

	@DieCategoryId int   
)
AS


				SELECT
					[DIECategoryID],
					[DIECategoryName],
					[DEICategoryDescription]
				FROM
					[dbo].[tblDIECategory]
				WHERE
					[DIECategoryID] = @DieCategoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIECategory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIECategory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIECategory_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIECategory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIECategory_Find
(

	@SearchUsingOR bit   = null ,

	@DieCategoryId int   = null ,

	@DieCategoryName nvarchar (1000)  = null ,

	@DeiCategoryDescription nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIECategoryID]
	, [DIECategoryName]
	, [DEICategoryDescription]
    FROM
	[dbo].[tblDIECategory]
    WHERE 
	 ([DIECategoryID] = @DieCategoryId OR @DieCategoryId IS NULL)
	AND ([DIECategoryName] = @DieCategoryName OR @DieCategoryName IS NULL)
	AND ([DEICategoryDescription] = @DeiCategoryDescription OR @DeiCategoryDescription IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIECategoryID]
	, [DIECategoryName]
	, [DEICategoryDescription]
    FROM
	[dbo].[tblDIECategory]
    WHERE 
	 ([DIECategoryID] = @DieCategoryId AND @DieCategoryId is not null)
	OR ([DIECategoryName] = @DieCategoryName AND @DieCategoryName is not null)
	OR ([DEICategoryDescription] = @DeiCategoryDescription AND @DeiCategoryDescription is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIEAttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_Get_List

AS


				
				SELECT
					[DIEAttachFileID],
					[DIERequestID],
					[DIEFileName],
					[DIEFileUrl]
				FROM
					[dbo].[tblDIEAttachFile]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIEAttachFile table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIEAttachFileID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIEAttachFileID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIEAttachFileID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEAttachFile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIEAttachFileID], O.[DIERequestID], O.[DIEFileName], O.[DIEFileUrl]
				FROM
				    [dbo].[tblDIEAttachFile] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIEAttachFileID] = PageIndex.[DIEAttachFileID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEAttachFile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIEAttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_Insert
(

	@DieAttachFileId int    OUTPUT,

	@DieRequestId int   ,

	@DieFileName nvarchar (400)  ,

	@DieFileUrl nvarchar (2000)  
)
AS


				
				INSERT INTO [dbo].[tblDIEAttachFile]
					(
					[DIERequestID]
					,[DIEFileName]
					,[DIEFileUrl]
					)
				VALUES
					(
					@DieRequestId
					,@DieFileName
					,@DieFileUrl
					)
				
				-- Get the identity value
				SET @DieAttachFileId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIEAttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_Update
(

	@DieAttachFileId int   ,

	@DieRequestId int   ,

	@DieFileName nvarchar (400)  ,

	@DieFileUrl nvarchar (2000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIEAttachFile]
				SET
					[DIERequestID] = @DieRequestId
					,[DIEFileName] = @DieFileName
					,[DIEFileUrl] = @DieFileUrl
				WHERE
[DIEAttachFileID] = @DieAttachFileId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIEAttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_Delete
(

	@DieAttachFileId int   
)
AS


				DELETE FROM [dbo].[tblDIEAttachFile] WITH (ROWLOCK) 
				WHERE
					[DIEAttachFileID] = @DieAttachFileId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_GetByDieRequestId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_GetByDieRequestId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_GetByDieRequestId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIEAttachFile table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_GetByDieRequestId
(

	@DieRequestId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIEAttachFileID],
					[DIERequestID],
					[DIEFileName],
					[DIEFileUrl]
				FROM
					[dbo].[tblDIEAttachFile]
				WHERE
					[DIERequestID] = @DieRequestId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_GetByDieAttachFileId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_GetByDieAttachFileId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_GetByDieAttachFileId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIEAttachFile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_GetByDieAttachFileId
(

	@DieAttachFileId int   
)
AS


				SELECT
					[DIEAttachFileID],
					[DIERequestID],
					[DIEFileName],
					[DIEFileUrl]
				FROM
					[dbo].[tblDIEAttachFile]
				WHERE
					[DIEAttachFileID] = @DieAttachFileId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEAttachFile_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEAttachFile_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEAttachFile_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIEAttachFile table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEAttachFile_Find
(

	@SearchUsingOR bit   = null ,

	@DieAttachFileId int   = null ,

	@DieRequestId int   = null ,

	@DieFileName nvarchar (400)  = null ,

	@DieFileUrl nvarchar (2000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIEAttachFileID]
	, [DIERequestID]
	, [DIEFileName]
	, [DIEFileUrl]
    FROM
	[dbo].[tblDIEAttachFile]
    WHERE 
	 ([DIEAttachFileID] = @DieAttachFileId OR @DieAttachFileId IS NULL)
	AND ([DIERequestID] = @DieRequestId OR @DieRequestId IS NULL)
	AND ([DIEFileName] = @DieFileName OR @DieFileName IS NULL)
	AND ([DIEFileUrl] = @DieFileUrl OR @DieFileUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIEAttachFileID]
	, [DIERequestID]
	, [DIEFileName]
	, [DIEFileUrl]
    FROM
	[dbo].[tblDIEAttachFile]
    WHERE 
	 ([DIEAttachFileID] = @DieAttachFileId AND @DieAttachFileId is not null)
	OR ([DIERequestID] = @DieRequestId AND @DieRequestId is not null)
	OR ([DIEFileName] = @DieFileName AND @DieFileName is not null)
	OR ([DIEFileUrl] = @DieFileUrl AND @DieFileUrl is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIEHistory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_Get_List

AS


				
				SELECT
					[DIEHistoryID],
					[DIERequestID],
					[DIEDateSubmit],
					[DIEStatus],
					[DIEHistoryNote],
					[DIEHistoryNoteJP],
					[ReleaseID],
					[UserID],
					[Owner],
					[LastUserUpdate],
					[LastTimeUpdate],
					[ActionTypeID]
				FROM
					[dbo].[tblDIEHistory]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIEHistory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIEHistoryID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIEHistoryID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIEHistoryID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEHistory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIEHistoryID], O.[DIERequestID], O.[DIEDateSubmit], O.[DIEStatus], O.[DIEHistoryNote], O.[DIEHistoryNoteJP], O.[ReleaseID], O.[UserID], O.[Owner], O.[LastUserUpdate], O.[LastTimeUpdate], O.[ActionTypeID]
				FROM
				    [dbo].[tblDIEHistory] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIEHistoryID] = PageIndex.[DIEHistoryID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIEHistory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIEHistory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_Insert
(

	@DieHistoryId int    OUTPUT,

	@DieRequestId int   ,

	@DieDateSubmit datetime   ,

	@DieStatus smallint   ,

	@DieHistoryNote nvarchar (4000)  ,

	@DieHistoryNoteJp nvarchar (4000)  ,

	@ReleaseId int   ,

	@UserId int   ,

	@Owner int   ,

	@LastUserUpdate int   ,

	@LastTimeUpdate datetime   ,

	@ActionTypeId int   
)
AS


				
				INSERT INTO [dbo].[tblDIEHistory]
					(
					[DIERequestID]
					,[DIEDateSubmit]
					,[DIEStatus]
					,[DIEHistoryNote]
					,[DIEHistoryNoteJP]
					,[ReleaseID]
					,[UserID]
					,[Owner]
					,[LastUserUpdate]
					,[LastTimeUpdate]
					,[ActionTypeID]
					)
				VALUES
					(
					@DieRequestId
					,@DieDateSubmit
					,@DieStatus
					,@DieHistoryNote
					,@DieHistoryNoteJp
					,@ReleaseId
					,@UserId
					,@Owner
					,@LastUserUpdate
					,@LastTimeUpdate
					,@ActionTypeId
					)
				
				-- Get the identity value
				SET @DieHistoryId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIEHistory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_Update
(

	@DieHistoryId int   ,

	@DieRequestId int   ,

	@DieDateSubmit datetime   ,

	@DieStatus smallint   ,

	@DieHistoryNote nvarchar (4000)  ,

	@DieHistoryNoteJp nvarchar (4000)  ,

	@ReleaseId int   ,

	@UserId int   ,

	@Owner int   ,

	@LastUserUpdate int   ,

	@LastTimeUpdate datetime   ,

	@ActionTypeId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIEHistory]
				SET
					[DIERequestID] = @DieRequestId
					,[DIEDateSubmit] = @DieDateSubmit
					,[DIEStatus] = @DieStatus
					,[DIEHistoryNote] = @DieHistoryNote
					,[DIEHistoryNoteJP] = @DieHistoryNoteJp
					,[ReleaseID] = @ReleaseId
					,[UserID] = @UserId
					,[Owner] = @Owner
					,[LastUserUpdate] = @LastUserUpdate
					,[LastTimeUpdate] = @LastTimeUpdate
					,[ActionTypeID] = @ActionTypeId
				WHERE
[DIEHistoryID] = @DieHistoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIEHistory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_Delete
(

	@DieHistoryId int   
)
AS


				DELETE FROM [dbo].[tblDIEHistory] WITH (ROWLOCK) 
				WHERE
					[DIEHistoryID] = @DieHistoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_GetByDieHistoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_GetByDieHistoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_GetByDieHistoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIEHistory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_GetByDieHistoryId
(

	@DieHistoryId int   
)
AS


				SELECT
					[DIEHistoryID],
					[DIERequestID],
					[DIEDateSubmit],
					[DIEStatus],
					[DIEHistoryNote],
					[DIEHistoryNoteJP],
					[ReleaseID],
					[UserID],
					[Owner],
					[LastUserUpdate],
					[LastTimeUpdate],
					[ActionTypeID]
				FROM
					[dbo].[tblDIEHistory]
				WHERE
					[DIEHistoryID] = @DieHistoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIEHistory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIEHistory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIEHistory_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIEHistory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIEHistory_Find
(

	@SearchUsingOR bit   = null ,

	@DieHistoryId int   = null ,

	@DieRequestId int   = null ,

	@DieDateSubmit datetime   = null ,

	@DieStatus smallint   = null ,

	@DieHistoryNote nvarchar (4000)  = null ,

	@DieHistoryNoteJp nvarchar (4000)  = null ,

	@ReleaseId int   = null ,

	@UserId int   = null ,

	@Owner int   = null ,

	@LastUserUpdate int   = null ,

	@LastTimeUpdate datetime   = null ,

	@ActionTypeId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIEHistoryID]
	, [DIERequestID]
	, [DIEDateSubmit]
	, [DIEStatus]
	, [DIEHistoryNote]
	, [DIEHistoryNoteJP]
	, [ReleaseID]
	, [UserID]
	, [Owner]
	, [LastUserUpdate]
	, [LastTimeUpdate]
	, [ActionTypeID]
    FROM
	[dbo].[tblDIEHistory]
    WHERE 
	 ([DIEHistoryID] = @DieHistoryId OR @DieHistoryId IS NULL)
	AND ([DIERequestID] = @DieRequestId OR @DieRequestId IS NULL)
	AND ([DIEDateSubmit] = @DieDateSubmit OR @DieDateSubmit IS NULL)
	AND ([DIEStatus] = @DieStatus OR @DieStatus IS NULL)
	AND ([DIEHistoryNote] = @DieHistoryNote OR @DieHistoryNote IS NULL)
	AND ([DIEHistoryNoteJP] = @DieHistoryNoteJp OR @DieHistoryNoteJp IS NULL)
	AND ([ReleaseID] = @ReleaseId OR @ReleaseId IS NULL)
	AND ([UserID] = @UserId OR @UserId IS NULL)
	AND ([Owner] = @Owner OR @Owner IS NULL)
	AND ([LastUserUpdate] = @LastUserUpdate OR @LastUserUpdate IS NULL)
	AND ([LastTimeUpdate] = @LastTimeUpdate OR @LastTimeUpdate IS NULL)
	AND ([ActionTypeID] = @ActionTypeId OR @ActionTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIEHistoryID]
	, [DIERequestID]
	, [DIEDateSubmit]
	, [DIEStatus]
	, [DIEHistoryNote]
	, [DIEHistoryNoteJP]
	, [ReleaseID]
	, [UserID]
	, [Owner]
	, [LastUserUpdate]
	, [LastTimeUpdate]
	, [ActionTypeID]
    FROM
	[dbo].[tblDIEHistory]
    WHERE 
	 ([DIEHistoryID] = @DieHistoryId AND @DieHistoryId is not null)
	OR ([DIERequestID] = @DieRequestId AND @DieRequestId is not null)
	OR ([DIEDateSubmit] = @DieDateSubmit AND @DieDateSubmit is not null)
	OR ([DIEStatus] = @DieStatus AND @DieStatus is not null)
	OR ([DIEHistoryNote] = @DieHistoryNote AND @DieHistoryNote is not null)
	OR ([DIEHistoryNoteJP] = @DieHistoryNoteJp AND @DieHistoryNoteJp is not null)
	OR ([ReleaseID] = @ReleaseId AND @ReleaseId is not null)
	OR ([UserID] = @UserId AND @UserId is not null)
	OR ([Owner] = @Owner AND @Owner is not null)
	OR ([LastUserUpdate] = @LastUserUpdate AND @LastUserUpdate is not null)
	OR ([LastTimeUpdate] = @LastTimeUpdate AND @LastTimeUpdate is not null)
	OR ([ActionTypeID] = @ActionTypeId AND @ActionTypeId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_Get_List

AS


				
				SELECT
					[UserID],
					[UserName],
					[PassWord],
					[QlnsID],
					[Email],
					[EmployeeName],
					[Remove],
					[IsLoginSystem],
					[UpdateDate],
					[UserUpdate],
					[PageDefaultLogin],
					[DateCreated],
					[DateRemoved],
					[IsNoBody]
				FROM
					[dbo].[tblUser]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblUser table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [UserID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([UserID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [UserID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblUser]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[UserID], O.[UserName], O.[PassWord], O.[QlnsID], O.[Email], O.[EmployeeName], O.[Remove], O.[IsLoginSystem], O.[UpdateDate], O.[UserUpdate], O.[PageDefaultLogin], O.[DateCreated], O.[DateRemoved], O.[IsNoBody]
				FROM
				    [dbo].[tblUser] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[UserID] = PageIndex.[UserID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblUser]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_Insert
(

	@UserId int    OUTPUT,

	@UserName nvarchar (50)  ,

	@PassWord nvarchar (50)  ,

	@QlnsId int   ,

	@Email nvarchar (100)  ,

	@EmployeeName nvarchar (100)  ,

	@Remove bit   ,

	@IsLoginSystem bit   ,

	@UpdateDate datetime   ,

	@UserUpdate int   ,

	@PageDefaultLogin nvarchar (1000)  ,

	@DateCreated datetime   ,

	@DateRemoved datetime   ,

	@IsNoBody bit   
)
AS


				
				INSERT INTO [dbo].[tblUser]
					(
					[UserName]
					,[PassWord]
					,[QlnsID]
					,[Email]
					,[EmployeeName]
					,[Remove]
					,[IsLoginSystem]
					,[UpdateDate]
					,[UserUpdate]
					,[PageDefaultLogin]
					,[DateCreated]
					,[DateRemoved]
					,[IsNoBody]
					)
				VALUES
					(
					@UserName
					,@PassWord
					,@QlnsId
					,@Email
					,@EmployeeName
					,@Remove
					,@IsLoginSystem
					,@UpdateDate
					,@UserUpdate
					,@PageDefaultLogin
					,@DateCreated
					,@DateRemoved
					,@IsNoBody
					)
				
				-- Get the identity value
				SET @UserId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_Update
(

	@UserId int   ,

	@UserName nvarchar (50)  ,

	@PassWord nvarchar (50)  ,

	@QlnsId int   ,

	@Email nvarchar (100)  ,

	@EmployeeName nvarchar (100)  ,

	@Remove bit   ,

	@IsLoginSystem bit   ,

	@UpdateDate datetime   ,

	@UserUpdate int   ,

	@PageDefaultLogin nvarchar (1000)  ,

	@DateCreated datetime   ,

	@DateRemoved datetime   ,

	@IsNoBody bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblUser]
				SET
					[UserName] = @UserName
					,[PassWord] = @PassWord
					,[QlnsID] = @QlnsId
					,[Email] = @Email
					,[EmployeeName] = @EmployeeName
					,[Remove] = @Remove
					,[IsLoginSystem] = @IsLoginSystem
					,[UpdateDate] = @UpdateDate
					,[UserUpdate] = @UserUpdate
					,[PageDefaultLogin] = @PageDefaultLogin
					,[DateCreated] = @DateCreated
					,[DateRemoved] = @DateRemoved
					,[IsNoBody] = @IsNoBody
				WHERE
[UserID] = @UserId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_Delete
(

	@UserId int   
)
AS


				DELETE FROM [dbo].[tblUser] WITH (ROWLOCK) 
				WHERE
					[UserID] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblUser table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_GetByUserId
(

	@UserId int   
)
AS


				SELECT
					[UserID],
					[UserName],
					[PassWord],
					[QlnsID],
					[Email],
					[EmployeeName],
					[Remove],
					[IsLoginSystem],
					[UpdateDate],
					[UserUpdate],
					[PageDefaultLogin],
					[DateCreated],
					[DateRemoved],
					[IsNoBody]
				FROM
					[dbo].[tblUser]
				WHERE
					[UserID] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_GetByUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_GetByUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_GetByUserName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblUser table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_GetByUserName
(

	@UserName nvarchar (50)  
)
AS


				SELECT
					[UserID],
					[UserName],
					[PassWord],
					[QlnsID],
					[Email],
					[EmployeeName],
					[Remove],
					[IsLoginSystem],
					[UpdateDate],
					[UserUpdate],
					[PageDefaultLogin],
					[DateCreated],
					[DateRemoved],
					[IsNoBody]
				FROM
					[dbo].[tblUser]
				WHERE
					[UserName] = @UserName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblUser_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblUser_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblUser_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblUser table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblUser_Find
(

	@SearchUsingOR bit   = null ,

	@UserId int   = null ,

	@UserName nvarchar (50)  = null ,

	@PassWord nvarchar (50)  = null ,

	@QlnsId int   = null ,

	@Email nvarchar (100)  = null ,

	@EmployeeName nvarchar (100)  = null ,

	@Remove bit   = null ,

	@IsLoginSystem bit   = null ,

	@UpdateDate datetime   = null ,

	@UserUpdate int   = null ,

	@PageDefaultLogin nvarchar (1000)  = null ,

	@DateCreated datetime   = null ,

	@DateRemoved datetime   = null ,

	@IsNoBody bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserID]
	, [UserName]
	, [PassWord]
	, [QlnsID]
	, [Email]
	, [EmployeeName]
	, [Remove]
	, [IsLoginSystem]
	, [UpdateDate]
	, [UserUpdate]
	, [PageDefaultLogin]
	, [DateCreated]
	, [DateRemoved]
	, [IsNoBody]
    FROM
	[dbo].[tblUser]
    WHERE 
	 ([UserID] = @UserId OR @UserId IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([PassWord] = @PassWord OR @PassWord IS NULL)
	AND ([QlnsID] = @QlnsId OR @QlnsId IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([EmployeeName] = @EmployeeName OR @EmployeeName IS NULL)
	AND ([Remove] = @Remove OR @Remove IS NULL)
	AND ([IsLoginSystem] = @IsLoginSystem OR @IsLoginSystem IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UserUpdate] = @UserUpdate OR @UserUpdate IS NULL)
	AND ([PageDefaultLogin] = @PageDefaultLogin OR @PageDefaultLogin IS NULL)
	AND ([DateCreated] = @DateCreated OR @DateCreated IS NULL)
	AND ([DateRemoved] = @DateRemoved OR @DateRemoved IS NULL)
	AND ([IsNoBody] = @IsNoBody OR @IsNoBody IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserID]
	, [UserName]
	, [PassWord]
	, [QlnsID]
	, [Email]
	, [EmployeeName]
	, [Remove]
	, [IsLoginSystem]
	, [UpdateDate]
	, [UserUpdate]
	, [PageDefaultLogin]
	, [DateCreated]
	, [DateRemoved]
	, [IsNoBody]
    FROM
	[dbo].[tblUser]
    WHERE 
	 ([UserID] = @UserId AND @UserId is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([PassWord] = @PassWord AND @PassWord is not null)
	OR ([QlnsID] = @QlnsId AND @QlnsId is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([EmployeeName] = @EmployeeName AND @EmployeeName is not null)
	OR ([Remove] = @Remove AND @Remove is not null)
	OR ([IsLoginSystem] = @IsLoginSystem AND @IsLoginSystem is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UserUpdate] = @UserUpdate AND @UserUpdate is not null)
	OR ([PageDefaultLogin] = @PageDefaultLogin AND @PageDefaultLogin is not null)
	OR ([DateCreated] = @DateCreated AND @DateCreated is not null)
	OR ([DateRemoved] = @DateRemoved AND @DateRemoved is not null)
	OR ([IsNoBody] = @IsNoBody AND @IsNoBody is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_Get_List

AS


				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDIERequest table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [DIERequestID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([DIERequestID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [DIERequestID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIERequest]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[DIERequestID], O.[DIEName], O.[DIETag], O.[DIEDescription], O.[DIETypeID], O.[ResolutionsID], O.[UserID], O.[ProjectID], O.[DIEStatus], O.[PriorityDIERequestID], O.[DIEDateSubmit], O.[CodeBy], O.[Owner], O.[UpdateTime], O.[LastUserUpdate], O.[TargetDate], O.[CompletedReleaseID], O.[MilestoneID], O.[DIECategoryID], O.[Estimated], O.[Actual], O.[ParentDie]
				FROM
				    [dbo].[tblDIERequest] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[DIERequestID] = PageIndex.[DIERequestID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDIERequest]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_Insert
(

	@DieRequestId int    OUTPUT,

	@DieName nvarchar (400)  ,

	@DieTag nvarchar (250)  ,

	@DieDescription ntext   ,

	@DieTypeId int   ,

	@ResolutionsId int   ,

	@UserId int   ,

	@ProjectId int   ,

	@DieStatus int   ,

	@PriorityDieRequestId int   ,

	@DieDateSubmit datetime   ,

	@CodeBy int   ,

	@Owner int   ,

	@UpdateTime datetime   ,

	@LastUserUpdate int   ,

	@TargetDate datetime   ,

	@CompletedReleaseId int   ,

	@MilestoneId int   ,

	@DieCategoryId int   ,

	@Estimated float   ,

	@Actual float   ,

	@ParentDie int   
)
AS


				
				INSERT INTO [dbo].[tblDIERequest]
					(
					[DIEName]
					,[DIETag]
					,[DIEDescription]
					,[DIETypeID]
					,[ResolutionsID]
					,[UserID]
					,[ProjectID]
					,[DIEStatus]
					,[PriorityDIERequestID]
					,[DIEDateSubmit]
					,[CodeBy]
					,[Owner]
					,[UpdateTime]
					,[LastUserUpdate]
					,[TargetDate]
					,[CompletedReleaseID]
					,[MilestoneID]
					,[DIECategoryID]
					,[Estimated]
					,[Actual]
					,[ParentDie]
					)
				VALUES
					(
					@DieName
					,@DieTag
					,@DieDescription
					,@DieTypeId
					,@ResolutionsId
					,@UserId
					,@ProjectId
					,@DieStatus
					,@PriorityDieRequestId
					,@DieDateSubmit
					,@CodeBy
					,@Owner
					,@UpdateTime
					,@LastUserUpdate
					,@TargetDate
					,@CompletedReleaseId
					,@MilestoneId
					,@DieCategoryId
					,@Estimated
					,@Actual
					,@ParentDie
					)
				
				-- Get the identity value
				SET @DieRequestId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_Update
(

	@DieRequestId int   ,

	@DieName nvarchar (400)  ,

	@DieTag nvarchar (250)  ,

	@DieDescription ntext   ,

	@DieTypeId int   ,

	@ResolutionsId int   ,

	@UserId int   ,

	@ProjectId int   ,

	@DieStatus int   ,

	@PriorityDieRequestId int   ,

	@DieDateSubmit datetime   ,

	@CodeBy int   ,

	@Owner int   ,

	@UpdateTime datetime   ,

	@LastUserUpdate int   ,

	@TargetDate datetime   ,

	@CompletedReleaseId int   ,

	@MilestoneId int   ,

	@DieCategoryId int   ,

	@Estimated float   ,

	@Actual float   ,

	@ParentDie int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDIERequest]
				SET
					[DIEName] = @DieName
					,[DIETag] = @DieTag
					,[DIEDescription] = @DieDescription
					,[DIETypeID] = @DieTypeId
					,[ResolutionsID] = @ResolutionsId
					,[UserID] = @UserId
					,[ProjectID] = @ProjectId
					,[DIEStatus] = @DieStatus
					,[PriorityDIERequestID] = @PriorityDieRequestId
					,[DIEDateSubmit] = @DieDateSubmit
					,[CodeBy] = @CodeBy
					,[Owner] = @Owner
					,[UpdateTime] = @UpdateTime
					,[LastUserUpdate] = @LastUserUpdate
					,[TargetDate] = @TargetDate
					,[CompletedReleaseID] = @CompletedReleaseId
					,[MilestoneID] = @MilestoneId
					,[DIECategoryID] = @DieCategoryId
					,[Estimated] = @Estimated
					,[Actual] = @Actual
					,[ParentDie] = @ParentDie
				WHERE
[DIERequestID] = @DieRequestId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDIERequest table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_Delete
(

	@DieRequestId int   
)
AS


				DELETE FROM [dbo].[tblDIERequest] WITH (ROWLOCK) 
				WHERE
					[DIERequestID] = @DieRequestId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByDieCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByDieCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByDieCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByDieCategoryId
(

	@DieCategoryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[DIECategoryID] = @DieCategoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByParentDie procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByParentDie') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByParentDie
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByParentDie
(

	@ParentDie int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[ParentDie] = @ParentDie
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByDieStatus procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByDieStatus') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByDieStatus
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByDieStatus
(

	@DieStatus int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[DIEStatus] = @DieStatus
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByDieTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByDieTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByDieTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByDieTypeId
(

	@DieTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[DIETypeID] = @DieTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByMilestoneId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByMilestoneId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByMilestoneId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByMilestoneId
(

	@MilestoneId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[MilestoneID] = @MilestoneId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByPriorityDieRequestId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByPriorityDieRequestId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByPriorityDieRequestId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByPriorityDieRequestId
(

	@PriorityDieRequestId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[PriorityDIERequestID] = @PriorityDieRequestId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByProjectId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByProjectId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByProjectId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByProjectId
(

	@ProjectId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[ProjectID] = @ProjectId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByCompletedReleaseId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByCompletedReleaseId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByCompletedReleaseId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByCompletedReleaseId
(

	@CompletedReleaseId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[CompletedReleaseID] = @CompletedReleaseId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByResolutionsId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByResolutionsId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByResolutionsId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByResolutionsId
(

	@ResolutionsId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[ResolutionsID] = @ResolutionsId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByUserId
(

	@UserId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[UserID] = @UserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByCodeBy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByCodeBy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByCodeBy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByCodeBy
(

	@CodeBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[CodeBy] = @CodeBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByOwner procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByOwner') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByOwner
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByOwner
(

	@Owner int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[Owner] = @Owner
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByLastUserUpdate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByLastUserUpdate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByLastUserUpdate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByLastUserUpdate
(

	@LastUserUpdate int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[LastUserUpdate] = @LastUserUpdate
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_GetByDieRequestId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_GetByDieRequestId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_GetByDieRequestId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDIERequest table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_GetByDieRequestId
(

	@DieRequestId int   
)
AS


				SELECT
					[DIERequestID],
					[DIEName],
					[DIETag],
					[DIEDescription],
					[DIETypeID],
					[ResolutionsID],
					[UserID],
					[ProjectID],
					[DIEStatus],
					[PriorityDIERequestID],
					[DIEDateSubmit],
					[CodeBy],
					[Owner],
					[UpdateTime],
					[LastUserUpdate],
					[TargetDate],
					[CompletedReleaseID],
					[MilestoneID],
					[DIECategoryID],
					[Estimated],
					[Actual],
					[ParentDie]
				FROM
					[dbo].[tblDIERequest]
				WHERE
					[DIERequestID] = @DieRequestId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDIERequest_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDIERequest_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDIERequest_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDIERequest table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDIERequest_Find
(

	@SearchUsingOR bit   = null ,

	@DieRequestId int   = null ,

	@DieName nvarchar (400)  = null ,

	@DieTag nvarchar (250)  = null ,

	@DieDescription ntext   = null ,

	@DieTypeId int   = null ,

	@ResolutionsId int   = null ,

	@UserId int   = null ,

	@ProjectId int   = null ,

	@DieStatus int   = null ,

	@PriorityDieRequestId int   = null ,

	@DieDateSubmit datetime   = null ,

	@CodeBy int   = null ,

	@Owner int   = null ,

	@UpdateTime datetime   = null ,

	@LastUserUpdate int   = null ,

	@TargetDate datetime   = null ,

	@CompletedReleaseId int   = null ,

	@MilestoneId int   = null ,

	@DieCategoryId int   = null ,

	@Estimated float   = null ,

	@Actual float   = null ,

	@ParentDie int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DIERequestID]
	, [DIEName]
	, [DIETag]
	, [DIEDescription]
	, [DIETypeID]
	, [ResolutionsID]
	, [UserID]
	, [ProjectID]
	, [DIEStatus]
	, [PriorityDIERequestID]
	, [DIEDateSubmit]
	, [CodeBy]
	, [Owner]
	, [UpdateTime]
	, [LastUserUpdate]
	, [TargetDate]
	, [CompletedReleaseID]
	, [MilestoneID]
	, [DIECategoryID]
	, [Estimated]
	, [Actual]
	, [ParentDie]
    FROM
	[dbo].[tblDIERequest]
    WHERE 
	 ([DIERequestID] = @DieRequestId OR @DieRequestId IS NULL)
	AND ([DIEName] = @DieName OR @DieName IS NULL)
	AND ([DIETag] = @DieTag OR @DieTag IS NULL)
	AND ([DIETypeID] = @DieTypeId OR @DieTypeId IS NULL)
	AND ([ResolutionsID] = @ResolutionsId OR @ResolutionsId IS NULL)
	AND ([UserID] = @UserId OR @UserId IS NULL)
	AND ([ProjectID] = @ProjectId OR @ProjectId IS NULL)
	AND ([DIEStatus] = @DieStatus OR @DieStatus IS NULL)
	AND ([PriorityDIERequestID] = @PriorityDieRequestId OR @PriorityDieRequestId IS NULL)
	AND ([DIEDateSubmit] = @DieDateSubmit OR @DieDateSubmit IS NULL)
	AND ([CodeBy] = @CodeBy OR @CodeBy IS NULL)
	AND ([Owner] = @Owner OR @Owner IS NULL)
	AND ([UpdateTime] = @UpdateTime OR @UpdateTime IS NULL)
	AND ([LastUserUpdate] = @LastUserUpdate OR @LastUserUpdate IS NULL)
	AND ([TargetDate] = @TargetDate OR @TargetDate IS NULL)
	AND ([CompletedReleaseID] = @CompletedReleaseId OR @CompletedReleaseId IS NULL)
	AND ([MilestoneID] = @MilestoneId OR @MilestoneId IS NULL)
	AND ([DIECategoryID] = @DieCategoryId OR @DieCategoryId IS NULL)
	AND ([Estimated] = @Estimated OR @Estimated IS NULL)
	AND ([Actual] = @Actual OR @Actual IS NULL)
	AND ([ParentDie] = @ParentDie OR @ParentDie IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DIERequestID]
	, [DIEName]
	, [DIETag]
	, [DIEDescription]
	, [DIETypeID]
	, [ResolutionsID]
	, [UserID]
	, [ProjectID]
	, [DIEStatus]
	, [PriorityDIERequestID]
	, [DIEDateSubmit]
	, [CodeBy]
	, [Owner]
	, [UpdateTime]
	, [LastUserUpdate]
	, [TargetDate]
	, [CompletedReleaseID]
	, [MilestoneID]
	, [DIECategoryID]
	, [Estimated]
	, [Actual]
	, [ParentDie]
    FROM
	[dbo].[tblDIERequest]
    WHERE 
	 ([DIERequestID] = @DieRequestId AND @DieRequestId is not null)
	OR ([DIEName] = @DieName AND @DieName is not null)
	OR ([DIETag] = @DieTag AND @DieTag is not null)
	OR ([DIETypeID] = @DieTypeId AND @DieTypeId is not null)
	OR ([ResolutionsID] = @ResolutionsId AND @ResolutionsId is not null)
	OR ([UserID] = @UserId AND @UserId is not null)
	OR ([ProjectID] = @ProjectId AND @ProjectId is not null)
	OR ([DIEStatus] = @DieStatus AND @DieStatus is not null)
	OR ([PriorityDIERequestID] = @PriorityDieRequestId AND @PriorityDieRequestId is not null)
	OR ([DIEDateSubmit] = @DieDateSubmit AND @DieDateSubmit is not null)
	OR ([CodeBy] = @CodeBy AND @CodeBy is not null)
	OR ([Owner] = @Owner AND @Owner is not null)
	OR ([UpdateTime] = @UpdateTime AND @UpdateTime is not null)
	OR ([LastUserUpdate] = @LastUserUpdate AND @LastUserUpdate is not null)
	OR ([TargetDate] = @TargetDate AND @TargetDate is not null)
	OR ([CompletedReleaseID] = @CompletedReleaseId AND @CompletedReleaseId is not null)
	OR ([MilestoneID] = @MilestoneId AND @MilestoneId is not null)
	OR ([DIECategoryID] = @DieCategoryId AND @DieCategoryId is not null)
	OR ([Estimated] = @Estimated AND @Estimated is not null)
	OR ([Actual] = @Actual AND @Actual is not null)
	OR ([ParentDie] = @ParentDie AND @ParentDie is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HomeDIERequest_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HomeDIERequest_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HomeDIERequest_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the HomeDIERequest view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HomeDIERequest_Get_List

AS


				
				SELECT
					[DIEName],
					[DIERequestID],
					[DIETag],
					[DIEDescription],
					[UpdateUserID],
					[ProjectID],
					[DIEDateSubmit],
					[DIENameStatus],
					[DIETypeName],
					[PriorityDIERequestName],
					[Color],
					[ColorName],
					[DIEStatus],
					[UpdateTime],
					[UpdatedUsername],
					[TargetDate],
					[Estimated],
					[Actual],
					[UserName],
					[UpdatedUserID],
					[DIESubmitDateOnly]
				FROM
					[dbo].[HomeDIERequest]
					
				SELECT @@ROWCOUNT			
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HomeDIERequest_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HomeDIERequest_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HomeDIERequest_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the HomeDIERequest view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HomeDIERequest_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


				
				BEGIN

				-- Build the sql query
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = ' SELECT * FROM [dbo].[HomeDIERequest]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Execution the query
				EXEC sp_executesql @SQL
				
				-- Return total count
				SELECT @@ROWCOUNT AS TotalRowCount
				
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

