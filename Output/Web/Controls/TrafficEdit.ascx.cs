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

	/// <summary>User control interface class to edit Traffic entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.TrafficEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class TrafficEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selFacilityID;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtNewCallFromWeb;
		protected System.Web.UI.WebControls.TextBox txtNewCallFromYellow;
		protected System.Web.UI.WebControls.TextBox txtNewCallFromOther;
		protected System.Web.UI.WebControls.TextBox txtTotalCalls;
		protected System.Web.UI.WebControls.TextBox txtWalkinWeb;
		protected System.Web.UI.WebControls.TextBox txtWalkinYellow;
		protected System.Web.UI.WebControls.TextBox txtWalkinOther;
		protected System.Web.UI.WebControls.TextBox txtWalkinTotal;
		protected System.Web.UI.WebControls.TextBox txtRented;
		protected System.Web.UI.WebControls.TextBox txtMovin;
		protected System.Web.UI.WebControls.TextBox txtMoveOut;
		protected System.Web.UI.WebControls.TextBox txtTransfer;
		protected System.Web.UI.WebControls.TextBox txtVacated;
		protected System.Web.UI.WebControls.TextBox txtComments;

		//========================================================
		//Global variables
		//========================================================
		private BizTraffic _traffic;


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
			get { return _traffic; }
			set { _traffic = (BizTraffic)value; }
		}

		#endregion
		

		
		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Traffic";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Traffic";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selFacilityID.SelectedIndex = 0;
			txtDate.Text = "";
			txtNewCallFromWeb.Text = "";
			txtNewCallFromYellow.Text = "";
			txtNewCallFromOther.Text = "";
			txtTotalCalls.Text = "";
			txtWalkinWeb.Text = "";
			txtWalkinYellow.Text = "";
			txtWalkinOther.Text = "";
			txtWalkinTotal.Text = "";
			txtRented.Text = "";
			txtMovin.Text = "";
			txtMoveOut.Text = "";
			txtTransfer.Text = "";
			txtVacated.Text = "";
			txtComments.Text = "";
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
				if ((_traffic != null) && (_traffic.HasState()))
				{
					if (selFacilityID.SelectedIndex < 1) _traffic.FacilityIDIsNull = true; else _traffic._facilityID = Convert.ToInt32(selFacilityID.SelectedValue);
					_traffic._date = txtDate.Text;
					if (txtNewCallFromWeb.Text.Length == 0) _traffic.NewCallFromWebIsNull = true; else _traffic._newCallFromWeb = DesignedNet.Framework.Web.Common.GetInteger(txtNewCallFromWeb);
					if (txtNewCallFromYellow.Text.Length == 0) _traffic.NewCallFromYellowIsNull = true; else _traffic._newCallFromYellow = DesignedNet.Framework.Web.Common.GetInteger(txtNewCallFromYellow);
					if (txtNewCallFromOther.Text.Length == 0) _traffic.NewCallFromOtherIsNull = true; else _traffic._newCallFromOther = DesignedNet.Framework.Web.Common.GetInteger(txtNewCallFromOther);
					if (txtTotalCalls.Text.Length == 0) _traffic.TotalCallsIsNull = true; else _traffic._totalCalls = DesignedNet.Framework.Web.Common.GetInteger(txtTotalCalls);
					if (txtWalkinWeb.Text.Length == 0) _traffic.WalkinWebIsNull = true; else _traffic._walkinWeb = DesignedNet.Framework.Web.Common.GetInteger(txtWalkinWeb);
					if (txtWalkinYellow.Text.Length == 0) _traffic.WalkinYellowIsNull = true; else _traffic._walkinYellow = DesignedNet.Framework.Web.Common.GetInteger(txtWalkinYellow);
					if (txtWalkinOther.Text.Length == 0) _traffic.WalkinOtherIsNull = true; else _traffic._walkinOther = DesignedNet.Framework.Web.Common.GetInteger(txtWalkinOther);
					if (txtWalkinTotal.Text.Length == 0) _traffic.WalkinTotalIsNull = true; else _traffic._walkinTotal = DesignedNet.Framework.Web.Common.GetInteger(txtWalkinTotal);
					if (txtRented.Text.Length == 0) _traffic.RentedIsNull = true; else _traffic._rented = DesignedNet.Framework.Web.Common.GetInteger(txtRented);
					if (txtMovin.Text.Length == 0) _traffic.MovinIsNull = true; else _traffic._movin = DesignedNet.Framework.Web.Common.GetInteger(txtMovin);
					if (txtMoveOut.Text.Length == 0) _traffic.MoveOutIsNull = true; else _traffic._moveOut = DesignedNet.Framework.Web.Common.GetInteger(txtMoveOut);
					if (txtTransfer.Text.Length == 0) _traffic.TransferIsNull = true; else _traffic._transfer = DesignedNet.Framework.Web.Common.GetInteger(txtTransfer);
					if (txtVacated.Text.Length == 0) _traffic.VacatedIsNull = true; else _traffic._vacated = DesignedNet.Framework.Web.Common.GetInteger(txtVacated);
					_traffic._comments = txtComments.Text;
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
			if ((_traffic != null) && (_traffic.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selFacilityID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selFacilityID.Items, _traffic._facilityID);
				txtDate.Text = _traffic.Date.ToString();
				txtNewCallFromWeb.Text = _traffic.NewCallFromWeb.ToString();
				txtNewCallFromYellow.Text = _traffic.NewCallFromYellow.ToString();
				txtNewCallFromOther.Text = _traffic.NewCallFromOther.ToString();
				txtTotalCalls.Text = _traffic.TotalCalls.ToString();
				txtWalkinWeb.Text = _traffic.WalkinWeb.ToString();
				txtWalkinYellow.Text = _traffic.WalkinYellow.ToString();
				txtWalkinOther.Text = _traffic.WalkinOther.ToString();
				txtWalkinTotal.Text = _traffic.WalkinTotal.ToString();
				txtRented.Text = _traffic.Rented.ToString();
				txtMovin.Text = _traffic.Movin.ToString();
				txtMoveOut.Text = _traffic.MoveOut.ToString();
				txtTransfer.Text = _traffic.Transfer.ToString();
				txtVacated.Text = _traffic.Vacated.ToString();
				txtComments.Text = _traffic.Comments.ToString();
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

