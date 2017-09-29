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

	/// <summary>User control interface class to edit Company entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.CompanyEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class CompanyEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selCompanyTypeID;
		protected System.Web.UI.WebControls.DropDownList selCompanyStatusID;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.TextBox txtLocationName;
		protected System.Web.UI.WebControls.TextBox txtStreetAddress;
		protected System.Web.UI.WebControls.TextBox txtRegion;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtWebsite;
		protected System.Web.UI.WebControls.TextBox txtDescription;

		//========================================================
		//Global variables
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
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Company";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Company";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selCompanyTypeID.SelectedIndex = 0;
			selCompanyStatusID.SelectedIndex = 0;
			txtCompanyName.Text = "";
			txtLocationName.Text = "";
			txtStreetAddress.Text = "";
			txtRegion.Text = "";
			txtCity.Text = "";
			txtState.Text = "";
			txtZip.Text = "";
			txtPhone.Text = "";
			txtFax.Text = "";
			txtWebsite.Text = "";
			txtDescription.Text = "";
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			
			BizCompanyType companyType = new BizCompanyType();
			companyType.List();
			selCompanyTypeID.DataValueField = "CompanyTypeID";
			selCompanyTypeID.DataTextField = "CompanyTypeID";
			selCompanyTypeID.DataSource = companyType;
			selCompanyTypeID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selCompanyTypeID.Items);
			 
			BizCompanyStatus companyStatus = new BizCompanyStatus();
			companyStatus.List();
			selCompanyStatusID.DataValueField = "CompanyStatusID";
			selCompanyStatusID.DataTextField = "CompanyStatusID";
			selCompanyStatusID.DataSource = companyStatus;
			selCompanyStatusID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selCompanyStatusID.Items);
			 
		}

		/// --------------------------------------------------------
		public string Validate()
		{
			string msg = "";

			// validate form controls
				if (selCompanyTypeID.SelectedIndex < 1) msg += "Please select the CompanyTypeID field...<br>";
				if (selCompanyStatusID.SelectedIndex < 1) msg += "Please select the CompanyStatusID field...<br>";
				if (DesignedNet.Framework.Web.Common.RequiredText(txtCompanyName)) msg += "Please enter the CompanyName field...<br>";

			// update business object if valid
			if (msg.Length == 0) 
			{
				// make sure entity has state
				if ((_company != null) && (_company.HasState()))
				{
					_company._companyTypeID = Convert.ToInt32(selCompanyTypeID.SelectedValue);
					_company._companyStatusID = Convert.ToInt32(selCompanyStatusID.SelectedValue);
					_company._companyName = txtCompanyName.Text;
					_company._locationName = txtLocationName.Text;
					_company._streetAddress = txtStreetAddress.Text;
					_company._region = txtRegion.Text;
					_company._city = txtCity.Text;
					_company._state = txtState.Text;
					_company._zip = txtZip.Text;
					_company._phone = txtPhone.Text;
					_company._fax = txtFax.Text;
					_company._website = txtWebsite.Text;
					_company._description = txtDescription.Text;
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
			if ((_company != null) && (_company.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selCompanyTypeID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selCompanyTypeID.Items, _company._companyTypeID);
				DesignedNet.Framework.Web.Common.ClearSelection(selCompanyStatusID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selCompanyStatusID.Items, _company._companyStatusID);
				txtCompanyName.Text = _company.CompanyName.ToString();
				txtLocationName.Text = _company.LocationName.ToString();
				txtStreetAddress.Text = _company.StreetAddress.ToString();
				txtRegion.Text = _company.Region.ToString();
				txtCity.Text = _company.City.ToString();
				txtState.Text = _company.State.ToString();
				txtZip.Text = _company.Zip.ToString();
				txtPhone.Text = _company.Phone.ToString();
				txtFax.Text = _company.Fax.ToString();
				txtWebsite.Text = _company.Website.ToString();
				txtDescription.Text = _company.Description.ToString();
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

