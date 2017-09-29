using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Web
{
	/// <summary>Interface definition for base web interface edit class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Web.IWebView
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IWebView
	{
		//========================================================
		//Public methods
		//========================================================

		//--------------------------------------------------------
		/// <summary></summary>
		object DataSource { get; set; }

		//--------------------------------------------------------
		/// <summary>Updates the form title</summary>
		string Title { get; set; }

		//--------------------------------------------------------
		/// <summary>Resets the form controls to defaults</summary>
		void Cancel();

		//--------------------------------------------------------
		/// <summary>Binds the business object to the control fields</summary>
		void DataBind();
	}
}