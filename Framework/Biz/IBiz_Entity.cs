using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Biz
{
	/// <summary>Interface definition for base business logic entity class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Biz.IBizEntity
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IBizEntity
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary>Creates a new instance of state</summary>
		bool New();

		//--------------------------------------------------------
		/// <summary>Saves the current instance</summary>
		bool Save();

		//--------------------------------------------------------
		/// <summary>Loads the default list of entites</summary>
		bool List();

		//--------------------------------------------------------
		/// <summary>Finds the specified instance in state</summary>
		bool Find(int id);
	
		//--------------------------------------------------------
		/// <summary>Loads the specified instance</summary>
		bool Load(int id);

		//--------------------------------------------------------
		/// <summary>Deletes the specified instance</summary>
		bool Delete(int id);
	
		//--------------------------------------------------------
		/// <summary>Saves the current list of entites in state</summary>
		bool SaveAll();
	}
}