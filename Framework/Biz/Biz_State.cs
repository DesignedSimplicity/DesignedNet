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
	/// <summary>Abstract base state object class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Biz.BizState
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	abstract public class BizState : IBizState
	{
		//========================================================
		//Module level enumerations
		//========================================================
		// AutoLoad:	Creates new state for each child entity spawned (different DataSet)
		// Inspect:		Inspects entity state holding object for related data (all in one DataSet)
		public enum Mode { AutoLoad, Inspect }		


		//========================================================
		//Module level variables
		//========================================================
		protected Mode _mode = Mode.AutoLoad;
		protected IDalData _dal = null;
		protected int _position = -1;
		protected string _entityName = "";
		protected DataSet _dataSet = null;
		protected DataRow _dataRow = null;
		protected DataView _dataView = null;
		protected DataTable _dataTable = null;


		//========================================================
		//Public constructor
		//========================================================
		public BizState(string entityName) { _entityName = entityName; _dataSet = new DataSet(); }
		public BizState(string entityName, DataSet state) { _entityName = entityName; _dataSet = state; _mode = Mode.Inspect; }

	
		//========================================================
		//IBizState implementation
		//========================================================
		#region Implementation of IBizState

		//--------------------------------------------------------
		/// <summary>Changes the state mode for the current entity</summary>
		/// <returns>The current state mode enumeration value</returns>
		public Mode StateMode
		{
			get { return _mode; }
			set { _mode = value; }
		}

		//--------------------------------------------------------
		/// <summary>Checks for entity level state holding object (DataTable/View) for row count</summary>
		/// <returns>The count of rows in the state collection</returns>
		public int Count
		{
			get 
			{
				if (_dataView == null)
					if (_dataTable == null)
						if (_dataRow == null)
							return -1;
						else
							return 1;
					else						
						return _dataTable.Rows.Count;
				else
					return _dataView.Count;
			}
		}

		//-------------------------------------------------------
		/// <summary>Returns the DataRow used for entity state</summary>
		public DataRow Row
		{
			get { return _dataRow; }
			set
			{
				try
				{
					Reset(); // reset object

					_dataRow = value;
					_dataTable = _dataRow.Table;
					_dataSet = _dataTable.DataSet;
				}
				catch {}
			}
		}

		//-------------------------------------------------------
		/// <summary>Returns the DataTable used for entity state</summary>
		public DataTable Table
		{ 
			get { return _dataTable; }
			set
			{
				try
				{
					Reset(); // reset object

					_dataTable = value;
					_dataSet = _dataTable.DataSet;
					_dataRow = _dataTable.Rows[0];
				}
				catch {}
			}
		}

		//-------------------------------------------------------
		/// <summary>Returns the DataView used for entity state</summary>
		public DataView DefaultView
		{ 
			get { return _dataView; }
			set
			{
				try
				{
					Reset(); // reset object

					_dataView = value;
					_dataTable = _dataView.Table;
					_dataSet = _dataTable.DataSet;
				}
				catch {}
			}
		}

		//--------------------------------------------------------
		/// <summary>Checks for data access layer object, creates if necessary</summary>
		/// <returns>True if data access layer was initalized</returns>
		public bool CheckDal()
		{
			// check current data access layer
			if (_dal == null) CreateDal();

			// return true if reference to data access layer
			return (_dal != null);
		}

		//--------------------------------------------------------
		/// <summary>Creates data access layer for this entity</summary>
		public virtual bool CreateDal()
		{
			throw new Exception("DesignedNet.Framework.BizState.CreateDal() -> Dependent object must override this method!  Assign this._dal to object with IDalData implementation.");
		}

		//--------------------------------------------------------
		/// <summary>Inspects DataSet for required DataTable, creates new DataTable if necessary</summary>
		/// <returns>True if state was initalized</returns>
		public bool CheckState()
		{
			// check current DataSet
			if (_dataSet == null) _dataSet = new DataSet();			

			// check current DataTable
			if (_dataTable == null)
			{
				_dataTable = _dataSet.Tables[_entityName];
				if (_dataTable == null) CreateState(); // create DataTable and relationships
			}

			// return true if reference to DataTable
			return (_dataTable != null);
		}

		//--------------------------------------------------------
		/// <summary>Inspects DataSet for required DataTable, creates new DataTable if necessary</summary>
		/// <returns>True if state was initalized</returns>
		public bool CheckState(DataSet state)
		{
			// set current DataSet
			_dataSet = state;

			// check current DataTable
			_dataTable = _dataSet.Tables[_entityName];
			if (_dataTable == null) CreateState(); // create DataTable and relationships

			// return true if reference to DataTable
			return (_dataTable != null);
		}

		//--------------------------------------------------------
		/// <summary>Creates empty state for the entity</summary>
		public virtual bool CreateState()
		{
			// create DataTable and add columns
			_dataTable = new DataTable(_entityName);
			_dal.Select(-1, _dataTable);
				
			// return success
			return (_dataTable != null);
		}

		//--------------------------------------------------------
		/// <summary>Checks for entity level state holding object (DataRow)</summary>
		/// <returns>True if current entity has state</returns>
		public bool HasState()
		{
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Returns current DataSet</summary>
		/// <returns>DataSet of current entity state</returns>
		public DataSet GetState()
		{
			return _dataSet;
		}

		//--------------------------------------------------------
		/// <summary>Locates a set of DataRow in the DataTable by creating a DataView</summary>
		/// <param name="fk">Column index name for filter column</param>
		/// <param name="id">Value of foriegn key for records</param>
		/// <returns>True if DataRow(s) with given value was located</returns>
		public bool Filter(string fk, int id)
		{
			// verify (and create) state
			CheckState();

			// build new DataView if needed
			if (_dataView == null) _dataView = new DataView(_dataTable);
			_dataView.RowFilter = fk + " = " + id.ToString();
			_position = -1;
			
			// get first DataRow from view
			try { _dataRow = _dataView[0].Row; }
			catch { _dataRow = null; }

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Locates a set of DataRow in the DataTable by creating a DataView</summary>
		/// <param name="col">Column index name for filter column</param>
		/// <param name="val">Value of colum for records</param>
		/// <returns>True if DataRow(s) with given value was located</returns>
		public bool Filter(string col, string val)
		{
			// verify (and create) state
			CheckState();

			// build new DataView if needed
			if (_dataView == null) _dataView = new DataView(_dataTable);
			_dataView.RowFilter = col + " = '" + val.ToString().Replace("'", "''") + "'";
			_position = -1;
			
			// get first DataRow from view
			try { _dataRow = _dataView[0].Row; }
			catch { _dataRow = null; }

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Locates a set of DataRow in the DataTable by creating a DataView</summary>
		/// <param name="filter">Explicit filter to use</param>
		/// <returns>True if DataRow(s) with given value was located</returns>
		public bool Filter(string filter)
		{
			// verify (and create) state
			CheckState();

			// build new DataView if needed
			if (_dataView == null) _dataView = new DataView(_dataTable);
			_dataView.RowFilter = filter;
			_position = -1;
			
			// get first DataRow from view
			try { _dataRow = _dataView[0].Row; }
			catch { _dataRow = null; }

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Sorts the items in a DataTable or DataView</summary>
		/// <param name="orderBy">Full SQL order by clause to use for sorting</param>
		/// <returns>True if sort was completed</returns>
		public bool Sort(string orderBy)
		{
			// verify (and create) state
			CheckState();

			// build new DataView if needed
			if (_dataView == null) _dataView = new DataView(_dataTable);
			_dataView.Sort = orderBy;

			// get first DataRow from view
			try { _dataRow = _dataView[0].Row; }
			catch { _dataRow = null; }

			// return result
			return (_dataRow != null);
		}

		//--------------------------------------------------------
		/// <summary>Removes the current entity from state</summary>
		/// <returns>True if DataRow was removed</returns>
		public bool Remove()
		{
			// verify (and create) data access layer
			CheckDal();

			// mark row for deletion
			if (_dataRow != null)
			{
				_dataTable.Rows.Remove(_dataRow);
				_position--; // move to previous
				return true;
			}
			else // no row deleted
				return false;
		}

		//--------------------------------------------------------
		/// <summary>Deletes the current entity from state</summary>
		/// <returns>True if DataRow was deleted</returns>
		public bool Delete()
		{
			// verify (and create) data access layer
			CheckDal();

			// mark row for deletion
			if (_dataRow != null)
			{
				_dataRow.Delete();
				_position--; // move to previous
				return true;
			}
			else // no row deleted
				return false;
		}

		//--------------------------------------------------------
		/// <summary>Returns true or false</summary>
		public bool IsNull(string fieldIndex)
		{
			try { return (_dataRow[fieldIndex].ToString() == ""); }
			catch { return true; }
		}

		//--------------------------------------------------------
		/// <summary>Checks for entity level state holding object (DataRow) has related child data</summary>
		/// <returns>True if current entity has child state</returns>
		public bool HasChildren(string relatedTable)
		{
			if (_dataSet.Tables.Contains(relatedTable)) // DataTable is there
				return (_dataSet.Relations.Contains(GetRelationshipName(relatedTable))); // DataRelation is there
			else
				return false; // table not present
		}

		//--------------------------------------------------------
		/// <summary>Checks the order of names for data relationship</summary>
		/// <returns>Correct relationship name</returns>
		public string GetRelationshipName(string relatedTable)
		{
			if (_entityName.CompareTo(relatedTable) < 0) // always in alphabetical order
				return _entityName + relatedTable;
			else
				return relatedTable + _entityName;
		}

		//--------------------------------------------------------
		/// <summary>Gets or sets the indexed entity value in state</summary>
		public object this[string fieldIndex]
		{
			get
			{
				try // to read from the data reader
				{
					return _dataRow[fieldIndex];
				}
				catch // any error makes reader unreadable
				{
					throw new Exception("DesignedNet.Framework.BizState->Index[" + fieldIndex + "] for entity '" + _entityName + "' is not initalized!");
				}
			}
			set
			{
				try // to read from the data reader
				{
					_dataRow[fieldIndex] = value;
				}
				catch // any error makes writer unwritable
				{
					throw new Exception("DesignedNet.Framework.BizState->Index[" + fieldIndex + "] for entity '" + _entityName + "' is not initalized!");
				}
			}
		}


		#endregion

		
		//========================================================
		//IEnumerable implementation
		//========================================================
		#region Implementation of IEnumerable
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}
		#endregion

		
		//========================================================
		//IEnumerator implementation
		//========================================================
		#region Implementation of IEnumerator

		//--------------------------------------------------------
		/// <summary>Resets the enumerator</summary>
		public void Reset()
		{
			_position = -1;
		}

		//--------------------------------------------------------
		/// <summary>Advances the current pointer to the next record (or first if uninitalized)</summary>
		public bool MoveNext()
		{
			try 
			{
				if (_dataView == null) // iterate though DataTable
				{
					if (_position < _dataTable.Rows.Count - 1)
					{
						_dataRow = _dataTable.Rows[++_position];
						return true;
					}
					else
						return false;
				} 
				else // iterate though DataView
				{
					if (_position < _dataView.Count - 1)
					{
						_dataRow = _dataView[++_position].Row;
						return true;
					}
					else
						return false;
				}
			}
			catch { return false; }
		}

		//--------------------------------------------------------
		/// <summary>Returns the current enumerated item</summary>
		public object Current
		{
			get { return this; }
		}

		#endregion


		//========================================================
		//Typed attribute assignment methods
		//========================================================
		#region Typed attribute assignment methods

		//--------------------------------------------------------
		//Sets an untyped object field value to the current data source column referenced by the fieldIndex
		protected void SetField(string fieldIndex, object fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a string field value from the current data source column referenced by the fieldIndex
		protected string GetString(string fieldIndex)
		{
			try { return this[ fieldIndex ].ToString(); }
			catch (System.ArgumentNullException) { return ""; }
		}

		//--------------------------------------------------------
		//Sets a string field value to the current data source column referenced by the fieldIndex
		protected void SetString(string fieldIndex, string fieldValue)
		{
			//convert to null if string lenth = 0
			if (fieldValue.Length == 0)
				this[ fieldIndex ] = null;
			else
				this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a 8-bit byte field value from the current data source column referenced by the fieldIndex
		protected byte GetByte(string fieldIndex)
		{
			try { return Convert.ToByte(this[ fieldIndex ]); }
			catch (System.ArgumentNullException) { return 0; } // catch DBNull values and convert to zero
		}

		//--------------------------------------------------------
		//Sets a 8-bit byte field value to the current data source column referenced by the fieldIndex
		protected void SetByte(string fieldIndex, byte fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a 16-bit integer field value from the current data source column referenced by the fieldIndex
		protected short GetInt16(string fieldIndex)
		{
			try { return Convert.ToInt16(this[ fieldIndex ]); }
			catch (System.ArgumentNullException) { return 0; } // catch DBNull values and convert to zero
		}

		//--------------------------------------------------------
		//Sets a 16-bit integer field value to the current data source column referenced by the fieldIndex
		protected void SetInt16(string fieldIndex, Int16 fieldValue) { this[ fieldIndex ] = fieldValue; }

		//--------------------------------------------------------
		//Gets a 32-bit integer field value from the current data source column referenced by the fieldIndex
		protected int GetInt32(string fieldIndex)
		{
			try { return Convert.ToInt32(this[ fieldIndex ]); }
			catch (System.InvalidCastException) { return 0; } // catch DBNull values and convert to zero
		}

		//--------------------------------------------------------
		//Sets a 32-bit integer field value to the current data source column referenced by the fieldIndex
		protected void SetInt32(string fieldIndex, int fieldValue) { this[ fieldIndex ] = fieldValue; }

		//--------------------------------------------------------
		//Gets a 64-bit integer field value from the current data source column referenced by the fieldIndex
		protected Int64 GetInt64(string fieldIndex)
		{
			try { return Convert.ToInt64(this[ fieldIndex ]); }
			catch (System.InvalidCastException) { return 0; } // catch DBNull values and convert to zero
		}

		//--------------------------------------------------------
		//Sets a 64-bit integer field value to the current data source column referenced by the fieldIndex
		protected void SetInt64(string fieldIndex, Int64 fieldValue) { this[ fieldIndex ] = fieldValue; }

		//--------------------------------------------------------
		//Gets a guid field value from the current data source column referenced by the fieldIndex
		protected Guid GetGuid(string fieldIndex)
		{
			//return Convert(GetField(fieldIndex));
			throw new Exception("StateItem->GetGuid: NOT IMPLEMENTED YET");
		}

		//--------------------------------------------------------
		//Sets a guid field value to the current data source column referenced by the fieldIndex
		protected void SetGuid(string fieldIndex, Guid fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a boolean field value from the current data source column referenced by the fieldIndex
		protected bool GetBoolean(string fieldIndex)
		{
			try { return Convert.ToBoolean(this[ fieldIndex ]); }
			catch { return false; }
		}

		//--------------------------------------------------------
		//Sets a boolean field value to the current data source column referenced by the fieldIndex
		protected void SetBoolean(string fieldIndex, bool fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a timestamp field value from the current data source column referenced by the fieldIndex
		protected DateTime GetDateTime(string fieldIndex)
		{
			return Convert.ToDateTime(this[ fieldIndex ]);
		}

		//--------------------------------------------------------
		//Sets a timestamp field value to the current data source column referenced by the fieldIndex
		protected void SetDateTime(string fieldIndex, DateTime fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a decimal field value from the current data source column referenced by the fieldIndex
		protected decimal GetDecimal(string fieldIndex)
		{
			return Convert.ToDecimal(this[ fieldIndex ]);
		}

		//--------------------------------------------------------
		//Sets a single field value to the current data source column referenced by the fieldIndex
		protected void SetDecimal(string fieldIndex, decimal fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a single field value from the current data source column referenced by the fieldIndex
		protected float GetSingle(string fieldIndex)
		{
			return Convert.ToSingle(this[ fieldIndex ]);
		}

		//--------------------------------------------------------
		//Sets a single field value to the current data source column referenced by the fieldIndex
		protected void SetSingle(string fieldIndex, float fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a double field value from the current data source column referenced by the fieldIndex
		protected double GetDouble(string fieldIndex)
		{
			return Convert.ToDouble(this[ fieldIndex ]);
		}

		//--------------------------------------------------------
		//Sets a double field value to the current data source column referenced by the fieldIndex
		protected void SetDouble(string fieldIndex, double fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}

		//--------------------------------------------------------
		//Gets a byte array field value from the current data source column referenced by the fieldIndex
		protected byte[] GetByteStream(string fieldIndex)
		{
			throw new Exception("StateItem->GetByteStream: NOT IMPLEMENTED YET");
		}

		//--------------------------------------------------------
		//Sets a byte array field value to the current data source column referenced by the fieldIndex
		protected void SetByteStream(string fieldIndex, byte[] fieldValue)
		{
			this[ fieldIndex ] = fieldValue;
		}
		#endregion

	}
}