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

	/// <summary>User control interface class to display Facility entities</summary>
	/// ================================================================================
	/// Object:	    Storage.Framework.Web.Controls.FacilityView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class FacilityView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
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
		public void Cancel()
		{
			// reset values
			lblView.Text = "";
			lblTitle.Text = "View Facility";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_facility != null) && (_facility.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>FacilityID:</b> " + _facility.FacilityID.ToString() + "<br>";
				lblView.Text += "<b>FacilityName:</b> " + _facility.FacilityName.ToString() + "<br>";
				lblView.Text += "<b>Address:</b> " + _facility.Address.ToString() + "<br>";
				lblView.Text += "<b>City:</b> " + _facility.City.ToString() + "<br>";
				lblView.Text += "<b>State:</b> " + _facility.State.ToString() + "<br>";
				lblView.Text += "<b>Zip:</b> " + _facility.Zip.ToString() + "<br>";
				lblView.Text += "<b>Phone:</b> " + _facility.Phone.ToString() + "<br>";
				lblView.Text += "<b>Fax:</b> " + _facility.Fax.ToString() + "<br>";
				lblView.Text += "<b>EmailAdd:</b> " + _facility.EmailAdd.ToString() + "<br>";
				lblView.Text += "<b>TotlSqFoot:</b> " + _facility.TotlSqFoot.ToString() + "<br>";
				lblView.Text += "<b>UserName:</b> " + _facility.UserName.ToString() + "<br>";
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

