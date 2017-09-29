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
	/// <summary>Data access layer for Company table in a sql server 2000 database</summary>
	/// ================================================================================
	/// Object:	    Harkins.Dal.DataCompany
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class DalCompany : DalSqlDb
	{
		//========================================================
		//Stored procedure constants
		//========================================================
		#region Stored procedure constants

		private const string _listByCompanyTypeCommand = "_ListByCompanyTypeID";
		private const string _listByCompanyStatusCommand = "_ListByCompanyStatusID";
		#endregion
		
		
		//========================================================
		//Object constructors
		//========================================================
		public DalCompany() : base("Company") {}
		
		
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
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			p.Direction = ParameterDirection.Output;
			
			p = cmd.Parameters.Add("@CompanyTypeID", SqlDbType.Int);
			p.SourceColumn = "CompanyTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyStatusID", SqlDbType.Int);
			p.SourceColumn = "CompanyStatusID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 100);
			p.SourceColumn = "CompanyName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LocationName", SqlDbType.VarChar, 100);
			p.SourceColumn = "LocationName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar, 100);
			p.SourceColumn = "StreetAddress";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Region", SqlDbType.VarChar, 50);
			p.SourceColumn = "Region";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@City", SqlDbType.VarChar, 50);
			p.SourceColumn = "City";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@State", SqlDbType.VarChar, 10);
			p.SourceColumn = "State";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 10);
			p.SourceColumn = "Zip";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
			p.SourceColumn = "Phone";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 50);
			p.SourceColumn = "Fax";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Website", SqlDbType.VarChar, 50);
			p.SourceColumn = "Website";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 5000);
			p.SourceColumn = "Description";
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
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyTypeID", SqlDbType.Int);
			p.SourceColumn = "CompanyTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyStatusID", SqlDbType.Int);
			p.SourceColumn = "CompanyStatusID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 100);
			p.SourceColumn = "CompanyName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@LocationName", SqlDbType.VarChar, 100);
			p.SourceColumn = "LocationName";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar, 100);
			p.SourceColumn = "StreetAddress";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Region", SqlDbType.VarChar, 50);
			p.SourceColumn = "Region";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@City", SqlDbType.VarChar, 50);
			p.SourceColumn = "City";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@State", SqlDbType.VarChar, 10);
			p.SourceColumn = "State";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 10);
			p.SourceColumn = "Zip";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
			p.SourceColumn = "Phone";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 50);
			p.SourceColumn = "Fax";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Website", SqlDbType.VarChar, 50);
			p.SourceColumn = "Website";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 5000);
			p.SourceColumn = "Description";
			p.SourceVersion = DataRowVersion.Current;
			
			return cmd;
		}

		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by CompanyType stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByCompanyTypeCmd( int companyTypeID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByCompanyTypeCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@CompanyTypeID", SqlDbType.Int);
			p.SourceColumn = "CompanyTypeID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = companyTypeID;

			return cmd;
		}


		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by CompanyStatus stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByCompanyStatusCmd( int companyStatusID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByCompanyStatusCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@CompanyStatusID", SqlDbType.Int);
			p.SourceColumn = "CompanyStatusID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = companyStatusID;

			return cmd;
		}

		
		#endregion
		

		//========================================================
		//IDalData implementation
		//========================================================
		#region IDalData implementation

		/// --------------------------------------------------------
		/// <summary>Lists the entity by CompanyType</summary>
		public int ListByCompanyType( int companyTypeID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByCompanyTypeCmd( companyTypeID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by CompanyType</summary>
		public int ListByCompanyType( int companyTypeID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByCompanyTypeCmd( companyTypeID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		/// --------------------------------------------------------
		/// <summary>Lists the entity by CompanyStatus</summary>
		public int ListByCompanyStatus( int companyStatusID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByCompanyStatusCmd( companyStatusID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by CompanyStatus</summary>
		public int ListByCompanyStatus( int companyStatusID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByCompanyStatusCmd( companyStatusID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		#endregion

	}
}
