
--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_List')
	BEGIN
		PRINT 'Dropping Procedure Comment_List'
		DROP PROCEDURE Comment_List 
	END

GO

PRINT 'Creating Procedure Comment_List'
GO

CREATE PROCEDURE Comment_List
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]



GO

GRANT EXEC ON Comment_List TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_Select')
	BEGIN
		PRINT 'Dropping Procedure Comment_Select'
		DROP PROCEDURE Comment_Select 
	END

GO

PRINT 'Creating Procedure Comment_Select'
GO

CREATE PROCEDURE Comment_Select
(
	@CommentID	int
)
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]
	WHERE CommentID = @CommentID

GO

GRANT EXEC ON Comment_Select TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_Insert')
	BEGIN
		PRINT 'Dropping Procedure Comment_Insert'
		DROP PROCEDURE Comment_Insert 
	END

GO

PRINT 'Creating Procedure Comment_Insert'
GO

CREATE PROCEDURE Comment_Insert
(
	@CommentID	int output,  
	@CommentTypeID	int,  
	@ProjectID	int,  
	@CompanyID	int,  
	@ContactID	int,  
	@CreatedByID	int,  
	@AssignedToID	int,  
	@Priority	int,  
	@Thread	varchar (50),  
	@Subject	varchar (500),  
	@Comment	varchar (5000),  
	@Reminder	datetime,  
	@Completed	datetime 
	 
)
AS

INSERT INTO [Comment]
	( CommentTypeID, ProjectID, CompanyID, ContactID, CreatedByID, AssignedToID, Priority, Thread, Subject, Comment, Created, Reminder, Completed )
	VALUES ( @CommentTypeID, @ProjectID, @CompanyID, @ContactID, @CreatedByID, @AssignedToID, @Priority, @Thread, @Subject, @Comment, getdate(), @Reminder, @Completed )
		
SET @CommentID = @@IDENTITY



GO

GRANT EXEC ON Comment_Insert TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_Update')
	BEGIN
		PRINT 'Dropping Procedure Comment_Update'
		DROP PROCEDURE Comment_Update 
	END

GO

PRINT 'Creating Procedure Comment_Update'
GO

CREATE PROCEDURE Comment_Update
(
	@CommentID	int,  
	@CommentTypeID	int,  
	@ProjectID	int,  
	@CompanyID	int,  
	@ContactID	int,  
	@CreatedByID	int,  
	@AssignedToID	int,  
	@Priority	int,  
	@Thread	varchar (50),  
	@Subject	varchar (500),  
	@Comment	varchar (5000),  
	@Reminder	datetime,  
	@Completed	datetime 
	 
)
AS


UPDATE [Comment]
	SET
		CommentTypeID = @CommentTypeID,  
		ProjectID = @ProjectID,  
		CompanyID = @CompanyID,  
		ContactID = @ContactID,  
		CreatedByID = @CreatedByID,  
		AssignedToID = @AssignedToID,  
		Priority = @Priority,  
		Thread = @Thread,  
		Subject = @Subject,  
		Comment = @Comment,  
		Updated = getdate(),  
		Reminder = @Reminder,  
		Completed = @Completed 
		
	WHERE CommentID = @CommentID

GO

GRANT EXEC ON Comment_Update TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_Delete')
	BEGIN
		PRINT 'Dropping Procedure Comment_Delete'
		DROP PROCEDURE Comment_Delete 
	END

GO

PRINT 'Creating Procedure Comment_Delete'
GO

CREATE PROCEDURE Comment_Delete
(
	@CommentID	int
)
AS


DELETE [Comment]
	WHERE CommentID = @CommentID

GO

GRANT EXEC ON Comment_Delete TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_Exists')
	BEGIN
		PRINT 'Dropping Procedure Comment_Exists'
		DROP PROCEDURE Comment_Exists 
	END

GO

PRINT 'Creating Procedure Comment_Exists'
GO

CREATE PROCEDURE Comment_Exists
(
	@CommentID	int
)
AS

SELECT COUNT(*) AS [Exists]
	FROM [Comment]
	WHERE CommentID = @CommentID

GO

GRANT EXEC ON Comment_Exists TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_ListByCommentTypeID')
	BEGIN
		PRINT 'Dropping Procedure Comment_ListByCommentTypeID'
		DROP PROCEDURE Comment_ListByCommentTypeID 
	END

GO

PRINT 'Creating Procedure Comment_ListByCommentTypeID'
GO

CREATE PROCEDURE Comment_ListByCommentTypeID
(
	@CommentTypeID	int
)
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]
	WHERE CommentTypeID = @CommentTypeID

GO

GRANT EXEC ON Comment_ListByCommentTypeID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_ListByProjectID')
	BEGIN
		PRINT 'Dropping Procedure Comment_ListByProjectID'
		DROP PROCEDURE Comment_ListByProjectID 
	END

GO

PRINT 'Creating Procedure Comment_ListByProjectID'
GO

CREATE PROCEDURE Comment_ListByProjectID
(
	@ProjectID	int
)
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]
	WHERE ProjectID = @ProjectID

GO

GRANT EXEC ON Comment_ListByProjectID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_ListByCompanyID')
	BEGIN
		PRINT 'Dropping Procedure Comment_ListByCompanyID'
		DROP PROCEDURE Comment_ListByCompanyID 
	END

GO

PRINT 'Creating Procedure Comment_ListByCompanyID'
GO

CREATE PROCEDURE Comment_ListByCompanyID
(
	@CompanyID	int
)
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Comment_ListByCompanyID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Comment_ListByContactID')
	BEGIN
		PRINT 'Dropping Procedure Comment_ListByContactID'
		DROP PROCEDURE Comment_ListByContactID 
	END

GO

PRINT 'Creating Procedure Comment_ListByContactID'
GO

CREATE PROCEDURE Comment_ListByContactID
(
	@ContactID	int
)
AS

SELECT
	CommentID, 
	CommentTypeID, 
	ProjectID, 
	CompanyID, 
	ContactID, 
	CreatedByID, 
	AssignedToID, 
	Priority, 
	Thread, 
	Subject, 
	Comment, 
	Created, 
	Updated, 
	Reminder, 
	Completed 
	FROM [Comment]
	WHERE ContactID = @ContactID

GO

GRANT EXEC ON Comment_ListByContactID TO PUBLIC
