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

	/// <summary>User control interface class to edit Comment entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.CommentEdit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/13/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class CommentEdit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList selCommentTypeID;
		protected System.Web.UI.WebControls.DropDownList selProjectID;
		protected System.Web.UI.WebControls.DropDownList selCompanyID;
		protected System.Web.UI.WebControls.DropDownList selContactID;
		protected System.Web.UI.WebControls.TextBox txtCreatedByID;
		protected System.Web.UI.WebControls.TextBox txtAssignedToID;
		protected System.Web.UI.WebControls.TextBox txtPriority;
		protected System.Web.UI.WebControls.TextBox txtThread;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.TextBox txtComment;
		protected System.Web.UI.WebControls.TextBox txtReminder;
		protected System.Web.UI.WebControls.TextBox txtCompleted;

		//========================================================
		//Global variables
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
		public void New()
		{
			// show form title
			lblTitle.Text = "Create Comment";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update Comment";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values
			selCommentTypeID.SelectedIndex = 0;
			selProjectID.SelectedIndex = 0;
			selCompanyID.SelectedIndex = 0;
			selContactID.SelectedIndex = 0;
			txtCreatedByID.Text = "";
			txtAssignedToID.Text = "";
			txtPriority.Text = "";
			txtThread.Text = "";
			txtSubject.Text = "";
			txtComment.Text = "";
			txtReminder.Text = "";
			txtCompleted.Text = "";
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			
			BizCommentType commentType = new BizCommentType();
			commentType.List();
			selCommentTypeID.DataValueField = "CommentTypeID";
			selCommentTypeID.DataTextField = "CommentTypeID";
			selCommentTypeID.DataSource = commentType;
			selCommentTypeID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selCommentTypeID.Items);
			 
			BizProject project = new BizProject();
			project.List();
			selProjectID.DataValueField = "ProjectID";
			selProjectID.DataTextField = "ProjectID";
			selProjectID.DataSource = project;
			selProjectID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selProjectID.Items);
			 
			BizCompany company = new BizCompany();
			company.List();
			selCompanyID.DataValueField = "CompanyID";
			selCompanyID.DataTextField = "CompanyID";
			selCompanyID.DataSource = company;
			selCompanyID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selCompanyID.Items);
			 
			BizContact contact = new BizContact();
			contact.List();
			selContactID.DataValueField = "ContactID";
			selContactID.DataTextField = "ContactID";
			selContactID.DataSource = contact;
			selContactID.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(selContactID.Items);
			 
		}

		/// --------------------------------------------------------
		public string Validate()
		{
			string msg = "";

			// validate form controls
				if (selCommentTypeID.SelectedIndex < 1) msg += "Please select the CommentTypeID field...<br>";
				if (DesignedNet.Framework.Web.Common.RequiredText(txtSubject)) msg += "Please enter the Subject field...<br>";
				if (DesignedNet.Framework.Web.Common.RequiredText(txtComment)) msg += "Please enter the Comment field...<br>";

			// update business object if valid
			if (msg.Length == 0) 
			{
				// make sure entity has state
				if ((_comment != null) && (_comment.HasState()))
				{
					_comment._commentTypeID = Convert.ToInt32(selCommentTypeID.SelectedValue);
					if (selProjectID.SelectedIndex < 1) _comment.ProjectIDIsNull = true; else _comment._projectID = Convert.ToInt32(selProjectID.SelectedValue);
					if (selCompanyID.SelectedIndex < 1) _comment.CompanyIDIsNull = true; else _comment._companyID = Convert.ToInt32(selCompanyID.SelectedValue);
					if (selContactID.SelectedIndex < 1) _comment.ContactIDIsNull = true; else _comment._contactID = Convert.ToInt32(selContactID.SelectedValue);
					if (txtCreatedByID.Text.Length == 0) _comment.CreatedByIDIsNull = true; else _comment._createdByID = DesignedNet.Framework.Web.Common.GetInteger(txtCreatedByID);
					if (txtAssignedToID.Text.Length == 0) _comment.AssignedToIDIsNull = true; else _comment._assignedToID = DesignedNet.Framework.Web.Common.GetInteger(txtAssignedToID);
					if (txtPriority.Text.Length == 0) _comment.PriorityIsNull = true; else _comment._priority = DesignedNet.Framework.Web.Common.GetInteger(txtPriority);
					_comment._thread = txtThread.Text;
					_comment._subject = txtSubject.Text;
					_comment._comment = txtComment.Text;
					if (txtReminder.Text.Length == 0) _comment.ReminderIsNull = true; else _comment._reminder = DesignedNet.Framework.Web.Common.GetDateTime(txtReminder);
					if (txtCompleted.Text.Length == 0) _comment.CompletedIsNull = true; else _comment._completed = DesignedNet.Framework.Web.Common.GetDateTime(txtCompleted);
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
			if ((_comment != null) && (_comment.HasState()))
			{
				DesignedNet.Framework.Web.Common.ClearSelection(selCommentTypeID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selCommentTypeID.Items, _comment._commentTypeID);
				DesignedNet.Framework.Web.Common.ClearSelection(selProjectID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selProjectID.Items, _comment._projectID);
				DesignedNet.Framework.Web.Common.ClearSelection(selCompanyID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selCompanyID.Items, _comment._companyID);
				DesignedNet.Framework.Web.Common.ClearSelection(selContactID);
				DesignedNet.Framework.Web.Common.SelectItemByValue(selContactID.Items, _comment._contactID);
				txtCreatedByID.Text = _comment.CreatedByID.ToString();
				txtAssignedToID.Text = _comment.AssignedToID.ToString();
				txtPriority.Text = _comment.Priority.ToString();
				txtThread.Text = _comment.Thread.ToString();
				txtSubject.Text = _comment.Subject.ToString();
				txtComment.Text = _comment.Comment.ToString();
				txtReminder.Text = _comment.Reminder.ToString();
				txtCompleted.Text = _comment.Completed.ToString();
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

