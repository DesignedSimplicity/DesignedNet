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

	/// <summary>User control interface class to display Finance entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.Controls.FinanceView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class FinanceView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
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
		public void Cancel()
		{
			// reset values
			lblView.Text = "";
			lblTitle.Text = "View Finance";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_finance != null) && (_finance.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>FinanceID:</b> " + _finance.FinanceID.ToString() + "<br>";
				lblView.Text += "<b>FacilityID:</b> " + _finance.FacilityID.ToString() + "<br>";
				lblView.Text += "<b>TrafficID:</b> " + _finance.TrafficID.ToString() + "<br>";
				lblView.Text += "<b>Date:</b> " + _finance.Date.ToString() + "<br>";
				lblView.Text += "<b>Lookup-Fac:</b> " + _finance.Lookup-Fac.ToString() + "<br>";
				lblView.Text += "<b>Cash:</b> " + _finance.Cash.ToString() + "<br>";
				lblView.Text += "<b>Checks:</b> " + _finance.Checks.ToString() + "<br>";
				lblView.Text += "<b>CCards:</b> " + _finance.CCards.ToString() + "<br>";
				lblView.Text += "<b>MiscCredit:</b> " + _finance.MiscCredit.ToString() + "<br>";
				lblView.Text += "<b>NonStdRent:</b> " + _finance.NonStdRent.ToString() + "<br>";
				lblView.Text += "<b>MerchantSales:</b> " + _finance.MerchantSales.ToString() + "<br>";
				lblView.Text += "<b>DCRTotal:</b> " + _finance.DCRTotal.ToString() + "<br>";
				lblView.Text += "<b>ChargeRent:</b> " + _finance.ChargeRent.ToString() + "<br>";
				lblView.Text += "<b>ChargeLate:</b> " + _finance.ChargeLate.ToString() + "<br>";
				lblView.Text += "<b>ChargeLien:</b> " + _finance.ChargeLien.ToString() + "<br>";
				lblView.Text += "<b>ChargeAdmin:</b> " + _finance.ChargeAdmin.ToString() + "<br>";
				lblView.Text += "<b>ChargeBDebt:</b> " + _finance.ChargeBDebt.ToString() + "<br>";
				lblView.Text += "<b>ChargeMisc:</b> " + _finance.ChargeMisc.ToString() + "<br>";
				lblView.Text += "<b>UseTax:</b> " + _finance.UseTax.ToString() + "<br>";
				lblView.Text += "<b>Eccon:</b> " + _finance.Eccon.ToString() + "<br>";
				lblView.Text += "<b>Percent:</b> " + _finance.Percent.ToString() + "<br>";
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

