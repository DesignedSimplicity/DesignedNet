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

	/// <summary>User control interface class to edit Contact entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.ContactEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/29/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class ContactEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selContactTypeID;
		protected System.Web.UI.WebControls.DropDownList selContactStatusID;
		protected System.Web.UI.WebControls.DropDownList selCompanyID;
		protected System.Web.UI.WebControls.TextBox txtSessionID;
		protected System.Web.UI.WebControls.TextBox txtPrefix;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtJobTitle;
		protected System.Web.UI.WebControls.TextBox txtOfficeNumber;
		protected System.Web.UI.WebControls.TextBox txtMobileNumber;
		protected System.Web.UI.WebControls.TextBox txtHomeNumber;
		protected System.Web.UI.WebControls.TextBox txtOtherNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.TextBox txtEmailAddress;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.TextBox txtUsername;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtLastLogin;

		//========================================================
		//Global variables
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
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Contact";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Contact";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selContactTypeID.SelectedIndex = 0;
			selContactStatusID.SelectedIndex = 0;
			selCompanyID.SelectedIndex = 0;
			txtSessionID.Text = "";
			txtPrefix.Text = "";
			txtFirstName.Text = "";
			txtLastName.Text = "";
			txtJobTitle.Text = "";
			txtOfficeNumber.Text = "";
			txtMobileNumber.Text = "";
			txtHomeNumber.Text = "";
			txtOtherNumber.Text = "";
			txtFaxNumber.Text = "";
			txtEmailAddress.Text = "";
			txtDescription.Text = "";
			txtUsername.Text = "";
			txtPassword.Text = "";
			txtLastLogin.Text = "";
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			
			BizContactType contactType = new BizContactType();
			contactType.List();
			selContactTypeID.DataValueField = "ContactTypeID";
			selContactTypeID.DataTextField = "ContactTypeID";
			selContactTypeID.DataSource = contactType;
			selContactTypeID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selContactTypeID.Items);
			 
			BizContactStatus contactStatus = new BizContactStatus();
			contactStatus.List();
			selContactStatusID.DataValueField = "ContactStatusID";
			selContactStatusID.DataTextField = "ContactStatusID";
			selContactStatusID.DataSource = contactStatus;
			selContactStatusID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selContactStatusID.Items);
			 
			BizCompany company = new BizCompany();
			company.List();
			selCompanyID.DataValueField = "CompanyID";
			selCompanyID.DataTextField = "CompanyID";
			selCompanyID.DataSource = company;
			selCompanyID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selCompanyID.Items);
			 
		}

		/// --------------------------------------------------------
		public string Validate()
		{
			string msg = "";

			// validate form controls
				if (selContactTypeID.SelectedIndex < 1) msg += "Please select the ContactTypeID field...<br>";
				if (selContactStatusID.SelectedIndex < 1) msg += "Please select the ContactStatusID field...<br>";
				if (selCompanyID.SelectedIndex < 1) msg += "Please select the CompanyID field...<br>";
				if (DesignedNet.Framework.Web.Common.RequiredText(txtLastName)) msg += "Please enter the LastName field...<br>";

			// update business object if valid
			if (msg.Length == 0) 
			{
				// make sure entity has state
				if ((_contact != null) && (_contact.HasState()))
				{
					_contact._contactTypeID = Convert.ToInt32(selContactTypeID.SelectedValue);
					_contact._contactStatusID = Convert.ToInt32(selContactStatusID.SelectedValue);
					_contact._companyID = Convert.ToInt32(selCompanyID.SelectedValue);
					_contact._sessionID = txtSessionID.Text;
					_contact._prefix = txtPrefix.Text;
					_contact._firstName = txtFirstName.Text;
					_contact._lastName = txtLastName.Text;
					_contact._jobTitle = txtJobTitle.Text;
					_contact._officeNumber = txtOfficeNumber.Text;
					_contact._mobileNumber = txtMobileNumber.Text;
					_contact._homeNumber = txtHomeNumber.Text;
					_contact._otherNumber = txtOtherNumber.Text;
					_contact._faxNumber = txtFaxNumber.Text;
					_contact._emailAddress = txtEmailAddress.Text;
					_contact._description = txtDescription.Text;
					_contact._username = txtUsername.Text;
					_contact._password = txtPassword.Text;
					if (txtLastLogin.Text.Length == 0) _contact.LastLoginIsNull = true; else _contact._lastLogin = DesignedNet.Framework.Web.Common.GetDateTime(txtLastLogin);
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
			if ((_contact != null) && (_contact.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selContactTypeID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selContactTypeID.Items, _contact._contactTypeID);
				DesignedNet.Framework.Web.Common.ClearSelection(selContactStatusID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selContactStatusID.Items, _contact._contactStatusID);
				DesignedNet.Framework.Web.Common.ClearSelection(selCompanyID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selCompanyID.Items, _contact._companyID);
				txtSessionID.Text = _contact.SessionID.ToString();
				txtPrefix.Text = _contact.Prefix.ToString();
				txtFirstName.Text = _contact.FirstName.ToString();
				txtLastName.Text = _contact.LastName.ToString();
				txtJobTitle.Text = _contact.JobTitle.ToString();
				txtOfficeNumber.Text = _contact.OfficeNumber.ToString();
				txtMobileNumber.Text = _contact.MobileNumber.ToString();
				txtHomeNumber.Text = _contact.HomeNumber.ToString();
				txtOtherNumber.Text = _contact.OtherNumber.ToString();
				txtFaxNumber.Text = _contact.FaxNumber.ToString();
				txtEmailAddress.Text = _contact.EmailAddress.ToString();
				txtDescription.Text = _contact.Description.ToString();
				txtUsername.Text = _contact.Username.ToString();
				txtPassword.Text = _contact.Password.ToString();
				txtLastLogin.Text = _contact.LastLogin.ToString();
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

