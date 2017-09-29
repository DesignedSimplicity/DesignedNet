using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DesignedNet.Framework.Dal
{
	
	/// <summary>Base class for Sql server entity command builders</summary>
	/// ================================================================================
	/// Object:		DesignedNet.Framework.Dal.DalSqlDb
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:		KHutchens
	/// Created:	01.16.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class DalSqlDb : IDalSql, IDalData
	{
		//========================================================
		//Variables
		//========================================================
		#region Variables

		protected SqlConnection _database;
		protected string _tableName = "Entity";
		protected string _listCommand = "_List";
		protected string _insertCommand = "_Insert";
		protected string _selectCommand = "_Select";
		protected string _updateCommand = "_Update";
		protected string _deleteCommand = "_Delete";
		protected string _reportCommand = "_Report";
		#endregion


		//========================================================
		//Constructors
		//========================================================
		#region Constructors

		//--------------------------------------------------------
		/// <summary>Default constructor</summary>
		public DalSqlDb(string tableName) { _tableName = tableName; }

		#endregion

		
		//========================================================
		//Protected methods
		//========================================================
		#region Protected methods

		public SqlConnection GetConnection()
		{
			// create and open connection if needed
			if (_database == null) _database = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);			
			if (_database.State != ConnectionState.Open) _database.Open(); // DO NOT OPEN AUTOMATICALLY, DATA ADAPTER WILL DO IT
			
			// return connection
			return _database;
		}

		public void SetParameter(SqlCommand cmd, string name, object val)
		{
			if (val == null)
				cmd.Parameters["@" + name].Value = DBNull.Value;
			else
				cmd.Parameters["@" + name].Value = val;
		}

		#endregion

		
		//========================================================
		//IDalCmd interface
		//========================================================
		#region IDalCmd interface

		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the insert stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public virtual SqlCommand GetInsertCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _insertCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			SqlCommandBuilder.DeriveParameters(cmd);

			return cmd;
		}
		
		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the update stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public virtual SqlCommand GetUpdateCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _updateCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			SqlCommandBuilder.DeriveParameters(cmd);

			return cmd;
		}
		
		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the select stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetSelectCmd(object pk)
		{
			SqlCommand cmd = new SqlCommand(_tableName + _selectCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			SqlParameter p = cmd.Parameters.Add("@" + _tableName + "ID", pk);
			p.SourceColumn = _tableName + "ID";

			return cmd;
		}		
		
		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the delete stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetDeleteCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _deleteCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@" + _tableName + "ID", SqlDbType.Int);
			p.SourceColumn = _tableName + "ID";

			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the delete stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetDeleteCmd(object pk)
		{
			SqlCommand cmd = new SqlCommand(_tableName + _deleteCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@" + _tableName + "ID", pk);
			p.SourceColumn = _tableName + "ID";

			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the report stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public virtual SqlCommand GetReportCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _reportCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			return cmd;
		}

		//--------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByColumnCmd(string column, object data)
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listCommand + "By" + column);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();
			
			SqlParameter p = cmd.Parameters.Add("@" + column, data);
			p.SourceColumn = column;

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
		/// <summary>Updates, inserts and deletes the all records contained in the DataTable</summary>
		/// <param name="dr">DataTable to process</param>
		/// <returns>Number of rows updated/inserted/deleted</returns>
		public int Update( DataTable dt )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();
			
			// create the necessary command objects needed for the DataAdapter.Update command
			da.UpdateCommand = GetUpdateCmd();
			da.InsertCommand = GetInsertCmd();
			da.DeleteCommand = GetDeleteCmd();

			// insert, update and delete all rows in DataTable
			int count = da.Update( dt );

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
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();
			
			// create the necessary command objects needed for the DataAdapter.Update command
			da.UpdateCommand = GetUpdateCmd();
			da.InsertCommand = GetInsertCmd();
			da.DeleteCommand = GetDeleteCmd();

			// insert, update or delete the data for the DataRow
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;
			int count = da.Update( drs );

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
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();
			
			// create the necessary command objects needed for the DataAdapter.Update command
			da.InsertCommand = GetInsertCmd();

			// copy single DataRow into DataRow array
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;

			// insert row in table
			int count = da.Update( drs );

			// accept changes and update identity column
			//dr.AcceptChanges();

			// return count of rows updated
			return count;
		}

		//--------------------------------------------------------
		/// <summary>Deletes a single record from the database via the primary key</summary>
		/// <param name="dr">DataRow to process</param>
		/// <returns>Number of rows deleted</returns>
		public int Delete( DataRow dr )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();
			
			// create the necessary command objects needed for the DataAdapter.Update command
			da.DeleteCommand = GetDeleteCmd();

			// copy single DataRow into DataRow array
			DataRow[] drs = new DataRow[1];
			drs[0] = dr;

			// insert row in table
			int count = da.Update( drs );

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
			SqlCommand cmd = GetDeleteCmd(pk);

			// execute delete command
			return cmd.ExecuteNonQuery();
		}

		//--------------------------------------------------------
		/// <summary>List the entities</summary>
		public int List( DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListCmd();

			// create and fill typed table
			return da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>List the entities</summary>
		public int List( out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListCmd();

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		//--------------------------------------------------------
		/// <summary>List the entity by specified column</summary>
		public int ListByColumn( string column, object data, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByColumnCmd(column, data);

			// create and fill typed table
			return da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>List the entity by specified column</summary>
		public int ListByColumn( string column, object data, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByColumnCmd(column, data);

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
			SqlCommand cmd = GetSelectCmd(pk);
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = cmd;

			// create and fill typed table
			return da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>Selects the entity specified</summary>
		public int Select( object pk, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetSelectCmd(pk);

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		//--------------------------------------------------------
		/// <summary>Reports the entity specified</summary>
		public int Report( DataTable table )
		{
			// create new data adapter
			SqlCommand cmd = GetReportCmd();
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = cmd;

			// create and fill typed table
			return da.Fill(table);
		}

		//--------------------------------------------------------
		/// <summary>Reports the entity specified</summary>
		public int Report( out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetReportCmd();

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

		#endregion
	}
}