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

	/// <summary>User control interface class to display Organization entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.Controls.OrganizationView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class OrganizationView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
		//========================================================
		private BizOrganization _organization;


		//========================================================
		//Property get/set methods
		//========================================================
		#region Property get/set methods

		/// --------------------------------------------------------
		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		/// --------------------------------------------------------
		public object DataSource
		{
			get { return _organization; }
			set { _organization = (BizOrganization)value; }
		}

		#endregion


		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void Cancel()
		{
			// reset values
			lblView.Text = "";
			lblTitle.Text = "View Organization";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_organization != null) && (_organization.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>SetupID:</b> " + _organization.SetupID.ToString() + "<br>";
				lblView.Text += "<b>Organization:</b> " + _organization.Organization.ToString() + "<br>";
				lblView.Text += "<b>Address:</b> " + _organization.Address.ToString() + "<br>";
				lblView.Text += "<b>City:</b> " + _organization.City.ToString() + "<br>";
				lblView.Text += "<b>State:</b> " + _organization.State.ToString() + "<br>";
				lblView.Text += "<b>Zip:</b> " + _organization.Zip.ToString() + "<br>";
				lblView.Text += "<b>Phone:</b> " + _organization.Phone.ToString() + "<br>";
				lblView.Text += "<b>Fax:</b> " + _organization.Fax.ToString() + "<br>";
			}
		}
		
	
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

