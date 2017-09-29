using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Biz
{
	/// <summary>Interface definition for 3D state holding object</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Biz.IBizState
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IBizState : IEnumerable, IEnumerator
	{
		//========================================================
		//Public methods
		//========================================================

		//--------------------------------------------------------
		/// <summary>Returns the count of DataRows in entity state</summary>
		int Count { get; }
			
		//-------------------------------------------------------
		/// <summary>Returns the DataRow used for entity state</summary>
		DataRow Row { get; }

		//-------------------------------------------------------
		/// <summary>Returns the DataTable used for entity state</summary>
		DataTable Table { get; }

		//-------------------------------------------------------
		/// <summary>Returns the DataView used for entity state</summary>
		DataView DefaultView { get; }

		//--------------------------------------------------------
		/// <summary>Creates data access object for the entity</summary>
		bool CreateDal();

		//--------------------------------------------------------
		/// <summary>Creates empty state for the entity</summary>
		bool CreateState();

		//--------------------------------------------------------
		/// <summary>Checks current state for entity</summary>
		bool HasState();

		//--------------------------------------------------------
		/// <summary>Returns the DataSet state for the current entity</summary>
		DataSet GetState();

		//--------------------------------------------------------
		/// <summary>Sortes the current list of entites in state</summary>
		bool Sort(string orderBy);

		//--------------------------------------------------------
		/// <summary>Filters the current list of entites in state</summary>
		bool Filter(string fk, int id);
		bool Filter(string col, string val);

		//--------------------------------------------------------
		/// <summary>Removes the current datarow from the datatable</summary>
		bool Remove();

		//--------------------------------------------------------
		/// <summary>Deletes the current instance from state</summary>
		bool Delete();
	
		//--------------------------------------------------------
		/// <summary>Returns true or false</summary>
		bool IsNull(string fieldIndex);

		//--------------------------------------------------------
		/// <summary>Checks for entity level state holding object (DataRow) has related child data</summary>
		bool HasChildren(string relatedTable);

		//--------------------------------------------------------
		/// <summary>Checks the order of names for data relationship</summary>
		string GetRelationshipName(string relatedTable);

		//--------------------------------------------------------
		/// <summary>Gets or sets the indexed entity value in state</summary>
		object this[string fieldIndex] { get; set; }
	}
}