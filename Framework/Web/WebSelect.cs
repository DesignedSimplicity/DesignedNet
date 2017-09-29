using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DesignedNet.Framework.Web
{
	/// <summary>Nav HTML User Control</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Web.Controls.WebSelect
	/// Language:	C# ASP.NET
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	01.24.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	[DefaultProperty("SelectedIndex"), 
	ToolboxData("<{0}:WebSelect runat=server></{0}:WebSelect>")]
	public class WebSelect : System.Web.UI.WebControls.DropDownList
	{
		//========================================================
		//Module level enumerations
		//========================================================
		public enum DisplayMode { Active, Passive }

		//========================================================
		//Module level variables
		//========================================================
		protected DisplayMode _mode;		// display mode for nav tree


		//========================================================
		//Property get/set methods
		//========================================================
		#region Property get/set methods
		#endregion

		
		//========================================================
		//Public methods
		//========================================================


		//========================================================
		//Private methods
		//========================================================

	}
}
