
--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_List')
	BEGIN
		PRINT 'Dropping Procedure Contact_List'
		DROP PROCEDURE Contact_List 
	END

GO

PRINT 'Creating Procedure Contact_List'
GO

CREATE PROCEDURE Contact_List
AS

SELECT
	ContactID, 
	ContactTypeID, 
	ContactStatusID, 
	CompanyID, 
	SessionID, 
	Prefix, 
	FirstName, 
	LastName, 
	JobTitle, 
	OfficeNumber, 
	MobileNumber, 
	HomeNumber, 
	OtherNumber, 
	FaxNumber, 
	EmailAddress, 
	Description, 
	Username, 
	Password, 
	Created, 
	Updated, 
	LastLogin 
	FROM [Contact]



GO

GRANT EXEC ON Contact_List TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_Select')
	BEGIN
		PRINT 'Dropping Procedure Contact_Select'
		DROP PROCEDURE Contact_Select 
	END

GO

PRINT 'Creating Procedure Contact_Select'
GO

CREATE PROCEDURE Contact_Select
(
	@ContactID	int
)
AS

SELECT
	ContactID, 
	ContactTypeID, 
	ContactStatusID, 
	CompanyID, 
	SessionID, 
	Prefix, 
	FirstName, 
	LastName, 
	JobTitle, 
	OfficeNumber, 
	MobileNumber, 
	HomeNumber, 
	OtherNumber, 
	FaxNumber, 
	EmailAddress, 
	Description, 
	Username, 
	Password, 
	Created, 
	Updated, 
	LastLogin 
	FROM [Contact]
	WHERE ContactID = @ContactID

GO

GRANT EXEC ON Contact_Select TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_Insert')
	BEGIN
		PRINT 'Dropping Procedure Contact_Insert'
		DROP PROCEDURE Contact_Insert 
	END

GO

PRINT 'Creating Procedure Contact_Insert'
GO

CREATE PROCEDURE Contact_Insert
(
	@ContactID	int output,  
	@ContactTypeID	int,  
	@ContactStatusID	int,  
	@CompanyID	int,  
	@SessionID	uniqueidentifier,  
	@Prefix	varchar (10),  
	@FirstName	varchar (50),  
	@LastName	varchar (50),  
	@JobTitle	varchar (50),  
	@OfficeNumber	varchar (50),  
	@MobileNumber	varchar (50),  
	@HomeNumber	varchar (50),  
	@OtherNumber	varchar (50),  
	@FaxNumber	varchar (50),  
	@EmailAddress	varchar (100),  
	@Description	varchar (500),  
	@Username	varchar (50),  
	@Password	varchar (50),  
	@LastLogin	datetime 
	 
)
AS

INSERT INTO [Contact]
	( ContactTypeID, ContactStatusID, CompanyID, SessionID, Prefix, FirstName, LastName, JobTitle, OfficeNumber, MobileNumber, HomeNumber, OtherNumber, FaxNumber, EmailAddress, Description, Username, Password, Created, LastLogin )
	VALUES ( @ContactTypeID, @ContactStatusID, @CompanyID, @SessionID, @Prefix, @FirstName, @LastName, @JobTitle, @OfficeNumber, @MobileNumber, @HomeNumber, @OtherNumber, @FaxNumber, @EmailAddress, @Description, @Username, @Password, getdate(), @LastLogin )
		
SET @ContactID = @@IDENTITY



GO

GRANT EXEC ON Contact_Insert TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_Update')
	BEGIN
		PRINT 'Dropping Procedure Contact_Update'
		DROP PROCEDURE Contact_Update 
	END

GO

PRINT 'Creating Procedure Contact_Update'
GO

CREATE PROCEDURE Contact_Update
(
	@ContactID	int,  
	@ContactTypeID	int,  
	@ContactStatusID	int,  
	@CompanyID	int,  
	@SessionID	uniqueidentifier,  
	@Prefix	varchar (10),  
	@FirstName	varchar (50),  
	@LastName	varchar (50),  
	@JobTitle	varchar (50),  
	@OfficeNumber	varchar (50),  
	@MobileNumber	varchar (50),  
	@HomeNumber	varchar (50),  
	@OtherNumber	varchar (50),  
	@FaxNumber	varchar (50),  
	@EmailAddress	varchar (100),  
	@Description	varchar (500),  
	@Username	varchar (50),  
	@Password	varchar (50),  
	@LastLogin	datetime 
	 
)
AS


UPDATE [Contact]
	SET
		ContactTypeID = @ContactTypeID,  
		ContactStatusID = @ContactStatusID,  
		CompanyID = @CompanyID,  
		SessionID = @SessionID,  
		Prefix = @Prefix,  
		FirstName = @FirstName,  
		LastName = @LastName,  
		JobTitle = @JobTitle,  
		OfficeNumber = @OfficeNumber,  
		MobileNumber = @MobileNumber,  
		HomeNumber = @HomeNumber,  
		OtherNumber = @OtherNumber,  
		FaxNumber = @FaxNumber,  
		EmailAddress = @EmailAddress,  
		Description = @Description,  
		Username = @Username,  
		Password = @Password,  
		Updated = getdate(),  
		LastLogin = @LastLogin 
		
	WHERE ContactID = @ContactID

GO

GRANT EXEC ON Contact_Update TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_Delete')
	BEGIN
		PRINT 'Dropping Procedure Contact_Delete'
		DROP PROCEDURE Contact_Delete 
	END

GO

PRINT 'Creating Procedure Contact_Delete'
GO

CREATE PROCEDURE Contact_Delete
(
	@ContactID	int
)
AS


DELETE [Contact]
	WHERE ContactID = @ContactID

GO

GRANT EXEC ON Contact_Delete TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_Exists')
	BEGIN
		PRINT 'Dropping Procedure Contact_Exists'
		DROP PROCEDURE Contact_Exists 
	END

GO

PRINT 'Creating Procedure Contact_Exists'
GO

CREATE PROCEDURE Contact_Exists
(
	@ContactID	int
)
AS

SELECT COUNT(*) AS [Exists]
	FROM [Contact]
	WHERE ContactID = @ContactID

GO

GRANT EXEC ON Contact_Exists TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_ListByContactTypeID')
	BEGIN
		PRINT 'Dropping Procedure Contact_ListByContactTypeID'
		DROP PROCEDURE Contact_ListByContactTypeID 
	END

GO

PRINT 'Creating Procedure Contact_ListByContactTypeID'
GO

CREATE PROCEDURE Contact_ListByContactTypeID
(
	@ContactTypeID	int
)
AS

SELECT
	ContactID, 
	ContactTypeID, 
	ContactStatusID, 
	CompanyID, 
	SessionID, 
	Prefix, 
	FirstName, 
	LastName, 
	JobTitle, 
	OfficeNumber, 
	MobileNumber, 
	HomeNumber, 
	OtherNumber, 
	FaxNumber, 
	EmailAddress, 
	Description, 
	Username, 
	Password, 
	Created, 
	Updated, 
	LastLogin 
	FROM [Contact]
	WHERE ContactTypeID = @ContactTypeID

GO

GRANT EXEC ON Contact_ListByContactTypeID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_ListByContactStatusID')
	BEGIN
		PRINT 'Dropping Procedure Contact_ListByContactStatusID'
		DROP PROCEDURE Contact_ListByContactStatusID 
	END

GO

PRINT 'Creating Procedure Contact_ListByContactStatusID'
GO

CREATE PROCEDURE Contact_ListByContactStatusID
(
	@ContactStatusID	int
)
AS

SELECT
	ContactID, 
	ContactTypeID, 
	ContactStatusID, 
	CompanyID, 
	SessionID, 
	Prefix, 
	FirstName, 
	LastName, 
	JobTitle, 
	OfficeNumber, 
	MobileNumber, 
	HomeNumber, 
	OtherNumber, 
	FaxNumber, 
	EmailAddress, 
	Description, 
	Username, 
	Password, 
	Created, 
	Updated, 
	LastLogin 
	FROM [Contact]
	WHERE ContactStatusID = @ContactStatusID

GO

GRANT EXEC ON Contact_ListByContactStatusID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Contact_ListByCompanyID')
	BEGIN
		PRINT 'Dropping Procedure Contact_ListByCompanyID'
		DROP PROCEDURE Contact_ListByCompanyID 
	END

GO

PRINT 'Creating Procedure Contact_ListByCompanyID'
GO

CREATE PROCEDURE Contact_ListByCompanyID
(
	@CompanyID	int
)
AS

SELECT
	ContactID, 
	ContactTypeID, 
	ContactStatusID, 
	CompanyID, 
	SessionID, 
	Prefix, 
	FirstName, 
	LastName, 
	JobTitle, 
	OfficeNumber, 
	MobileNumber, 
	HomeNumber, 
	OtherNumber, 
	FaxNumber, 
	EmailAddress, 
	Description, 
	Username, 
	Password, 
	Created, 
	Updated, 
	LastLogin 
	FROM [Contact]
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Contact_ListByCompanyID TO PUBLIC
