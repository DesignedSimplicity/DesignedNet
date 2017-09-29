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

	/// <summary>User control interface class to display Comment entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.Controls.CommentView
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class CommentView : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
		//========================================================
		private BizComment _comment;


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
			get { return _comment; }
			set { _comment = (BizComment)value; }
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
			lblTitle.Text = "View Comment";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_comment != null) && (_comment.HasState()))
			{
				lblView.Text = "";
				
				lblView.Text += "<b>CommentID:</b> " + _comment.CommentID.ToString() + "<br>";
				lblView.Text += "<b>CommentTypeID:</b> " + _comment.CommentTypeID.ToString() + "<br>";
				lblView.Text += "<b>ProjectID:</b> " + _comment.ProjectID.ToString() + "<br>";
				lblView.Text += "<b>CompanyID:</b> " + _comment.CompanyID.ToString() + "<br>";
				lblView.Text += "<b>ContactID:</b> " + _comment.ContactID.ToString() + "<br>";
				lblView.Text += "<b>CreatedByID:</b> " + _comment.CreatedByID.ToString() + "<br>";
				lblView.Text += "<b>AssignedToID:</b> " + _comment.AssignedToID.ToString() + "<br>";
				lblView.Text += "<b>Priority:</b> " + _comment.Priority.ToString() + "<br>";
				lblView.Text += "<b>Thread:</b> " + _comment.Thread.ToString() + "<br>";
				lblView.Text += "<b>Subject:</b> " + _comment.Subject.ToString() + "<br>";
				lblView.Text += "<b>Comment:</b> " + _comment.Comment.ToString() + "<br>";
				lblView.Text += "<b>Created:</b> " + _comment.Created.ToString() + "<br>";
				lblView.Text += "<b>Updated:</b> " + _comment.Updated.ToString() + "<br>";
				lblView.Text += "<b>Reminder:</b> " + _comment.Reminder.ToString() + "<br>";
				lblView.Text += "<b>Completed:</b> " + _comment.Completed.ToString() + "<br>";
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

