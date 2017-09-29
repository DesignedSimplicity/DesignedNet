/********************************************************************************/
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//============================
using DesignedNet.Framework.Biz;
using Harkins.Dal;


//----------------------------
namespace Harkins.Biz
{
	/// <summary>Business logic class for sql server database table: Contact</summary>
	/// ================================================================================
	/// Object:	    Harkins.Biz.BizContact
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class BizContact : BizEntity
	{
		//========================================================
		//Field index constants
		//========================================================
		#region Field index constants

		private static Type[] _columnTypes = new Type[21] {typeof(int), typeof(int), typeof(int), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(DateTime)};
		private static string[] _columnNames = new string[21] {"ContactID", "ContactTypeID", "ContactStatusID", "CompanyID", "SessionID", "Prefix", "FirstName", "LastName", "JobTitle", "OfficeNumber", "MobileNumber", "HomeNumber", "OtherNumber", "FaxNumber", "EmailAddress", "Description", "Username", "Password", "Created", "Updated", "LastLogin"};

		// data column(s) name and index
		private const int _contactIDIndex = 0;
		private const int _contactTypeIDIndex = 1;
		private const int _contactStatusIDIndex = 2;
		private const int _companyIDIndex = 3;
		private const int _sessionIDIndex = 4;
		private const int _prefixIndex = 5;
		private const int _firstNameIndex = 6;
		private const int _lastNameIndex = 7;
		private const int _jobTitleIndex = 8;
		private const int _officeNumberIndex = 9;
		private const int _mobileNumberIndex = 10;
		private const int _homeNumberIndex = 11;
		private const int _otherNumberIndex = 12;
		private const int _faxNumberIndex = 13;
		private const int _emailAddressIndex = 14;
		private const int _descriptionIndex = 15;
		private const int _usernameIndex = 16;
		private const int _passwordIndex = 17;
		private const int _createdIndex = 18;
		private const int _updatedIndex = 19;
		private const int _lastLoginIndex = 20;

		#endregion
		

		//========================================================
		//Object constructors
		//========================================================
		public BizContact() : base("Contact") {}
		public BizContact(DataSet state) : base("Contact", state) {}


		//========================================================
		//Action verbs
		//========================================================
		#region Action verbs

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByContactType(int contactTypeID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalContact dal = (DalContact)_dal;
			dal.ListByContactType(contactTypeID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByContactStatus(int contactStatusID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalContact dal = (DalContact)_dal;
			dal.ListByContactStatus(contactStatusID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByCompany(int companyID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalContact dal = (DalContact)_dal;
			dal.ListByCompany(companyID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}
	
		#endregion
	
	
		//========================================================
		//Entity get/set methods
		//========================================================
		#region Entity get/set methods

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizContactType ContactType
		{
			get
			{
				BizContactType biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizContactType(_dataSet);
						if (!IsNull( _columnNames[_contactTypeIDIndex] )) biz.Find(_contactTypeID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizContactType();
						if (!IsNull( _columnNames[_contactTypeIDIndex] )) biz.Load(_contactTypeID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._contactTypeID = value._contactTypeID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizContactStatus ContactStatus
		{
			get
			{
				BizContactStatus biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizContactStatus(_dataSet);
						if (!IsNull( _columnNames[_contactStatusIDIndex] )) biz.Find(_contactStatusID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizContactStatus();
						if (!IsNull( _columnNames[_contactStatusIDIndex] )) biz.Load(_contactStatusID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._contactStatusID = value._contactStatusID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizCompany Company
		{
			get
			{
				BizCompany biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizCompany(_dataSet);
						if (!IsNull( _columnNames[_companyIDIndex] )) biz.Find(_companyID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizCompany();
						if (!IsNull( _columnNames[_companyIDIndex] )) biz.Load(_companyID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._companyID = value._companyID; } // attempt to sync key values
				catch { }
			}
		}

		#endregion
		

		//========================================================
		//Attribute get/set methods
		//========================================================
		#region Attribute get/set methods

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for ContactID</summary>
		public object ContactID
		{
			get { return this[ _columnNames[_contactIDIndex] ]; }
		}
		
		public int _contactID
		{
			get { return GetInt32( _columnNames[_contactIDIndex] ); }
			set { SetInt32( _columnNames[_contactIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for ContactTypeID</summary>
		public object ContactTypeID
		{
			get { return this[ _columnNames[_contactTypeIDIndex] ]; }
		}
		
		public int _contactTypeID
		{
			get { return GetInt32( _columnNames[_contactTypeIDIndex] ); }
			set { SetInt32( _columnNames[_contactTypeIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for ContactStatusID</summary>
		public object ContactStatusID
		{
			get { return this[ _columnNames[_contactStatusIDIndex] ]; }
		}
		
		public int _contactStatusID
		{
			get { return GetInt32( _columnNames[_contactStatusIDIndex] ); }
			set { SetInt32( _columnNames[_contactStatusIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CompanyID</summary>
		public object CompanyID
		{
			get { return this[ _columnNames[_companyIDIndex] ]; }
		}
		
		public int _companyID
		{
			get { return GetInt32( _columnNames[_companyIDIndex] ); }
			set { SetInt32( _columnNames[_companyIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the Guid typed value for SessionID</summary>
		public object SessionID
		{
			get { return this[ _columnNames[_sessionIDIndex] ]; }
		}
		public bool SessionIDIsNull
		{
			get { return IsNull( _columnNames[_sessionIDIndex] ); }
			set { this[ _columnNames[_sessionIDIndex] ] = System.DBNull.Value; }
		}
		public Guid _sessionID
		{
			get { return GetGuid( _columnNames[_sessionIDIndex] ); }
			set { SetGuid( _columnNames[_sessionIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Prefix</summary>
		public object Prefix
		{
			get { return this[ _columnNames[_prefixIndex] ]; }
		}
		public bool PrefixIsNull
		{
			get { return IsNull( _columnNames[_prefixIndex] ); }
			set { this[ _columnNames[_prefixIndex] ] = System.DBNull.Value; }
		}
		public string _prefix
		{
			get { return GetString( _columnNames[_prefixIndex] ); }
			set { SetString( _columnNames[_prefixIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for FirstName</summary>
		public object FirstName
		{
			get { return this[ _columnNames[_firstNameIndex] ]; }
		}
		public bool FirstNameIsNull
		{
			get { return IsNull( _columnNames[_firstNameIndex] ); }
			set { this[ _columnNames[_firstNameIndex] ] = System.DBNull.Value; }
		}
		public string _firstName
		{
			get { return GetString( _columnNames[_firstNameIndex] ); }
			set { SetString( _columnNames[_firstNameIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for LastName</summary>
		public object LastName
		{
			get { return this[ _columnNames[_lastNameIndex] ]; }
		}
		
		public string _lastName
		{
			get { return GetString( _columnNames[_lastNameIndex] ); }
			set { SetString( _columnNames[_lastNameIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for JobTitle</summary>
		public object JobTitle
		{
			get { return this[ _columnNames[_jobTitleIndex] ]; }
		}
		public bool JobTitleIsNull
		{
			get { return IsNull( _columnNames[_jobTitleIndex] ); }
			set { this[ _columnNames[_jobTitleIndex] ] = System.DBNull.Value; }
		}
		public string _jobTitle
		{
			get { return GetString( _columnNames[_jobTitleIndex] ); }
			set { SetString( _columnNames[_jobTitleIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for OfficeNumber</summary>
		public object OfficeNumber
		{
			get { return this[ _columnNames[_officeNumberIndex] ]; }
		}
		public bool OfficeNumberIsNull
		{
			get { return IsNull( _columnNames[_officeNumberIndex] ); }
			set { this[ _columnNames[_officeNumberIndex] ] = System.DBNull.Value; }
		}
		public string _officeNumber
		{
			get { return GetString( _columnNames[_officeNumberIndex] ); }
			set { SetString( _columnNames[_officeNumberIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for MobileNumber</summary>
		public object MobileNumber
		{
			get { return this[ _columnNames[_mobileNumberIndex] ]; }
		}
		public bool MobileNumberIsNull
		{
			get { return IsNull( _columnNames[_mobileNumberIndex] ); }
			set { this[ _columnNames[_mobileNumberIndex] ] = System.DBNull.Value; }
		}
		public string _mobileNumber
		{
			get { return GetString( _columnNames[_mobileNumberIndex] ); }
			set { SetString( _columnNames[_mobileNumberIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for HomeNumber</summary>
		public object HomeNumber
		{
			get { return this[ _columnNames[_homeNumberIndex] ]; }
		}
		public bool HomeNumberIsNull
		{
			get { return IsNull( _columnNames[_homeNumberIndex] ); }
			set { this[ _columnNames[_homeNumberIndex] ] = System.DBNull.Value; }
		}
		public string _homeNumber
		{
			get { return GetString( _columnNames[_homeNumberIndex] ); }
			set { SetString( _columnNames[_homeNumberIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for OtherNumber</summary>
		public object OtherNumber
		{
			get { return this[ _columnNames[_otherNumberIndex] ]; }
		}
		public bool OtherNumberIsNull
		{
			get { return IsNull( _columnNames[_otherNumberIndex] ); }
			set { this[ _columnNames[_otherNumberIndex] ] = System.DBNull.Value; }
		}
		public string _otherNumber
		{
			get { return GetString( _columnNames[_otherNumberIndex] ); }
			set { SetString( _columnNames[_otherNumberIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for FaxNumber</summary>
		public object FaxNumber
		{
			get { return this[ _columnNames[_faxNumberIndex] ]; }
		}
		public bool FaxNumberIsNull
		{
			get { return IsNull( _columnNames[_faxNumberIndex] ); }
			set { this[ _columnNames[_faxNumberIndex] ] = System.DBNull.Value; }
		}
		public string _faxNumber
		{
			get { return GetString( _columnNames[_faxNumberIndex] ); }
			set { SetString( _columnNames[_faxNumberIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for EmailAddress</summary>
		public object EmailAddress
		{
			get { return this[ _columnNames[_emailAddressIndex] ]; }
		}
		public bool EmailAddressIsNull
		{
			get { return IsNull( _columnNames[_emailAddressIndex] ); }
			set { this[ _columnNames[_emailAddressIndex] ] = System.DBNull.Value; }
		}
		public string _emailAddress
		{
			get { return GetString( _columnNames[_emailAddressIndex] ); }
			set { SetString( _columnNames[_emailAddressIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Description</summary>
		public object Description
		{
			get { return this[ _columnNames[_descriptionIndex] ]; }
		}
		public bool DescriptionIsNull
		{
			get { return IsNull( _columnNames[_descriptionIndex] ); }
			set { this[ _columnNames[_descriptionIndex] ] = System.DBNull.Value; }
		}
		public string _description
		{
			get { return GetString( _columnNames[_descriptionIndex] ); }
			set { SetString( _columnNames[_descriptionIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Username</summary>
		public object Username
		{
			get { return this[ _columnNames[_usernameIndex] ]; }
		}
		public bool UsernameIsNull
		{
			get { return IsNull( _columnNames[_usernameIndex] ); }
			set { this[ _columnNames[_usernameIndex] ] = System.DBNull.Value; }
		}
		public string _username
		{
			get { return GetString( _columnNames[_usernameIndex] ); }
			set { SetString( _columnNames[_usernameIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Password</summary>
		public object Password
		{
			get { return this[ _columnNames[_passwordIndex] ]; }
		}
		public bool PasswordIsNull
		{
			get { return IsNull( _columnNames[_passwordIndex] ); }
			set { this[ _columnNames[_passwordIndex] ] = System.DBNull.Value; }
		}
		public string _password
		{
			get { return GetString( _columnNames[_passwordIndex] ); }
			set { SetString( _columnNames[_passwordIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Created</summary>
		public object Created
		{
			get { return this[ _columnNames[_createdIndex] ]; }
		}
		
		public DateTime _created
		{
			get { return GetDateTime( _columnNames[_createdIndex] ); }
			//set { SetDateTime( _columnNames[_createdIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Updated</summary>
		public object Updated
		{
			get { return this[ _columnNames[_updatedIndex] ]; }
		}
		public bool UpdatedIsNull
		{
			get { return IsNull( _columnNames[_updatedIndex] ); }
			//set { this[ _columnNames[_updatedIndex] ] = System.DBNull.Value; }
		}
		public DateTime _updated
		{
			get { return GetDateTime( _columnNames[_updatedIndex] ); }
			//set { SetDateTime( _columnNames[_updatedIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for LastLogin</summary>
		public object LastLogin
		{
			get { return this[ _columnNames[_lastLoginIndex] ]; }
		}
		public bool LastLoginIsNull
		{
			get { return IsNull( _columnNames[_lastLoginIndex] ); }
			set { this[ _columnNames[_lastLoginIndex] ] = System.DBNull.Value; }
		}
		public DateTime _lastLogin
		{
			get { return GetDateTime( _columnNames[_lastLoginIndex] ); }
			set { SetDateTime( _columnNames[_lastLoginIndex], value ); }
		}

		#endregion

	
		//========================================================
		//IBizEntity implementation
		//========================================================
		#region Implementation of IBizEntity
		
		public override bool CreateDal()
		{
			_dal = new DalContact();
			return (_dal != null);
		}
		
		#endregion


		//========================================================
		//IBizState implementation
		//========================================================
		#region Implementation of IBizState
		
		public override bool CreateState()
		{
			// create DataTable and add columns
			_dataTable = new DataTable(_entityName);
				
			// create and add primary key column
			DataColumn[] keys = new DataColumn[1];
			keys[0] = _dataTable.Columns.Add( _columnNames[ 0 ], _columnTypes[ 0 ] );
			keys[0].Unique = true;
			keys[0].AutoIncrement = true;
			keys[0].AutoIncrementSeed = -1;
			keys[0].AutoIncrementStep = -1;
			_dataTable.PrimaryKey = keys;

			// create and add all other columns
			for(int col=1; col<=_columnNames.GetUpperBound(0); col++) _dataTable.Columns.Add( _columnNames[ col ], _columnTypes[ col ] );

			// add DataTable to DataSet
			if (_dataSet == null) _dataSet = new DataSet();
			_dataSet.Tables.Add(_dataTable);

			// add relationships to DataSet
			if (_dataSet.Tables.Contains("ContactType"))
			{
				string relationshipName = GetRelationshipName("ContactType");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["ContactType"].Columns["ContactTypeID"];
					DataColumn fk = _dataSet.Tables["Contact"].Columns["ContactTypeID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("ContactStatus"))
			{
				string relationshipName = GetRelationshipName("ContactStatus");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["ContactStatus"].Columns["ContactStatusID"];
					DataColumn fk = _dataSet.Tables["Contact"].Columns["ContactStatusID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("Company"))
			{
				string relationshipName = GetRelationshipName("Company");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["Company"].Columns["CompanyID"];
					DataColumn fk = _dataSet.Tables["Contact"].Columns["CompanyID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
					
			// return success
			return (_dataTable != null);
		}
		
		#endregion		
	}
}
