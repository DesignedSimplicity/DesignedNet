using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//----------------------------
namespace DesignedNet.Framework.Dal
{
	/// <summary>Interface definition for base data access layer command builder</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Dal.IDalSql
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IDalSql
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary>Builds the list command for sql</summary>
		SqlCommand GetListCmd();

		//--------------------------------------------------------
		/// <summary>Builds the list by command index for sql</summary>
		SqlCommand GetListByColumnCmd(string index, object fk);

		//--------------------------------------------------------
		/// <summary>Builds the insert command for sql</summary>
		SqlCommand GetInsertCmd();

		//--------------------------------------------------------
		/// <summary>Builds the select command for sql</summary>
		SqlCommand GetSelectCmd(object pk);

		//--------------------------------------------------------
		/// <summary>Builds the update command for sql</summary>
		SqlCommand GetUpdateCmd();

		//--------------------------------------------------------
		/// <summary>Builds the delete command for sql</summary>
		SqlCommand GetDeleteCmd();
		SqlCommand GetDeleteCmd(object pk);
	}
}