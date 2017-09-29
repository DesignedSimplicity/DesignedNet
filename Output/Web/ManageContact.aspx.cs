/********************************************************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using DesignedNet.Framework.Web;
using Harkins.Biz;
using Harkins.Web;

namespace Harkins.Web
{
	/// <summary>User interface class for managment of Contact entities</summary>
	/// ================================================================================
	/// Object:	    Harkins.Web.ManageContact
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	08.12.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class ManageContact : System.Web.UI.Page, DesignedNet.Framework.Web.IWebPage
	{
		//========================================================
		//User controls and variables
		//========================================================
		protected Harkins.Web.Controls.PageNavigation navigation;
		protected Harkins.Web.Controls.PageHeader header;
		protected Harkins.Web.Controls.PageFooter footer;
		protected Harkins.Web.Controls.ContactView view;
		protected Harkins.Web.Controls.ContactEdit edit;
		protected Harkins.Web.Controls.ContactList list;
		protected int _selectedContactID;
		protected BizContact _contactList;
		protected BizContact _contact;
		protected bool _canDelete;
		protected bool _canEdit;


		//========================================================
		//Html and Web controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label lblMode;
		protected System.Web.UI.WebControls.TextBox txtSearch;
		protected System.Web.UI.WebControls.HyperLink urlAddNew;
		protected System.Web.UI.WebControls.HyperLink urlCancel;
		protected System.Web.UI.WebControls.LinkButton cmdDelete;
		protected System.Web.UI.WebControls.LinkButton cmdAccept;
		protected System.Web.UI.WebControls.LinkButton cmdUpdate;
		protected System.Web.UI.WebControls.LinkButton cmdCreate;
		protected System.Web.UI.WebControls.LinkButton cmdFilter;
		protected System.Web.UI.WebControls.LinkButton cmdSearch;
		protected System.Web.UI.WebControls.LinkButton cmdReset;
		protected System.Web.UI.WebControls.LinkButton cmdEdit;


		//========================================================
		//DesignedNet.Framework.Web.IWebPage Implementation
		//========================================================
		#region DesignedNet.Framework.Web.IWebPage Implementation
		
		/// --------------------------------------------------------
		public void DoSecurity()
		{
			_canDelete = true;
			_canEdit = true;
		}


		/// --------------------------------------------------------
		public void Render(Common.PageMode pageMode) { Render(pageMode, ""); }
		public void Render(Common.PageMode pageMode, string message)
		{
			// render common controls
			lblMsg.Text = message;
			list.DataBind();

			// configure complex controls
			switch (pageMode)
			{
				case Common.PageMode.List :
					// configure page mode
					lblMode.Text = "List";

					// disable controls
					edit.Visible = false;
					view.Visible = false;
					urlCancel.Visible = false;
					cmdCreate.Visible = false;
					cmdUpdate.Visible = false;
					cmdDelete.Visible = false;
					cmdAccept.Visible = false;
					cmdEdit.Visible = false;
					break;
					
				case Common.PageMode.New :
					// configure page mode
					lblMode.Text = "New";
					edit.New();

					urlCancel.NavigateUrl = "ManageContact.aspx";
					urlCancel.Visible = true;
					
					cmdCreate.Visible = true;

					// disable controls
					edit.Visible = true;
					view.Visible = false;
					cmdUpdate.Visible = false;
					cmdDelete.Visible = false;
					cmdAccept.Visible = false;
					cmdEdit.Visible = false;
					break;
	
				case Common.PageMode.View :
					// configure page mode
					lblMode.Text = "View";

					view.DataBind();
					view.Visible = true;

					urlCancel.NavigateUrl = "ManageContact.aspx";
					urlCancel.Visible = _canEdit;

					cmdEdit.Visible = _canEdit;

					// disable controls
					edit.Visible = false;
					cmdCreate.Visible = false;
					cmdUpdate.Visible = false;
					cmdDelete.Visible = false;
					cmdAccept.Visible = false;
					break;

				case Common.PageMode.Edit :
					// configure page mode
					lblMode.Text = "Edit";

					edit.Edit();
					edit.DataBind();
					edit.Visible = true;

					urlCancel.NavigateUrl = "ManageContact.aspx?ContactID=" + _selectedContactID.ToString();
					urlCancel.Visible = true;

					cmdUpdate.Visible = true;
					cmdDelete.Visible = _canDelete;

					// disable controls
					view.Visible = false;
					cmdCreate.Visible = false;
					cmdAccept.Visible = false;
					cmdEdit.Visible = false;
					break;

				case Common.PageMode.Delete :
					// configure page mode
					lblMode.Text = "Delete";

					view.DataBind();
					view.Visible = true;
					view.Title = "Delete Contact";

					urlCancel.NavigateUrl = "ManageContact.aspx?ContactID=" + _selectedContactID.ToString();
					urlCancel.Visible = _canDelete;
					cmdAccept.Visible = _canDelete;

					// disable controls
					edit.Visible = false;
					cmdCreate.Visible = false;
					cmdUpdate.Visible = false;
					cmdDelete.Visible = false;
					cmdEdit.Visible = false;
					break;
					
				default :
				case Common.PageMode.Error :
					lblMode.Text = pageMode.ToString();
					view.Visible = false;
					edit.Visible = false;
					urlCancel.Visible = false;

					cmdCreate.Visible = false;
					cmdUpdate.Visible = false;
					cmdDelete.Visible = false;
					cmdAccept.Visible = false;
					cmdEdit.Visible = false;
					break;
			}
		}
		
		#endregion


		//========================================================
		//Page event handlers
		//========================================================

		/// --------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			// do site security
			DoSecurity();

			// get id from querystring
			_selectedContactID = DesignedNet.Framework.Web.Common.GetID(Request.QueryString, "ContactID");
			if (_selectedContactID < 1) _selectedContactID = DesignedNet.Framework.Web.Common.GetID(ViewState, "ContactID");

			// populate list control
			_contactList = new BizContact();
			_contactList.List();
			list.DataSource = _contactList;

			// decide page mode
			_contact = new BizContact();
			_contact.Table = _contactList.Table;
			if (_selectedContactID > 0)
			{
				// load selected
				if (_contact.Find(_selectedContactID))
				{
					edit.DataSource = _contact;
					view.DataSource = _contact;
					if (!Page.IsPostBack) Render(Common.PageMode.View);
				}
				else // user not found
					Render(Common.PageMode.Error, "The item selected was not found in the database!");
			}
			else
			{
				if (!Page.IsPostBack) Render(Common.PageMode.New);
			}
		}

		/// --------------------------------------------------------
		public void cmdEdit_Click(object sender, System.EventArgs e)
		{
			Render(Common.PageMode.Edit);
		}

		/// --------------------------------------------------------
		public void cmdCreate_Click(object sender, System.EventArgs e)
		{
			// validate user control
			_contact.New();
			edit.DataSource = _contact;
			string msg = edit.Validate();
			if (msg.Length == 0) // update valid object
			{
				_contact.Save();
				ViewState["ContactID"] = _contact.ContactID;
				Render(Common.PageMode.Edit, "Created Contact #" + _contact._contactID.ToString() + " @ " + DateTime.Now);
			}
			else // show error message
				lblMsg.Text = msg;
		}

		/// --------------------------------------------------------
		public void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			// validate user control
			edit.DataSource = _contact;
			string msg = edit.Validate();
			if (msg.Length == 0) // update valid object
			{
				_contact.Save(); // save
				Render(Common.PageMode.Edit, "Updated Contact #" + _contact._contactID.ToString() + " @ " + DateTime.Now);
			}
			else // show error message
				lblMsg.Text = msg;
		}

		/// --------------------------------------------------------
		public void cmdSearch_Click(object sender, System.EventArgs e)
		{
			if (txtSearch.Text.Length > 0)
			{
				_contactList.Filter("Contact", txtSearch.Text);
				Render(Common.PageMode.List, "Search results for: " + txtSearch.Text);
			}
			else
				Render(Common.PageMode.List);
		}

		/// --------------------------------------------------------
		public void cmdDelete_Click(object sender, System.EventArgs e)
		{
			// display confirmation message
			Render(Common.PageMode.Delete, "Are you sure you want to delete the selected item?");
		}

		/// --------------------------------------------------------
		public void cmdAccept_Click(object sender, System.EventArgs e)
		{
			// process delete
			if (_contact.Delete() && _contact.Save())
				Response.Redirect("ManageContact.aspx");
			else // display error message
				Render(Common.PageMode.Error, "Error deleting the selected item, item was not found!");
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
		
		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// 
		private void InitializeComponent()
		{    
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
			this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}

