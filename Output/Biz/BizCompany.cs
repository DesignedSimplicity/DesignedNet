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
	/// <summary>Business logic class for sql server database table: Company</summary>
	/// ================================================================================
	/// Object:	    Harkins.Biz.BizCompany
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class BizCompany : BizEntity
	{
		//========================================================
		//Field index constants
		//========================================================
		#region Field index constants

		private static Type[] _columnTypes = new Type[16] {typeof(int), typeof(int), typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime)};
		private static string[] _columnNames = new string[16] {"CompanyID", "CompanyTypeID", "CompanyStatusID", "CompanyName", "LocationName", "StreetAddress", "Region", "City", "State", "Zip", "Phone", "Fax", "Website", "Description", "Created", "Updated"};

		// data column(s) name and index
		private const int _companyIDIndex = 0;
		private const int _companyTypeIDIndex = 1;
		private const int _companyStatusIDIndex = 2;
		private const int _companyNameIndex = 3;
		private const int _locationNameIndex = 4;
		private const int _streetAddressIndex = 5;
		private const int _regionIndex = 6;
		private const int _cityIndex = 7;
		private const int _stateIndex = 8;
		private const int _zipIndex = 9;
		private const int _phoneIndex = 10;
		private const int _faxIndex = 11;
		private const int _websiteIndex = 12;
		private const int _descriptionIndex = 13;
		private const int _createdIndex = 14;
		private const int _updatedIndex = 15;

		#endregion
		

		//========================================================
		//Object constructors
		//========================================================
		public BizCompany() : base("Company") {}
		public BizCompany(DataSet state) : base("Company", state) {}


		//========================================================
		//Action verbs
		//========================================================
		#region Action verbs

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByCompanyType(int companyTypeID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalCompany dal = (DalCompany)_dal;
			dal.ListByCompanyType(companyTypeID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByCompanyStatus(int companyStatusID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalCompany dal = (DalCompany)_dal;
			dal.ListByCompanyStatus(companyStatusID, _dataTable);
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
		public BizCompanyType CompanyType
		{
			get
			{
				BizCompanyType biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizCompanyType(_dataSet);
						if (!IsNull( _columnNames[_companyTypeIDIndex] )) biz.Find(_companyTypeID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizCompanyType();
						if (!IsNull( _columnNames[_companyTypeIDIndex] )) biz.Load(_companyTypeID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._companyTypeID = value._companyTypeID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizCompanyStatus CompanyStatus
		{
			get
			{
				BizCompanyStatus biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizCompanyStatus(_dataSet);
						if (!IsNull( _columnNames[_companyStatusIDIndex] )) biz.Find(_companyStatusID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizCompanyStatus();
						if (!IsNull( _columnNames[_companyStatusIDIndex] )) biz.Load(_companyStatusID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._companyStatusID = value._companyStatusID; } // attempt to sync key values
				catch { }
			}
		}

		#endregion
		

		//========================================================
		//Attribute get/set methods
		//========================================================
		#region Attribute get/set methods

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
		/// <summary>Gets or sets the int typed value for CompanyTypeID</summary>
		public object CompanyTypeID
		{
			get { return this[ _columnNames[_companyTypeIDIndex] ]; }
		}
		
		public int _companyTypeID
		{
			get { return GetInt32( _columnNames[_companyTypeIDIndex] ); }
			set { SetInt32( _columnNames[_companyTypeIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CompanyStatusID</summary>
		public object CompanyStatusID
		{
			get { return this[ _columnNames[_companyStatusIDIndex] ]; }
		}
		
		public int _companyStatusID
		{
			get { return GetInt32( _columnNames[_companyStatusIDIndex] ); }
			set { SetInt32( _columnNames[_companyStatusIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for CompanyName</summary>
		public object CompanyName
		{
			get { return this[ _columnNames[_companyNameIndex] ]; }
		}
		
		public string _companyName
		{
			get { return GetString( _columnNames[_companyNameIndex] ); }
			set { SetString( _columnNames[_companyNameIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for LocationName</summary>
		public object LocationName
		{
			get { return this[ _columnNames[_locationNameIndex] ]; }
		}
		public bool LocationNameIsNull
		{
			get { return IsNull( _columnNames[_locationNameIndex] ); }
			set { this[ _columnNames[_locationNameIndex] ] = System.DBNull.Value; }
		}
		public string _locationName
		{
			get { return GetString( _columnNames[_locationNameIndex] ); }
			set { SetString( _columnNames[_locationNameIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for StreetAddress</summary>
		public object StreetAddress
		{
			get { return this[ _columnNames[_streetAddressIndex] ]; }
		}
		public bool StreetAddressIsNull
		{
			get { return IsNull( _columnNames[_streetAddressIndex] ); }
			set { this[ _columnNames[_streetAddressIndex] ] = System.DBNull.Value; }
		}
		public string _streetAddress
		{
			get { return GetString( _columnNames[_streetAddressIndex] ); }
			set { SetString( _columnNames[_streetAddressIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Region</summary>
		public object Region
		{
			get { return this[ _columnNames[_regionIndex] ]; }
		}
		public bool RegionIsNull
		{
			get { return IsNull( _columnNames[_regionIndex] ); }
			set { this[ _columnNames[_regionIndex] ] = System.DBNull.Value; }
		}
		public string _region
		{
			get { return GetString( _columnNames[_regionIndex] ); }
			set { SetString( _columnNames[_regionIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for City</summary>
		public object City
		{
			get { return this[ _columnNames[_cityIndex] ]; }
		}
		public bool CityIsNull
		{
			get { return IsNull( _columnNames[_cityIndex] ); }
			set { this[ _columnNames[_cityIndex] ] = System.DBNull.Value; }
		}
		public string _city
		{
			get { return GetString( _columnNames[_cityIndex] ); }
			set { SetString( _columnNames[_cityIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for State</summary>
		public object State
		{
			get { return this[ _columnNames[_stateIndex] ]; }
		}
		public bool StateIsNull
		{
			get { return IsNull( _columnNames[_stateIndex] ); }
			set { this[ _columnNames[_stateIndex] ] = System.DBNull.Value; }
		}
		public string _state
		{
			get { return GetString( _columnNames[_stateIndex] ); }
			set { SetString( _columnNames[_stateIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Zip</summary>
		public object Zip
		{
			get { return this[ _columnNames[_zipIndex] ]; }
		}
		public bool ZipIsNull
		{
			get { return IsNull( _columnNames[_zipIndex] ); }
			set { this[ _columnNames[_zipIndex] ] = System.DBNull.Value; }
		}
		public string _zip
		{
			get { return GetString( _columnNames[_zipIndex] ); }
			set { SetString( _columnNames[_zipIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Phone</summary>
		public object Phone
		{
			get { return this[ _columnNames[_phoneIndex] ]; }
		}
		public bool PhoneIsNull
		{
			get { return IsNull( _columnNames[_phoneIndex] ); }
			set { this[ _columnNames[_phoneIndex] ] = System.DBNull.Value; }
		}
		public string _phone
		{
			get { return GetString( _columnNames[_phoneIndex] ); }
			set { SetString( _columnNames[_phoneIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Fax</summary>
		public object Fax
		{
			get { return this[ _columnNames[_faxIndex] ]; }
		}
		public bool FaxIsNull
		{
			get { return IsNull( _columnNames[_faxIndex] ); }
			set { this[ _columnNames[_faxIndex] ] = System.DBNull.Value; }
		}
		public string _fax
		{
			get { return GetString( _columnNames[_faxIndex] ); }
			set { SetString( _columnNames[_faxIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Website</summary>
		public object Website
		{
			get { return this[ _columnNames[_websiteIndex] ]; }
		}
		public bool WebsiteIsNull
		{
			get { return IsNull( _columnNames[_websiteIndex] ); }
			set { this[ _columnNames[_websiteIndex] ] = System.DBNull.Value; }
		}
		public string _website
		{
			get { return GetString( _columnNames[_websiteIndex] ); }
			set { SetString( _columnNames[_websiteIndex], value ); }
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

		#endregion

	
		//========================================================
		//IBizEntity implementation
		//========================================================
		#region Implementation of IBizEntity
		
		public override bool CreateDal()
		{
			_dal = new DalCompany();
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
			if (_dataSet.Tables.Contains("CompanyType"))
			{
				string relationshipName = GetRelationshipName("CompanyType");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["CompanyType"].Columns["CompanyTypeID"];
					DataColumn fk = _dataSet.Tables["Company"].Columns["CompanyTypeID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("CompanyStatus"))
			{
				string relationshipName = GetRelationshipName("CompanyStatus");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["CompanyStatus"].Columns["CompanyStatusID"];
					DataColumn fk = _dataSet.Tables["Company"].Columns["CompanyStatusID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
					
			// return success
			return (_dataTable != null);
		}
		
		#endregion		
	}
}
