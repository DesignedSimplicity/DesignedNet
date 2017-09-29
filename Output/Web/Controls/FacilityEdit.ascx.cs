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

	/// <summary>User control interface class to edit Facility entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.FacilityEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class FacilityEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtFacilityName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtEmailAdd;
		protected System.Web.UI.WebControls.TextBox txtTotlSqFoot;
		protected System.Web.UI.WebControls.TextBox txtUserName;

		//========================================================
		//Global variables
		//========================================================
		private BizFacility _facility;


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
			get { return _facility; }
			set { _facility = (BizFacility)value; }
		}

		#endregion
		

		
		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Facility";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Facility";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			txtFacilityName.Text = "";
			txtAddress.Text = "";
			txtCity.Text = "";
			txtState.Text = "";
			txtZip.Text = "";
			txtPhone.Text = "";
			txtFax.Text = "";
			txtEmailAdd.Text = "";
			txtTotlSqFoot.Text = "";
			txtUserName.Text = "";
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
				if ((_facility != null) && (_facility.HasState()))
				{
					_facility._facilityName = txtFacilityName.Text;
					_facility._address = txtAddress.Text;
					_facility._city = txtCity.Text;
					_facility._state = txtState.Text;
					if (txtZip.Text.Length == 0) _facility.ZipIsNull = true; else _facility._zip = DesignedNet.Framework.Web.Common.GetInteger(txtZip);
					_facility._phone = txtPhone.Text;
					_facility._fax = txtFax.Text;
					_facility._emailAdd = txtEmailAdd.Text;
					if (txtTotlSqFoot.Text.Length == 0) _facility.TotlSqFootIsNull = true; else _facility._totlSqFoot = DesignedNet.Framework.Web.Common.GetInteger(txtTotlSqFoot);
					_facility._userName = txtUserName.Text;
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
			if ((_facility != null) && (_facility.HasState()))
			{
				txtFacilityName.Text = _facility.FacilityName.ToString();
				txtAddress.Text = _facility.Address.ToString();
				txtCity.Text = _facility.City.ToString();
				txtState.Text = _facility.State.ToString();
				txtZip.Text = _facility.Zip.ToString();
				txtPhone.Text = _facility.Phone.ToString();
				txtFax.Text = _facility.Fax.ToString();
				txtEmailAdd.Text = _facility.EmailAdd.ToString();
				txtTotlSqFoot.Text = _facility.TotlSqFoot.ToString();
				txtUserName.Text = _facility.UserName.ToString();
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

