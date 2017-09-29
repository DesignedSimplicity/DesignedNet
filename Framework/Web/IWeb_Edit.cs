using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Web
{
	/// <summary>Interface definition for base web interface edit class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Web.IWebEdit
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IWebEdit : IWebView
	{
		//========================================================
		//Public methods
		//========================================================

		//--------------------------------------------------------
		/// <summary>Places the form in new mode</summary>
		void New();

		//--------------------------------------------------------
		/// <summary>Places the form in edit mode</summary>
		void Edit();

		//--------------------------------------------------------
		/// <summary>Populates the form controls with required reference data</summary>
		void LoadRefData();

		//--------------------------------------------------------
		/// <summary>Validates the user control and updates the business object</summary>
		/// <returns>Null string if form valid, error message otherwise</returns>
		string Validate();
	}
}