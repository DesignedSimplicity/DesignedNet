/********************************************************************************/
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//============================
using DesignedNet.Framework.Dal;


namespace DesignedNet.Framework.Biz
{
	/// <summary>Abstract base business object class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Biz.BizEntity
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	11.27.02
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	abstract public class BizEntity : BizState, IBizEntity
	{
		//========================================================
		//Module level variables
		//========================================================


		//========================================================
		//Public constructor
		//========================================================
		public BizEntity(string entityName) : base(entityName) { }
		public BizEntity(string entityName, DataSet state) : base(entityName, state) { }


		//========================================================
		//IBizEntity implementation
		//========================================================
		#region Implementation of IBizEntity

		//--------------------------------------------------------
		/// <summary>Creates a new DataRow the DataTable, creates the DataTable if necessary</summary>
		/// <returns>True if new DataRow was created successfully</returns>
		public bool New()
		{
			// verify (and create) state
			CheckState();

			// create and add new row
			_dataRow = _dataTable.NewRow();
			_dataTable.Rows.Add(_dataRow);

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Locates a DataRow in the DataTable by primary key value</summary>
		/// <param name="id">Value of primary key for record to locate</param>
		/// <returns>True if DataRow with given value was located</returns>
		public bool Find(int id)
		{
			// verify (and create) state
			CheckState();

			// locate row
			_dataRow = _dataTable.Rows.Find(id);

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Loads the specified DataRow from the database</summary>
		/// <param name="id">Value of primary key for record to load</param>
		/// <returns>True if DataRow with given value was loaded</returns>
		public bool Load(int id)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// execute data access request
			_dal.Select(id, _dataTable);
			_dal.Close();

			// extract data row
			try { _dataRow = _dataTable.Rows[0]; }
			catch { _dataRow = null; }

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Saves the specified DataRow to the database</summary>
		/// <returns>True if DataRow with given value was saved</returns>
		public bool Save()
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// execute data access request
			if (_dataRow != null)
			{
				if (_dal.Update(_dataRow) == 0)
				{
					_dal.Close();
					return false;
				}
				else
				{
					_dal.Close();
					return true;
				}
			}
			else
				return false;
		}

		//--------------------------------------------------------
		/// <summary>Saves the specified DataTable to the database</summary>
		/// <returns>True if DataRow with given value was saved</returns>
		public bool SaveAll()
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// execute data access request
			if (_dataTable != null)
			{
				if (_dal.Update(_dataTable) == 0)
				{
					_dal.Close();
					return false;
				}
				else
				{
					_dal.Close();
					return true;
				}
			}
			else
				return false;
		}

		//--------------------------------------------------------
		/// <summary>Loads the default list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool List()
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// execute data access request
			_dal.List(_dataTable); 
			_dal.Close();

			// return result
			return (_dataTable != null);
		}

		//--------------------------------------------------------
		/// <summary>Loads the default report of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool Report()
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// execute data access request
			_dal.Report(_dataTable); 
			_dal.Close();

			// return result
			return (_dataTable != null);
		}

		//--------------------------------------------------------
		/// <summary>Deletes the current entity from the database</summary>
		/// <param name="id">Value of primary key for record to delete</param>
		/// <returns>True if entity was deleted</returns>
		public bool Delete(int id)
		{
			// verify (and create) data access layer
			CheckDal();

			// delete row from database
			if (_dal.Delete(id) == 0)
				return false;
			else
			{
				_dal.Close();
				return true;
			}
		}

		#endregion

	}
}