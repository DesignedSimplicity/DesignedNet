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

	/// <summary>User control interface class to edit Finance entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.FinanceEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	2/24/2009 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class FinanceEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selFacilityID;
		protected System.Web.UI.WebControls.TextBox txtTrafficID;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtLookup-Fac;
		protected System.Web.UI.WebControls.TextBox txtCash;
		protected System.Web.UI.WebControls.TextBox txtChecks;
		protected System.Web.UI.WebControls.TextBox txtCCards;
		protected System.Web.UI.WebControls.TextBox txtMiscCredit;
		protected System.Web.UI.WebControls.TextBox txtNonStdRent;
		protected System.Web.UI.WebControls.TextBox txtMerchantSales;
		protected System.Web.UI.WebControls.TextBox txtDCRTotal;
		protected System.Web.UI.WebControls.TextBox txtChargeRent;
		protected System.Web.UI.WebControls.TextBox txtChargeLate;
		protected System.Web.UI.WebControls.TextBox txtChargeLien;
		protected System.Web.UI.WebControls.TextBox txtChargeAdmin;
		protected System.Web.UI.WebControls.TextBox txtChargeBDebt;
		protected System.Web.UI.WebControls.TextBox txtChargeMisc;
		protected System.Web.UI.WebControls.TextBox txtUseTax;
		protected System.Web.UI.WebControls.TextBox txtEccon;
		protected System.Web.UI.WebControls.TextBox txtPercent;

		//========================================================
		//Global variables
		//========================================================
		private BizFinance _finance;


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
			get { return _finance; }
			set { _finance = (BizFinance)value; }
		}

		#endregion
		

		
		//========================================================
		//Public methods
		//========================================================

		/// --------------------------------------------------------
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Finance";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Finance";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selFacilityID.SelectedIndex = 0;
			txtTrafficID.Text = "";
			txtDate.Text = "";
			txtLookup-Fac.Text = "";
			txtCash.Text = "";
			txtChecks.Text = "";
			txtCCards.Text = "";
			txtMiscCredit.Text = "";
			txtNonStdRent.Text = "";
			txtMerchantSales.Text = "";
			txtDCRTotal.Text = "";
			txtChargeRent.Text = "";
			txtChargeLate.Text = "";
			txtChargeLien.Text = "";
			txtChargeAdmin.Text = "";
			txtChargeBDebt.Text = "";
			txtChargeMisc.Text = "";
			txtUseTax.Text = "";
			txtEccon.Text = "";
			txtPercent.Text = "";
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
				if ((_finance != null) && (_finance.HasState()))
				{
					if (selFacilityID.SelectedIndex < 1) _finance.FacilityIDIsNull = true; else _finance._facilityID = Convert.ToInt32(selFacilityID.SelectedValue);
					if (txtTrafficID.Text.Length == 0) _finance.TrafficIDIsNull = true; else _finance._trafficID = DesignedNet.Framework.Web.Common.GetInteger(txtTrafficID);
					_finance._date = txtDate.Text;
					if (txtLookup-Fac.Text.Length == 0) _finance.Lookup-FacIsNull = true; else _finance._lookup-Fac = DesignedNet.Framework.Web.Common.GetInteger(txtLookup-Fac);
					if (txtCash.Text.Length == 0) _finance.CashIsNull = true; else _finance._cash = DesignedNet.Framework.Web.Common.GetDecimal(txtCash);
					if (txtChecks.Text.Length == 0) _finance.ChecksIsNull = true; else _finance._checks = DesignedNet.Framework.Web.Common.GetDecimal(txtChecks);
					if (txtCCards.Text.Length == 0) _finance.CCardsIsNull = true; else _finance._cCards = DesignedNet.Framework.Web.Common.GetDecimal(txtCCards);
					if (txtMiscCredit.Text.Length == 0) _finance.MiscCreditIsNull = true; else _finance._miscCredit = DesignedNet.Framework.Web.Common.GetDecimal(txtMiscCredit);
					if (txtNonStdRent.Text.Length == 0) _finance.NonStdRentIsNull = true; else _finance._nonStdRent = DesignedNet.Framework.Web.Common.GetDecimal(txtNonStdRent);
					if (txtMerchantSales.Text.Length == 0) _finance.MerchantSalesIsNull = true; else _finance._merchantSales = DesignedNet.Framework.Web.Common.GetDecimal(txtMerchantSales);
					if (txtDCRTotal.Text.Length == 0) _finance.DCRTotalIsNull = true; else _finance._dCRTotal = DesignedNet.Framework.Web.Common.GetDecimal(txtDCRTotal);
					if (txtChargeRent.Text.Length == 0) _finance.ChargeRentIsNull = true; else _finance._chargeRent = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeRent);
					if (txtChargeLate.Text.Length == 0) _finance.ChargeLateIsNull = true; else _finance._chargeLate = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeLate);
					if (txtChargeLien.Text.Length == 0) _finance.ChargeLienIsNull = true; else _finance._chargeLien = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeLien);
					if (txtChargeAdmin.Text.Length == 0) _finance.ChargeAdminIsNull = true; else _finance._chargeAdmin = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeAdmin);
					if (txtChargeBDebt.Text.Length == 0) _finance.ChargeBDebtIsNull = true; else _finance._chargeBDebt = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeBDebt);
					if (txtChargeMisc.Text.Length == 0) _finance.ChargeMiscIsNull = true; else _finance._chargeMisc = DesignedNet.Framework.Web.Common.GetDecimal(txtChargeMisc);
					if (txtUseTax.Text.Length == 0) _finance.UseTaxIsNull = true; else _finance._useTax = DesignedNet.Framework.Web.Common.GetDecimal(txtUseTax);
					if (txtEccon.Text.Length == 0) _finance.EcconIsNull = true; else _finance._eccon = DesignedNet.Framework.Web.Common.GetInteger(txtEccon);
					if (txtPercent.Text.Length == 0) _finance.PercentIsNull = true; else _finance._percent = DesignedNet.Framework.Web.Common.GetInteger(txtPercent);
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
			if ((_finance != null) && (_finance.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selFacilityID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selFacilityID.Items, _finance._facilityID);
				txtTrafficID.Text = _finance.TrafficID.ToString();
				txtDate.Text = _finance.Date.ToString();
				txtLookup-Fac.Text = _finance.Lookup-Fac.ToString();
				txtCash.Text = _finance.Cash.ToString();
				txtChecks.Text = _finance.Checks.ToString();
				txtCCards.Text = _finance.CCards.ToString();
				txtMiscCredit.Text = _finance.MiscCredit.ToString();
				txtNonStdRent.Text = _finance.NonStdRent.ToString();
				txtMerchantSales.Text = _finance.MerchantSales.ToString();
				txtDCRTotal.Text = _finance.DCRTotal.ToString();
				txtChargeRent.Text = _finance.ChargeRent.ToString();
				txtChargeLate.Text = _finance.ChargeLate.ToString();
				txtChargeLien.Text = _finance.ChargeLien.ToString();
				txtChargeAdmin.Text = _finance.ChargeAdmin.ToString();
				txtChargeBDebt.Text = _finance.ChargeBDebt.ToString();
				txtChargeMisc.Text = _finance.ChargeMisc.ToString();
				txtUseTax.Text = _finance.UseTax.ToString();
				txtEccon.Text = _finance.Eccon.ToString();
				txtPercent.Text = _finance.Percent.ToString();
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

