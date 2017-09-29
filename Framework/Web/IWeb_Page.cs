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
	public interface IWebPage
	{
		//========================================================
		//Public methods
		//========================================================
	
		//--------------------------------------------------------
		/// <summary>Checks the user session and security if required, configures role security</summary>
		void DoSecurity();

		//--------------------------------------------------------
		/// <summary>Renders the form in edit mode</summary>
		void cmdEdit_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Validates user control and creates new record</summary>
		void cmdCreate_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Validates user control and updates exisiting record</summary>
		void cmdUpdate_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Finds a record given a key value or lists all</summary>
		void cmdSearch_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Renders the form in delete item mode</summary>
		void cmdDelete_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Accepts and process the delete request</summary>
		void cmdAccept_Click(object sender, System.EventArgs e);

		//--------------------------------------------------------
		/// <summary>Renders the page in the specified page mode</summary>
		void Render(Common.PageMode pageMode);
		void Render(Common.PageMode pageMode, string message);
	}
}