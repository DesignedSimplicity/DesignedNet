
--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_List')
	BEGIN
		PRINT 'Dropping Procedure Company_List'
		DROP PROCEDURE Company_List 
	END

GO

PRINT 'Creating Procedure Company_List'
GO

CREATE PROCEDURE Company_List
AS

SELECT
	CompanyID, 
	CompanyTypeID, 
	CompanyStatusID, 
	CompanyName, 
	LocationName, 
	StreetAddress, 
	Region, 
	City, 
	State, 
	Zip, 
	Phone, 
	Fax, 
	Website, 
	Description, 
	Created, 
	Updated 
	FROM [Company]



GO

GRANT EXEC ON Company_List TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_Select')
	BEGIN
		PRINT 'Dropping Procedure Company_Select'
		DROP PROCEDURE Company_Select 
	END

GO

PRINT 'Creating Procedure Company_Select'
GO

CREATE PROCEDURE Company_Select
(
	@CompanyID	int
)
AS

SELECT
	CompanyID, 
	CompanyTypeID, 
	CompanyStatusID, 
	CompanyName, 
	LocationName, 
	StreetAddress, 
	Region, 
	City, 
	State, 
	Zip, 
	Phone, 
	Fax, 
	Website, 
	Description, 
	Created, 
	Updated 
	FROM [Company]
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Company_Select TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_Insert')
	BEGIN
		PRINT 'Dropping Procedure Company_Insert'
		DROP PROCEDURE Company_Insert 
	END

GO

PRINT 'Creating Procedure Company_Insert'
GO

CREATE PROCEDURE Company_Insert
(
	@CompanyID	int output,  
	@CompanyTypeID	int,  
	@CompanyStatusID	int,  
	@CompanyName	varchar (100),  
	@LocationName	varchar (100),  
	@StreetAddress	varchar (100),  
	@Region	varchar (50),  
	@City	varchar (50),  
	@State	varchar (10),  
	@Zip	varchar (10),  
	@Phone	varchar (50),  
	@Fax	varchar (50),  
	@Website	varchar (50),  
	@Description	varchar (5000) 
	 
)
AS

INSERT INTO [Company]
	( CompanyTypeID, CompanyStatusID, CompanyName, LocationName, StreetAddress, Region, City, State, Zip, Phone, Fax, Website, Description, Created )
	VALUES ( @CompanyTypeID, @CompanyStatusID, @CompanyName, @LocationName, @StreetAddress, @Region, @City, @State, @Zip, @Phone, @Fax, @Website, @Description, getdate() )
		
SET @CompanyID = @@IDENTITY



GO

GRANT EXEC ON Company_Insert TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_Update')
	BEGIN
		PRINT 'Dropping Procedure Company_Update'
		DROP PROCEDURE Company_Update 
	END

GO

PRINT 'Creating Procedure Company_Update'
GO

CREATE PROCEDURE Company_Update
(
	@CompanyID	int,  
	@CompanyTypeID	int,  
	@CompanyStatusID	int,  
	@CompanyName	varchar (100),  
	@LocationName	varchar (100),  
	@StreetAddress	varchar (100),  
	@Region	varchar (50),  
	@City	varchar (50),  
	@State	varchar (10),  
	@Zip	varchar (10),  
	@Phone	varchar (50),  
	@Fax	varchar (50),  
	@Website	varchar (50),  
	@Description	varchar (5000) 
	 
)
AS


UPDATE [Company]
	SET
		CompanyTypeID = @CompanyTypeID,  
		CompanyStatusID = @CompanyStatusID,  
		CompanyName = @CompanyName,  
		LocationName = @LocationName,  
		StreetAddress = @StreetAddress,  
		Region = @Region,  
		City = @City,  
		State = @State,  
		Zip = @Zip,  
		Phone = @Phone,  
		Fax = @Fax,  
		Website = @Website,  
		Description = @Description,  
		Updated = getdate() 
		
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Company_Update TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_Delete')
	BEGIN
		PRINT 'Dropping Procedure Company_Delete'
		DROP PROCEDURE Company_Delete 
	END

GO

PRINT 'Creating Procedure Company_Delete'
GO

CREATE PROCEDURE Company_Delete
(
	@CompanyID	int
)
AS


DELETE [Company]
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Company_Delete TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_Exists')
	BEGIN
		PRINT 'Dropping Procedure Company_Exists'
		DROP PROCEDURE Company_Exists 
	END

GO

PRINT 'Creating Procedure Company_Exists'
GO

CREATE PROCEDURE Company_Exists
(
	@CompanyID	int
)
AS

SELECT COUNT(*) AS [Exists]
	FROM [Company]
	WHERE CompanyID = @CompanyID

GO

GRANT EXEC ON Company_Exists TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_ListByCompanyTypeID')
	BEGIN
		PRINT 'Dropping Procedure Company_ListByCompanyTypeID'
		DROP PROCEDURE Company_ListByCompanyTypeID 
	END

GO

PRINT 'Creating Procedure Company_ListByCompanyTypeID'
GO

CREATE PROCEDURE Company_ListByCompanyTypeID
(
	@CompanyTypeID	int
)
AS

SELECT
	CompanyID, 
	CompanyTypeID, 
	CompanyStatusID, 
	CompanyName, 
	LocationName, 
	StreetAddress, 
	Region, 
	City, 
	State, 
	Zip, 
	Phone, 
	Fax, 
	Website, 
	Description, 
	Created, 
	Updated 
	FROM [Company]
	WHERE CompanyTypeID = @CompanyTypeID

GO

GRANT EXEC ON Company_ListByCompanyTypeID TO PUBLIC

--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = 'Company_ListByCompanyStatusID')
	BEGIN
		PRINT 'Dropping Procedure Company_ListByCompanyStatusID'
		DROP PROCEDURE Company_ListByCompanyStatusID 
	END

GO

PRINT 'Creating Procedure Company_ListByCompanyStatusID'
GO

CREATE PROCEDURE Company_ListByCompanyStatusID
(
	@CompanyStatusID	int
)
AS

SELECT
	CompanyID, 
	CompanyTypeID, 
	CompanyStatusID, 
	CompanyName, 
	LocationName, 
	StreetAddress, 
	Region, 
	City, 
	State, 
	Zip, 
	Phone, 
	Fax, 
	Website, 
	Description, 
	Created, 
	Updated 
	FROM [Company]
	WHERE CompanyStatusID = @CompanyStatusID

GO

GRANT EXEC ON Company_ListByCompanyStatusID TO PUBLIC
