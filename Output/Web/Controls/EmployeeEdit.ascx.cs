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

	/// <summary>User control interface class to edit Employee entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.EmployeeEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class EmployeeEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtFullName;
		protected System.Web.UI.WebControls.TextBox txtPosition;
		protected System.Web.UI.WebControls.DropDownList selFacilityID;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtEmailAdd;
		protected System.Web.UI.WebControls.TextBox txtTotlSqFoot;

		//========================================================
		//Global variables
		//========================================================
		private BizEmployee _employee;


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
			get { return _employee; }
			set { _employee = (BizEmployee)value; }
		}

		#endregion
		

		
		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Employee";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Employee";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			txtFullName.Text = "";
			txtPosition.Text = "";
			selFacilityID.SelectedIndex = 0;
			txtState.Text = "";
			txtZip.Text = "";
			txtPhone.Text = "";
			txtFax.Text = "";
			txtEmailAdd.Text = "";
			txtTotlSqFoot.Text = "";
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			
			BizFacility facility = new BizFacility();
			facility.List();
			selFacilityID.DataValueField = "FacilityID";
			selFacilityID.DataTextField = "FacilityID";
			selFacilityID.DataSource = facility;
			selFacilityID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selFacilityID.Items);
			 
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
				if ((_employee != null) && (_employee.HasState()))
				{
					_employee._fullName = txtFullName.Text;
					_employee._position = txtPosition.Text;
					if (selFacilityID.SelectedIndex < 1) _employee.FacilityIDIsNull = true; else _employee._facilityID = Convert.ToInt32(selFacilityID.SelectedValue);
					_employee._state = txtState.Text;
					if (txtZip.Text.Length == 0) _employee.ZipIsNull = true; else _employee._zip = DesignedNet.Framework.Web.Common.GetInteger(txtZip);
					_employee._phone = txtPhone.Text;
					_employee._fax = txtFax.Text;
					_employee._emailAdd = txtEmailAdd.Text;
					if (txtTotlSqFoot.Text.Length == 0) _employee.TotlSqFootIsNull = true; else _employee._totlSqFoot = DesignedNet.Framework.Web.Common.GetInteger(txtTotlSqFoot);
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
			if ((_employee != null) && (_employee.HasState()))
			{
				txtFullName.Text = _employee.FullName.ToString();
				txtPosition.Text = _employee.Position.ToString();
				DesignedNet.Framework.Web.Common.ClearSelection(selFacilityID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selFacilityID.Items, _employee._facilityID);
				txtState.Text = _employee.State.ToString();
				txtZip.Text = _employee.Zip.ToString();
				txtPhone.Text = _employee.Phone.ToString();
				txtFax.Text = _employee.Fax.ToString();
				txtEmailAdd.Text = _employee.EmailAdd.ToString();
				txtTotlSqFoot.Text = _employee.TotlSqFoot.ToString();
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

