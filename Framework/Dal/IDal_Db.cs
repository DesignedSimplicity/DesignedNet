using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

//----------------------------
namespace DesignedNet.Framework.Dal
{
	/// <summary>Interface definition for base data access layer command builder</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Dal.IDalDb
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IDalDb
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary>Builds the list command for sql</summary>
		OleDbCommand GetListCmd();

		//--------------------------------------------------------
		/// <summary>Builds the list by command index for sql</summary>
		OleDbCommand GetListByColumnCmd(string index, object fk);

		//--------------------------------------------------------
		/// <summary>Builds the insert command for sql</summary>
		OleDbCommand GetInsertCmd();

		//--------------------------------------------------------
		/// <summary>Builds the select command for sql</summary>
		OleDbCommand GetSelectCmd(object pk);

		//--------------------------------------------------------
		/// <summary>Builds the update command for sql</summary>
		OleDbCommand GetUpdateCmd();

		//--------------------------------------------------------
		/// <summary>Builds the delete command for sql</summary>
		OleDbCommand GetDeleteCmd();
		OleDbCommand GetDeleteCmd(object pk);
	}
}