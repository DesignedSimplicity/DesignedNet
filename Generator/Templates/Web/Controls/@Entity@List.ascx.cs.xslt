<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">11/12/2002</xsl:param>
<xsl:output method="text"/>

<!-- Type Transformations -->
<xsl:include href="../../CommonTransformations.xslt"/>

<xsl:template match="Entity">/********************************************************************************/
namespace <xsl:value-of select="$RootNamespace"/>.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using <xsl:value-of select="$RootNamespace"/>.Biz;

	/// &lt;summary&gt;User control interface class to list <xsl:value-of select="@objName"/> entities&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>List
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class <xsl:value-of select="@objName"/>List : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebList
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.DataList list;


		//========================================================
		//Private variables
		//========================================================
		protected string _navigateUrl = "Manage<xsl:value-of select="@objName"/>.aspx?<xsl:value-of select="Property[@pk='1']/@objName"/>=";


		//========================================================
		//Property get/set methods
		//========================================================
		#region Property get/set methods

		/// --------------------------------------------------------
		public object DataSource
		{
			get { return list.DataSource; }
			set { list.DataSource = value; }
		}

		/// --------------------------------------------------------
		public string NavigateUrl
		{
			get { return _navigateUrl; }
			set { _navigateUrl = value; }
		}

		#endregion


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
		
		/// &lt;summary&gt;
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// &lt;/summary&gt;
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

	}
}

</xsl:template>
</xsl:stylesheet>