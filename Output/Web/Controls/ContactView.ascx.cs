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

	/// <summary>User control interface class to display Contact entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.Controls.ContactView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class ContactView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
		//========================================================
		private BizContact _contact;


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
			get { return _contact; }
			set { _contact = (BizContact)value; }
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
			lblTitle.Text = "View Contact";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_contact != null) && (_contact.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>ContactID:</b> " + _contact.ContactID.ToString() + "<br>";
				lblView.Text += "<b>ContactTypeID:</b> " + _contact.ContactTypeID.ToString() + "<br>";
				lblView.Text += "<b>ContactStatusID:</b> " + _contact.ContactStatusID.ToString() + "<br>";
				lblView.Text += "<b>CompanyID:</b> " + _contact.CompanyID.ToString() + "<br>";
				lblView.Text += "<b>SessionID:</b> " + _contact.SessionID.ToString() + "<br>";
				lblView.Text += "<b>Prefix:</b> " + _contact.Prefix.ToString() + "<br>";
				lblView.Text += "<b>FirstName:</b> " + _contact.FirstName.ToString() + "<br>";
				lblView.Text += "<b>LastName:</b> " + _contact.LastName.ToString() + "<br>";
				lblView.Text += "<b>JobTitle:</b> " + _contact.JobTitle.ToString() + "<br>";
				lblView.Text += "<b>OfficeNumber:</b> " + _contact.OfficeNumber.ToString() + "<br>";
				lblView.Text += "<b>MobileNumber:</b> " + _contact.MobileNumber.ToString() + "<br>";
				lblView.Text += "<b>HomeNumber:</b> " + _contact.HomeNumber.ToString() + "<br>";
				lblView.Text += "<b>OtherNumber:</b> " + _contact.OtherNumber.ToString() + "<br>";
				lblView.Text += "<b>FaxNumber:</b> " + _contact.FaxNumber.ToString() + "<br>";
				lblView.Text += "<b>EmailAddress:</b> " + _contact.EmailAddress.ToString() + "<br>";
				lblView.Text += "<b>Description:</b> " + _contact.Description.ToString() + "<br>";
				lblView.Text += "<b>Username:</b> " + _contact.Username.ToString() + "<br>";
				lblView.Text += "<b>Password:</b> " + _contact.Password.ToString() + "<br>";
				lblView.Text += "<b>Created:</b> " + _contact.Created.ToString() + "<br>";
				lblView.Text += "<b>Updated:</b> " + _contact.Updated.ToString() + "<br>";
				lblView.Text += "<b>LastLogin:</b> " + _contact.LastLogin.ToString() + "<br>";
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

