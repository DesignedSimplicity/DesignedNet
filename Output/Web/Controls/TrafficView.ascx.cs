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

	/// <summary>User control interface class to display Traffic entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.Controls.TrafficView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class TrafficView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
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
		public void Cancel()
		{
			// reset values
			lblView.Text = "";
			lblTitle.Text = "View Traffic";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_traffic != null) && (_traffic.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>TrafficID:</b> " + _traffic.TrafficID.ToString() + "<br>";
				lblView.Text += "<b>FacilityID:</b> " + _traffic.FacilityID.ToString() + "<br>";
				lblView.Text += "<b>Date:</b> " + _traffic.Date.ToString() + "<br>";
				lblView.Text += "<b>NewCallFromWeb:</b> " + _traffic.NewCallFromWeb.ToString() + "<br>";
				lblView.Text += "<b>NewCallFromYellow:</b> " + _traffic.NewCallFromYellow.ToString() + "<br>";
				lblView.Text += "<b>NewCallFromOther:</b> " + _traffic.NewCallFromOther.ToString() + "<br>";
				lblView.Text += "<b>TotalCalls:</b> " + _traffic.TotalCalls.ToString() + "<br>";
				lblView.Text += "<b>WalkinWeb:</b> " + _traffic.WalkinWeb.ToString() + "<br>";
				lblView.Text += "<b>WalkinYellow:</b> " + _traffic.WalkinYellow.ToString() + "<br>";
				lblView.Text += "<b>WalkinOther:</b> " + _traffic.WalkinOther.ToString() + "<br>";
				lblView.Text += "<b>WalkinTotal:</b> " + _traffic.WalkinTotal.ToString() + "<br>";
				lblView.Text += "<b>Rented:</b> " + _traffic.Rented.ToString() + "<br>";
				lblView.Text += "<b>Movin:</b> " + _traffic.Movin.ToString() + "<br>";
				lblView.Text += "<b>MoveOut:</b> " + _traffic.MoveOut.ToString() + "<br>";
				lblView.Text += "<b>Transfer:</b> " + _traffic.Transfer.ToString() + "<br>";
				lblView.Text += "<b>Vacated:</b> " + _traffic.Vacated.ToString() + "<br>";
				lblView.Text += "<b>Comments:</b> " + _traffic.Comments.ToString() + "<br>";
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

