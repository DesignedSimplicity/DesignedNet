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

	/// <summary>User control interface class to edit Organization entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.OrganizationEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class OrganizationEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtOrganization;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;

		//========================================================
		//Global variables
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
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Organization";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Organization";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			txtOrganization.Text = "";
			txtAddress.Text = "";
			txtCity.Text = "";
			txtState.Text = "";
			txtZip.Text = "";
			txtPhone.Text = "";
			txtFax.Text = "";
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			
		}

		/// --------------------------------------------------------
		public string Validate()
		{
			string msg = "";

			// validate form controls

			// update business object if valid
			if (msg.Length == 0) 
			{
				// make sure entity has state
				if ((_organization != null) && (_organization.HasState()))
				{
					_organization._organization = txtOrganization.Text;
					_organization._address = txtAddress.Text;
					_organization._city = txtCity.Text;
					_organization._state = txtState.Text;
					_organization._zip = txtZip.Text;
					_organization._phone = txtPhone.Text;
					_organization._fax = txtFax.Text;
				}
				else
					msg = "ERROR: Business object does not have state!<br>";
			}

			return msg;
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_organization != null) && (_organization.HasState()))
			{
				txtOrganization.Text = _organization.Organization.ToString();
				txtAddress.Text = _organization.Address.ToString();
				txtCity.Text = _organization.City.ToString();
				txtState.Text = _organization.State.ToString();
				txtZip.Text = _organization.Zip.ToString();
				txtPhone.Text = _organization.Phone.ToString();
				txtFax.Text = _organization.Fax.ToString();
			}
		}


		//========================================================
		//Page event handlers
		//========================================================

		/// --------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			// initalize page
			if (!Page.IsPostBack)
			{
				// load all data needed for form
				LoadRefData();
			}
		}


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

