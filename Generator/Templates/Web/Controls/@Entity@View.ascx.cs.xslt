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

	/// &lt;summary&gt;User control interface class to display <xsl:value-of select="@objName"/> entities&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>View
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	04.09.03
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class <xsl:value-of select="@objName"/>View : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebView
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblView;
		protected System.Web.UI.WebControls.Label lblTitle;


		//========================================================
		//Private variables
		//========================================================
		private Biz<xsl:value-of select="@objName"/><xsl:text> </xsl:text>_<xsl:value-of select="@varName"/>;


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
			get { return _<xsl:value-of select="@varName"/>; }
			set { _<xsl:value-of select="@varName"/> = (Biz<xsl:value-of select="@objName"/>)value; }
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
			lblTitle.Text = "View <xsl:value-of select="@objName"/>";
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_<xsl:value-of select="@varName"/> != null) &amp;&amp; (_<xsl:value-of select="@varName"/>.HasState()))
			{
				lblView.Text = "";
				<xsl:for-each select="Property">
				lblView.Text += "&lt;b&gt;<xsl:value-of select="@objName"/>:&lt;/b&gt; " + _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>.ToString() + "&lt;br&gt;";</xsl:for-each>
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