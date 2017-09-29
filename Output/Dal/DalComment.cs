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
	/// <summary>Data access layer for Comment table in a sql server 2000 database</summary>
	/// ================================================================================
	/// Object:	    Harkins.Dal.DataComment
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/13/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class DalComment : DalSqlDb
	{
		//========================================================
		//Stored procedure constants
		//========================================================
		#region Stored procedure constants

		private const string _listByCommentTypeCommand = "_ListByCommentTypeID";
		private const string _listByProjectCommand = "_ListByProjectID";
		private const string _listByCompanyCommand = "_ListByCompanyID";
		private const string _listByContactCommand = "_ListByContactID";
		#endregion
		
		
		//========================================================
		//Object constructors
		//========================================================
		public DalComment() : base("Comment") {}
		
		
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
			
			p = cmd.Parameters.Add("@CommentID", SqlDbType.Int);
			p.SourceColumn = "CommentID";
			p.SourceVersion = DataRowVersion.Current;
			p.Direction = ParameterDirection.Output;
			
			p = cmd.Parameters.Add("@CommentTypeID", SqlDbType.Int);
			p.SourceColumn = "CommentTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
			p.SourceColumn = "ProjectID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ContactID", SqlDbType.Int);
			p.SourceColumn = "ContactID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CreatedByID", SqlDbType.Int);
			p.SourceColumn = "CreatedByID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@AssignedToID", SqlDbType.Int);
			p.SourceColumn = "AssignedToID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Priority", SqlDbType.Int);
			p.SourceColumn = "Priority";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Thread", SqlDbType.VarChar, 50);
			p.SourceColumn = "Thread";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 500);
			p.SourceColumn = "Subject";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Comment", SqlDbType.VarChar, 5000);
			p.SourceColumn = "Comment";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Reminder", SqlDbType.DateTime);
			p.SourceColumn = "Reminder";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Completed", SqlDbType.DateTime);
			p.SourceColumn = "Completed";
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
			
			p = cmd.Parameters.Add("@CommentID", SqlDbType.Int);
			p.SourceColumn = "CommentID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CommentTypeID", SqlDbType.Int);
			p.SourceColumn = "CommentTypeID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
			p.SourceColumn = "ProjectID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			p.SourceColumn = "CompanyID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@ContactID", SqlDbType.Int);
			p.SourceColumn = "ContactID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@CreatedByID", SqlDbType.Int);
			p.SourceColumn = "CreatedByID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@AssignedToID", SqlDbType.Int);
			p.SourceColumn = "AssignedToID";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Priority", SqlDbType.Int);
			p.SourceColumn = "Priority";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Thread", SqlDbType.VarChar, 50);
			p.SourceColumn = "Thread";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 500);
			p.SourceColumn = "Subject";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Comment", SqlDbType.VarChar, 5000);
			p.SourceColumn = "Comment";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Reminder", SqlDbType.DateTime);
			p.SourceColumn = "Reminder";
			p.SourceVersion = DataRowVersion.Current;
			
			p = cmd.Parameters.Add("@Completed", SqlDbType.DateTime);
			p.SourceColumn = "Completed";
			p.SourceVersion = DataRowVersion.Current;
			
			return cmd;
		}

		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by CommentType stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByCommentTypeCmd( int commentTypeID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByCommentTypeCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@CommentTypeID", SqlDbType.Int);
			p.SourceColumn = "CommentTypeID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = commentTypeID;

			return cmd;
		}


		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by Project stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByProjectCmd( int projectID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByProjectCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
			p.SourceColumn = "ProjectID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = projectID;

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


		/// --------------------------------------------------------
		/// <summary>Creates a SqlCommand object for the list by Contact stored procedure</summary>
		/// <returns>Initalized SqlCommand object</returns>
		public SqlCommand GetListByContactCmd( int contactID )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listByContactCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@ContactID", SqlDbType.Int);
			p.SourceColumn = "ContactID";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = contactID;

			return cmd;
		}

		
		#endregion
		

		//========================================================
		//IDalData implementation
		//========================================================
		#region IDalData implementation

		/// --------------------------------------------------------
		/// <summary>Lists the entity by CommentType</summary>
		public int ListByCommentType( int commentTypeID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByCommentTypeCmd( commentTypeID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by CommentType</summary>
		public int ListByCommentType( int commentTypeID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByCommentTypeCmd( commentTypeID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		/// --------------------------------------------------------
		/// <summary>Lists the entity by Project</summary>
		public int ListByProject( int projectID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByProjectCmd( projectID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by Project</summary>
		public int ListByProject( int projectID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByProjectCmd( projectID );

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


		/// --------------------------------------------------------
		/// <summary>Lists the entity by Contact</summary>
		public int ListByContact( int contactID, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListByContactCmd( contactID );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// <summary>Lists the entity by Contact</summary>
		public int ListByContact( int contactID, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListByContactCmd( contactID );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}


		#endregion

	}
}
