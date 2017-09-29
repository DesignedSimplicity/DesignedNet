using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace DesignedNet.Framework.Dal
{
	/// <summary>Base class for OleDb server entity command builders</summary>
	/// ================================================================================
	/// Object:		DesignedNet.Framework.Dal.DalOleDb
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:		KHutchens
	/// Created:	01.16.03
	/// Modified:	03.17.03
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class DalOleDb : IDalDb, IDalData
	{
		//========================================================
		//Variables
		//========================================================
		#region Variables

		protected OleDbDataAdapter _da = new OleDbDataAdapter();
		protected OleDbConnection _database;
		protected string _tableName = "Entity";
		#endregion


		//========================================================
		//Constructors
		//========================================================
		#region Constructors

		//--------------------------------------------------------
		/// <summary>Default constructor</summary>
		public DalOleDb(string tableName) { _tableName = tableName; }

		#endregion

		
		//========================================================
		//Protected methods
		//========================================================
		#region Protected methods

		public OleDbConnection GetConnection()
		{
			// create and open connection if needed
			if (_database == null) _database = new OleDbConnection(ConfigurationSettings.AppSettings["OleDbConnectionString"]);			
			if (_database.State != ConnectionState.Open) _database.Open(); // DO NOT OPEN AUTOMATICALLY, DATA ADAPTER WILL DO IT
			
			// return connection
			return _database;
		}

		#endregion


		//========================================================
		//IDalCmd interface
		//========================================================
		#region IDalCmd interface

		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the select stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public OleDbCommand GetIdentityCmd()
		{
			OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY");
			cmd.CommandType = CommandType.Text;
			cmd.Connection = GetConnection();
			return cmd;
		}
		
		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the select stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public virtual OleDbCommand GetSelectCmd(object pk)
		{
			OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + _tableName + "] WHERE " + _tableName + "ID = " + pk.ToString());
			cmd.CommandType = CommandType.Text;
			cmd.Connection = GetConnection();
			return cmd;
		}		
		
		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the insert stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public virtual OleDbCommand GetInsertCmd()
		{
			_da.SelectCommand = GetSelectCmd(0); //GetListCmd();
			OleDbCommandBuilder builder = new OleDbCommandBuilder(_da);
			builder.QuotePrefix = "[";
			builder.QuoteSuffix = "]";
			return builder.GetInsertCommand();
		}
		
		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the update stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public virtual OleDbCommand GetUpdateCmd()
		{
			_da.SelectCommand = GetSelectCmd(0); //GetListCmd();
			OleDbCommandBuilder builder = new OleDbCommandBuilder(_da);
			builder.QuotePrefix = "[";
			builder.QuoteSuffix = "]";
			return builder.GetUpdateCommand();
		}
		
		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the delete stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public virtual OleDbCommand GetDeleteCmd()
		{
			_da.SelectCommand = GetSelectCmd(0); //GetListCmd();
			OleDbCommandBuilder builder = new OleDbCommandBuilder(_da);
			builder.QuotePrefix = "[";
			builder.QuoteSuffix = "]";
			return builder.GetDeleteCommand();
		}

		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the delete stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public OleDbCommand GetDeleteCmd(object pk)
		{
			OleDbCommand cmd = new OleDbCommand("DELETE [" + _tableName + "] WHERE " + _tableName + "ID = " + pk.ToString());
			cmd.CommandType = CommandType.Text;
			cmd.Connection = GetConnection();
			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the list stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public OleDbCommand GetListCmd()
		{
			OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + _tableName + "]", GetConnection());
			cmd.CommandType = CommandType.Text;
			cmd.Connection = GetConnection();
			
			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a OleDbCommand object for the list stored procedure</summary>
		/// <returns>Initalized OleDbCommand object</returns>
		public OleDbCommand GetListByColumnCmd(string column, object data)
		{
			OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + _tableName + "] WHERE [" + column + "] = " + data, GetConnection());
			cmd.CommandType = CommandType.Text;
			cmd.Connection = GetConnection();
			return cmd;
		}

		#endregion

		
		//========================================================
		//IDalData interface
		//========================================================
		#region IDalData interface

		//--------------------------------------------------------
		/// <summary>Closes any open database connection</summary>
		public void Close()
		{
			_database.Close();
		}

		//--------------------------------------------------------
		public int Report( DataTable dt )
		{
			throw new Exception("DesignedNet.Framwork.Dal.Dal_OleDb.cs not implemented!");
		}

		//--------------------------------------------------------
		/// <summary>Updates, inserts and deletes the all records contained in the DataTable</summary>
		/// <param name="dr">DataTable to process</param>
		/// <returns>Number of rows updated/inserted/deleted</returns>
		public int Update( DataTable dt )
		{
			// create the necessary command objects needed for the DataAdapter.Update command
			_da.UpdateCommand = GetUpdateCmd();
			_da.InsertCommand = GetInsertCmd();
			_da.DeleteCommand = GetDeleteCmd();

			// insert, update and delete all rows in DataTable
			int count = _da.Update( dt );

			// accept the changes to the dataset
			//dt.AcceptChanges();

			// return the number of rows updated
			return count;
		}

		//--------------------------------------------------------
		/// <summary>Updates, inserts and deletes the record contained in the DataRow</summary>
		/// <param name="dr">DataRow to process</param>
		/// <returns>Number of rows updated/inserted/deleted</returns>
		public int Update( DataRow dr )
		{
			// create the necessary command objects needed for the DataAdapter.Update command
			_da.UpdateCommand = GetUpdateCmd();
			_da.InsertCommand = GetInsertCmd();
			_da.DeleteCommand = GetDeleteCmd();

			// insert, update or delete the data for the DataRow
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;
			int count = _da.Update( drs );

			try 
			{
				OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY");
				cmd.Connection = _da.SelectCommand.Connection;
				dr[_tableName + "ID"] = (int)cmd.ExecuteScalar();
				_da.SelectCommand.Connection.Close();
			} 
			catch {}

			// accept the changes to the DataRow
			//dr.AcceptChanges();

			// return count of rows updated
			return count;
		}

		//--------------------------------------------------------
		/// <summary>Inserts a single record into the database from values in the DataRow</summary>
		/// <param name="dr">DataRow to process</param>
		/// <returns>Number of rows inserted</returns>
		public int Insert( DataRow dr )
		{
			// create the necessary command objects needed for the DataAdapter.Update command
			_da.InsertCommand = GetInsertCmd();

			// copy single DataRow into DataRow array
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;

			// insert row in table
			int count = _da.Update( drs );

			OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY");
			cmd.Connection = _da.SelectCommand.Connection;
			dr[_tableName + "ID"] = (int)cmd.ExecuteScalar();
			_da.SelectCommand.Connection.Close();

			// return count of rows updated
			return count;
		}

		//--------------------------------------------------------
		/// <summary>Deletes a single record from the database via the primary key</summary>
		/// <param name="dr">DataRow to process</param>
		/// <returns>Number of rows deleted</returns>
		public int Delete( DataRow dr )
		{
			// create the necessary command objects needed for the DataAdapter.Update command
			_da.DeleteCommand = GetDeleteCmd();

			// copy single DataRow into DataRow array
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;

			// insert row in table
			int count = _da.Update( drs );

			// accept changes and update identity column
			//dr.AcceptChanges();

			// return count of rows updated
			return count;
		}

		//--------------------------------------------------------
		/// <summary>Deletes the entity specified</summary>
		public int Delete( object pk )
		{
			// get data access command
			OleDbCommand cmd = GetDeleteCmd(pk);

			// execute delete command
			return cmd.ExecuteNonQuery();
		}

		//--------------------------------------------------------
		/// <summary>List the entities</summary>
		public int List( DataTable table )
		{
			// get data access command
			_da.SelectCommand = GetListCmd();

			// create and fill typed table
			return _da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>List the entities</summary>
		public int List( out OleDbDataReader sql )
		{
			// create new data adapter
			OleDbCommand cmd = GetListCmd();

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		//--------------------------------------------------------
		/// <summary>List the entity by specified column</summary>
		public int ListByColumn( string column, object data, DataTable table )
		{
			// get data access command
			_da.SelectCommand = GetListByColumnCmd(column, data);

			// create and fill typed table
			return _da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>List the entity by specified column</summary>
		public int ListByColumn( string column, object data, out OleDbDataReader sql )
		{
			// create new data adapter
			OleDbCommand cmd = GetListByColumnCmd(column, data);

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		//--------------------------------------------------------
		/// <summary>Selects the entity specified</summary>
		public int Select( object pk, DataTable table )
		{
			// create new data adapter
			OleDbCommand cmd = GetSelectCmd(pk);

			// get data access command
			_da.SelectCommand = cmd;

			// create and fill typed table
			return _da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>Selects the entity specified</summary>
		public int Select( object pk, out OleDbDataReader sql )
		{
			// create new data adapter
			OleDbCommand cmd = GetSelectCmd(pk);

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		#endregion
	}
}