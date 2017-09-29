using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Dal
{
	/// <summary>Interface definition for base data access layer action object</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Dal.IDalData
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IDalData
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary>Closes any open database connection</summary>
		void Close();
		
		//--------------------------------------------------------
		/// <summary>List the entities</summary>
		int List(DataTable table);

		//--------------------------------------------------------
		/// <summary>Report the entities</summary>
		int Report(DataTable table);

		//--------------------------------------------------------
		/// <summary>Selects the entity specified</summary>
		int Select(object pk, DataTable table);

		//--------------------------------------------------------
		/// <summary>Inserts the entity specified</summary>
		int Insert(DataRow row);
	
		//--------------------------------------------------------
		/// <summary>Updates the entity specified</summary>
		int Update(DataRow row);
		int Update(DataTable table);

		//--------------------------------------------------------
		/// <summary>Deletes the entity specified</summary>
		int Delete(object pk);
		int Delete(DataRow row);

		//--------------------------------------------------------
		/// <summary>List the entity by specified column</summary>
		int ListByColumn(string column, object data, DataTable table);
	}
}