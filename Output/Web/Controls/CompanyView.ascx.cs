/********************************************************************************/
namespace Harkins.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Harkins.Biz;

	/// <summary>User control interface class to display Company entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.Controls.CompanyView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class CompanyView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
		//========================================================
		private BizCompany _company;


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
			get { return _company; }
			set { _company = (BizCompany)value; }
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
			lblTitle.Text = "View Company";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_company != null) && (_company.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>CompanyID:</b> " + _company.CompanyID.ToString() + "<br>";
				lblView.Text += "<b>CompanyTypeID:</b> " + _company.CompanyTypeID.ToString() + "<br>";
				lblView.Text += "<b>CompanyStatusID:</b> " + _company.CompanyStatusID.ToString() + "<br>";
				lblView.Text += "<b>CompanyName:</b> " + _company.CompanyName.ToString() + "<br>";
				lblView.Text += "<b>LocationName:</b> " + _company.LocationName.ToString() + "<br>";
				lblView.Text += "<b>StreetAddress:</b> " + _company.StreetAddress.ToString() + "<br>";
				lblView.Text += "<b>Region:</b> " + _company.Region.ToString() + "<br>";
				lblView.Text += "<b>City:</b> " + _company.City.ToString() + "<br>";
				lblView.Text += "<b>State:</b> " + _company.State.ToString() + "<br>";
				lblView.Text += "<b>Zip:</b> " + _company.Zip.ToString() + "<br>";
				lblView.Text += "<b>Phone:</b> " + _company.Phone.ToString() + "<br>";
				lblView.Text += "<b>Fax:</b> " + _company.Fax.ToString() + "<br>";
				lblView.Text += "<b>Website:</b> " + _company.Website.ToString() + "<br>";
				lblView.Text += "<b>Description:</b> " + _company.Description.ToString() + "<br>";
				lblView.Text += "<b>Created:</b> " + _company.Created.ToString() + "<br>";
				lblView.Text += "<b>Updated:</b> " + _company.Updated.ToString() + "<br>";
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

