/********************************************************************************/
namespace Storage.Framework.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Storage.Framework.Biz;

	/// <summary>User control interface class to list Traffic entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.Controls.TrafficList
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class TrafficList : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebList
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.DataList list;


		//========================================================
		//Private variables
		//========================================================
		protected string _navigateUrl = "ManageTraffic.aspx?TrafficID=";


		//========================================================
		//Property get/set methods
		//========================================================
		#region Property get/set methods

		/// --------------------------------------------------------
		public object DataSource
		{
			get { return list.DataSource; }
			set { list.DataSource = value; }
		}

		/// --------------------------------------------------------
		public string NavigateUrl
		{
			get { return _navigateUrl; }
			set { _navigateUrl = value; }
		}

		#endregion


		//========================================================
		//Page event handlers
		//========================================================

		/// --------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
		}


		//========================================================
		//Web Form Designer generated code
		//========================================================
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

	}
}

