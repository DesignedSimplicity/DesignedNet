using System;
using System.Collections;
using System.Data;

//----------------------------
namespace DesignedNet.Framework.Web
{
	/// <summary>Interface definition for base web interface list class</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Web.IWebList
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	03.17.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public interface IWebList
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary></summary>
		object DataSource { get; set; }

		//--------------------------------------------------------
		/// <summary>Gets or sets the url used for the link</summary>
		string NavigateUrl { get; set; }
	}
}