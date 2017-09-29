/********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Xml.XPath;

//============================
using DesignedNet.Framework.Dal;


//----------------------------
namespace Harkins.Dal
{
	/// <summary>Data access layer for Contact table in a sql server 2000 database</summary>
	/// ================================================================================
	/// Object:	    Harkins.Dal.DataContact
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class DalContact : DalSqlDb
	{
		//========================================================
		//Stored procedure constants
		//========================================================
		#region Stored procedure constants

		private const string _listByContactTypeCommand = "_ListByContactTypeID";
		private const string _listByContactStatusCommand = "_ListByContactStatusID";
		private const string _listByCompanyCommand = "_ListByCompanyID";
		#endregion
		
		
		//========================================================
		//Object constructors
		//========================================================
		public DalContact() : base("Contact") {}
		
		
		//========================================================
		//IDalCmd implementation
		//========================================================
		#region IDalCmd implementation
		
		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the insert stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public override SqlCommand GetInsertCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _insertCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p;
			
			p = cmd.Parameters.Add("@ContactID", SqlDbType.Int);
			p.SourceColumn = "ContactID";
			p.SourceVersion = DataRowVersion.Current;
			p.Direction = ParameterDirection.Output;
			
			p = cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int);
			p.SourceColumn = "ContactTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ContactStatusID", SqlDbType.Int);
			p.SourceColumn = "ContactStatusID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier);
			p.SourceColumn = "SessionID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Prefix", SqlDbType.VarChar, 10);
			p.SourceColumn = "Prefix";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
			p.SourceColumn = "FirstName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
			p.SourceColumn = "LastName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@JobTitle", SqlDbType.VarChar, 50);
			p.SourceColumn = "JobTitle";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@OfficeNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "OfficeNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "MobileNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "HomeNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@OtherNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "OtherNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@FaxNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "FaxNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 100);
			p.SourceColumn = "EmailAddress";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
			p.SourceColumn = "Description";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50);
			p.SourceColumn = "Username";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
			p.SourceColumn = "Password";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime);
			p.SourceColumn = "LastLogin";
			p.SourceVersion = DataRowVersion.Current;
			
			return cmd;
		}

		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the update stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public override SqlCommand GetUpdateCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _updateCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p;
			
			p = cmd.Parameters.Add("@ContactID", SqlDbType.Int);
			p.SourceColumn = "ContactID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int);
			p.SourceColumn = "ContactTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ContactStatusID", SqlDbType.Int);
			p.SourceColumn = "ContactStatusID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier);
			p.SourceColumn = "SessionID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Prefix", SqlDbType.VarChar, 10);
			p.SourceColumn = "Prefix";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
			p.SourceColumn = "FirstName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
			p.SourceColumn = "LastName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@JobTitle", SqlDbType.VarChar, 50);
			p.SourceColumn = "JobTitle";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@OfficeNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "OfficeNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "MobileNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@HomeNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "HomeNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@OtherNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "OtherNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@FaxNumber", SqlDbType.VarChar, 50);
			p.SourceColumn = "FaxNumber";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 100);
			p.SourceColumn = "EmailAddress";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
			p.SourceColumn = "Description";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50);
			p.SourceColumn = "Username";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
			p.SourceColumn = "Password";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime);
			p.SourceColumn = "LastLogin";
			p.SourceVersion = DataRowVersion.Current;
			
			return cmd;
		}

		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by ContactType stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByContactTypeCmd( int contactTypeID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByContactTypeCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@ContactTypeID", SqlDbType.Int);
			p.SourceColumn = "ContactTypeID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = contactTypeID;

			return cmd;
		}


		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by ContactStatus stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByContactStatusCmd( int contactStatusID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByContactStatusCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@ContactStatusID", SqlDbType.Int);
			p.SourceColumn = "ContactStatusID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = contactStatusID;

			return cmd;
		}


		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by Company stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByCompanyCmd( int companyID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByCompanyCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = companyID;

			return cmd;
		}

		
		#endregion
		

		//========================================================
		//IDalData implementation
		//========================================================
		#region IDalData implementation

		/// --------------------------------------------------------
		/// <summary>Lists the entity by ContactType</summary>
		public int ListByContactType( int contactTypeID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByContactTypeCmd( contactTypeID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by ContactType</summary>
		public int ListByContactType( int contactTypeID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByContactTypeCmd( contactTypeID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		/// --------------------------------------------------------
		/// <summary>Lists the entity by ContactStatus</summary>
		public int ListByContactStatus( int contactStatusID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByContactStatusCmd( contactStatusID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by ContactStatus</summary>
		public int ListByContactStatus( int contactStatusID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByContactStatusCmd( contactStatusID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		/// --------------------------------------------------------
		/// <summary>Lists the entity by Company</summary>
		public int ListByCompany( int companyID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByCompanyCmd( companyID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by Company</summary>
		public int ListByCompany( int companyID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByCompanyCmd( companyID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		#endregion

	}
}
