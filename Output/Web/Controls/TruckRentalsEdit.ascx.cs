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

	/// <summary>User control interface class to edit TruckRentals entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.TruckRentalsEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class TruckRentalsEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selFacilityID;
		protected System.Web.UI.WebControls.TextBox txtEnteredDate;
		protected System.Web.UI.WebControls.TextBox txtAppliedDate;
		protected System.Web.UI.WebControls.TextBox txtAmount;

		//========================================================
		//Global variables
		//========================================================
		private BizTruckRentals _truckRentals;


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
			get { return _truckRentals; }
			set { _truckRentals = (BizTruckRentals)value; }
		}

		#endregion
		

		
		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void New()
		{
			// show form title
			lblTitle.Text = "Create TruckRentals";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update TruckRentals";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selFacilityID.SelectedIndex = 0;
			txtEnteredDate.Text = "";
			txtAppliedDate.Text = "";
			txtAmount.Text = "";
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
				if ((_truckRentals != null) && (_truckRentals.HasState()))
				{
					if (selFacilityID.SelectedIndex < 1) _truckRentals.FacilityIDIsNull = true; else _truckRentals._facilityID = Convert.ToInt32(selFacilityID.SelectedValue);
					_truckRentals._enteredDate = txtEnteredDate.Text;
					_truckRentals._appliedDate = txtAppliedDate.Text;
					if (txtAmount.Text.Length == 0) _truckRentals.AmountIsNull = true; else _truckRentals._amount = DesignedNet.Framework.Web.Common.GetDecimal(txtAmount);
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
			if ((_truckRentals != null) && (_truckRentals.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selFacilityID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selFacilityID.Items, _truckRentals._facilityID);
				txtEnteredDate.Text = _truckRentals.EnteredDate.ToString();
				txtAppliedDate.Text = _truckRentals.AppliedDate.ToString();
				txtAmount.Text = _truckRentals.Amount.ToString();
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

