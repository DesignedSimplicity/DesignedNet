<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">02/07/04</xsl:param>
<xsl:output method="text"/>

<!-- Type Transformations -->
<xsl:include href="../CommonTransformations.xslt"/>

<xsl:template match="Entity">/********************************************************************************/
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
using <xsl:value-of select="$RootNamespace"/>.Biz;
using <xsl:value-of select="$RootNamespace"/>.Web;

namespace <xsl:value-of select="$RootNamespace"/>.Web
{
	/// &lt;summary&gt;User interface class for managment of <xsl:value-of select="@objName"/> entities&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Web.Manage<xsl:value-of select="@objName"/>
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	08.12.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class Manage<xsl:value-of select="@objName"/> : System.Web.UI.Page, DesignedNet.Framework.Web.IWebPage
	{
		//========================================================
		//User controls and variables
		//========================================================
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.PageNavigation navigation;
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.PageHeader header;
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.PageFooter footer;
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>View view;
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>Edit edit;
		protected <xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>List list;
		protected int _selected<xsl:value-of select="Property[@pk='1']/@objName"/>;
		protected Biz<xsl:value-of select="@objName"/><xsl:text> </xsl:text>_<xsl:value-of select="@varName"/>List;
		protected Biz<xsl:value-of select="@objName"/><xsl:text> </xsl:text>_<xsl:value-of select="@varName"/>;
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

					urlCancel.NavigateUrl = "Manage<xsl:value-of select="@objName"/>.aspx";
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

					urlCancel.NavigateUrl = "Manage<xsl:value-of select="@objName"/>.aspx";
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

					urlCancel.NavigateUrl = "Manage<xsl:value-of select="@objName"/>.aspx?<xsl:value-of select="Property[@pk='1']/@objName"/>=" + _selected<xsl:value-of select="Property[@pk='1']/@objName"/>.ToString();
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
					view.Title = "Delete <xsl:value-of select="@objName"/>";

					urlCancel.NavigateUrl = "Manage<xsl:value-of select="@objName"/>.aspx?<xsl:value-of select="Property[@pk='1']/@objName"/>=" + _selected<xsl:value-of select="Property[@pk='1']/@objName"/>.ToString();
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
			_selected<xsl:value-of select="Property[@pk='1']/@objName"/> = DesignedNet.Framework.Web.Common.GetID(Request.QueryString, "<xsl:value-of select="Property[@pk='1']/@objName"/>");
			if (_selected<xsl:value-of select="Property[@pk='1']/@objName"/> &lt; 1) _selected<xsl:value-of select="Property[@pk='1']/@objName"/> = DesignedNet.Framework.Web.Common.GetID(ViewState, "<xsl:value-of select="Property[@pk='1']/@objName"/>");

			// populate list control
			_<xsl:value-of select="@varName"/>List = new Biz<xsl:value-of select="@objName"/>();
			_<xsl:value-of select="@varName"/>List.List();
			list.DataSource = _<xsl:value-of select="@varName"/>List;

			// decide page mode
			_<xsl:value-of select="@varName"/> = new Biz<xsl:value-of select="@objName"/>();
			_<xsl:value-of select="@varName"/>.Table = _<xsl:value-of select="@varName"/>List.Table;
			if (_selected<xsl:value-of select="Property[@pk='1']/@objName"/> &gt; 0)
			{
				// load selected
				if (_<xsl:value-of select="@varName"/>.Find(_selected<xsl:value-of select="Property[@pk='1']/@objName"/>))
				{
					edit.DataSource = _<xsl:value-of select="@varName"/>;
					view.DataSource = _<xsl:value-of select="@varName"/>;
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
			_<xsl:value-of select="@varName"/>.New();
			edit.DataSource = _<xsl:value-of select="@varName"/>;
			string msg = edit.Validate();
			if (msg.Length == 0) // update valid object
			{
				_<xsl:value-of select="@varName"/>.Save();
				ViewState["<xsl:value-of select="Property[@pk='1']/@objName"/>"] = _<xsl:value-of select="@varName"/>.<xsl:value-of select="Property[@pk='1']/@objName"/>;
				Render(Common.PageMode.Edit, "Created <xsl:value-of select="@objName"/> #" + _<xsl:value-of select="@varName"/>._<xsl:value-of select="Property[@pk='1']/@varName"/>.ToString() + " @ " + DateTime.Now);
			}
			else // show error message
				lblMsg.Text = msg;
		}

		/// --------------------------------------------------------
		public void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			// validate user control
			edit.DataSource = _<xsl:value-of select="@varName"/>;
			string msg = edit.Validate();
			if (msg.Length == 0) // update valid object
			{
				_<xsl:value-of select="@varName"/>.Save(); // save
				Render(Common.PageMode.Edit, "Updated <xsl:value-of select="@objName"/> #" + _<xsl:value-of select="@varName"/>._<xsl:value-of select="Property[@pk='1']/@varName"/>.ToString() + " @ " + DateTime.Now);
			}
			else // show error message
				lblMsg.Text = msg;
		}

		/// --------------------------------------------------------
		public void cmdSearch_Click(object sender, System.EventArgs e)
		{
			if (txtSearch.Text.Length > 0)
			{
				_<xsl:value-of select="@varName"/>List.Filter("<xsl:value-of select="@objName"/>", txtSearch.Text);
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
			if (_<xsl:value-of select="@varName"/>.Delete() &amp;&amp; _<xsl:value-of select="@varName"/>.Save())
				Response.Redirect("Manage<xsl:value-of select="@objName"/>.aspx");
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
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

</xsl:template>
</xsl:stylesheet>