<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="RootNamespace">DesignedNet.Framework</xsl:param>
<xsl:param name="Today">01/01/04</xsl:param>
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

	/// &lt;summary&gt;User control interface class to edit <xsl:value-of select="@objName"/> entities&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Web.<xsl:value-of select="@objName"/>Edit
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	<xsl:value-of select="$Today"/>
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public abstract class <xsl:value-of select="@objName"/>Edit : System.Web.UI.UserControl, DesignedNet.Framework.Web.IWebEdit
	{
		//========================================================
		//Web/User controls
		//========================================================
		protected System.Web.UI.WebControls.Label lblTitle;<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']">
		<xsl:variable name="type"><xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template></xsl:variable>
		<xsl:choose>
			<xsl:when test="@fk = '1'">
		protected System.Web.UI.WebControls.DropDownList sel<xsl:value-of select="@objName"/>;</xsl:when>
			<xsl:otherwise>
		protected System.Web.UI.WebControls.TextBox txt<xsl:value-of select="@objName"/>;</xsl:otherwise>
		</xsl:choose></xsl:for-each>

		//========================================================
		//Global variables
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
		public void New()
		{
			// show form title
			lblTitle.Text = "Create <xsl:value-of select="@objName"/>";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Edit()
		{
			// show form title
			lblTitle.Text = "Update <xsl:value-of select="@objName"/>";
			
			// reset form
			Cancel();
		}

		/// --------------------------------------------------------
		public void Cancel()
		{			
			// reset control values<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']">
			<xsl:choose>
				<xsl:when test="@fk = '1'">
			sel<xsl:value-of select="@objName"/>.SelectedIndex = 0;</xsl:when>
				<xsl:otherwise>
			txt<xsl:value-of select="@objName"/>.Text = "";</xsl:otherwise>
			</xsl:choose></xsl:for-each>
		}

		/// --------------------------------------------------------
		public void LoadRefData()
		{
			<xsl:for-each select="Property[@fk='1']">
			Biz<xsl:value-of select="@fkObjName"/><xsl:text> </xsl:text><xsl:value-of select="@fkVarName"/> = new Biz<xsl:value-of select="@fkObjName"/>();
			<xsl:value-of select="@fkVarName"/>.List();
			sel<xsl:value-of select="@objName"/>.DataValueField = "<xsl:value-of select="@objName"/>";
			sel<xsl:value-of select="@objName"/>.DataTextField = "<xsl:value-of select="@objName"/>";
			sel<xsl:value-of select="@objName"/>.DataSource = <xsl:value-of select="@fkVarName"/>;
			sel<xsl:value-of select="@objName"/>.DataBind();
			DesignedNet.Framework.Web.Common.CreateSelectOneItem(sel<xsl:value-of select="@objName"/>.Items);
			<xsl:text> </xsl:text>
			</xsl:for-each>
		}

		/// --------------------------------------------------------
		public string Validate()
		{
			string msg = "";

			// validate form controls<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']"><xsl:if test="@isNullable = 0">
				<xsl:variable name="type"><xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template></xsl:variable>
				<xsl:choose>
					<xsl:when test="@fk = '1'">
				if (sel<xsl:value-of select="@objName"/>.SelectedIndex &lt; 1) msg += "Please select the <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
					<xsl:otherwise>
						<xsl:choose>
							<xsl:when test="(@isNullable = '0') and ($type = 'short' or $type = 'int' or $type = 'byte' or $type = 'Int64')">
				if (DesignedNet.Framework.Web.Common.RequiredInteger(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid integet into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:when test="(@isNullable = '1') and ($type = 'short' or $type = 'int' or $type = 'byte' or $type = 'Int64')">
				if (DesignedNet.Framework.Web.Common.OptionalInteger(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid integet into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:when test="(@isNullable = '0') and ($type = 'float' or $type = 'double' or $type = 'decimal')">
				if (DesignedNet.Framework.Web.Common.RequiredDecimal(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid decimal into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:when test="(@isNullable = '1') and ($type = 'float' or $type = 'double' or $type = 'decimal')">
				if (DesignedNet.Framework.Web.Common.OptionalDecimal(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid decimal into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:when test="(@isNullable = '0') and ($type = 'DateTime')">
				if (DesignedNet.Framework.Web.Common.RequiredDate(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid date/time into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:when test="(@isNullable = '1') and ($type = 'DateTime')">
				if (DesignedNet.Framework.Web.Common.OptionalDate(txt<xsl:value-of select="@objName"/>)) msg += "Please enter a valid date/time into <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:when>
							<xsl:otherwise>
				if (DesignedNet.Framework.Web.Common.RequiredText(txt<xsl:value-of select="@objName"/>)) msg += "Please enter the <xsl:value-of select="@objName"/> field...&lt;br&gt;";</xsl:otherwise>
						</xsl:choose>					
					</xsl:otherwise>
				</xsl:choose></xsl:if></xsl:for-each>

			// update business object if valid
			if (msg.Length == 0) 
			{
				// make sure entity has state
				if ((_<xsl:value-of select="@varName"/> != null) &amp;&amp; (_<xsl:value-of select="@varName"/>.HasState()))
				{<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']">
					<xsl:variable name="type"><xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template></xsl:variable>
					<xsl:choose>
						<xsl:when test="@isNullable = '0' and @fk = '1'">
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = Convert.ToInt32(sel<xsl:value-of select="@objName"/>.SelectedValue);</xsl:when>
						<xsl:when test="@isNullable = '1' and @fk = '1'">
					if (sel<xsl:value-of select="@objName"/>.SelectedIndex &lt; 1) _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>IsNull = true; else _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = Convert.ToInt32(sel<xsl:value-of select="@objName"/>.SelectedValue);</xsl:when>
						<xsl:when test="(@isNullable = '0') and ($type = 'short' or $type = 'int' or $type = 'byte' or $type = 'Int64')">
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetInteger(txt<xsl:value-of select="@objName"/>);</xsl:when>
						<xsl:when test="(@isNullable = '1') and ($type = 'short' or $type = 'int' or $type = 'byte' or $type = 'Int64')">
					if (txt<xsl:value-of select="@objName"/>.Text.Length == 0) _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>IsNull = true; else _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetInteger(txt<xsl:value-of select="@objName"/>);</xsl:when>

						<xsl:when test="(@isNullable = '0') and ($type = 'decimal')">
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDecimal(txt<xsl:value-of select="@objName"/>);</xsl:when>
						<xsl:when test="(@isNullable = '1') and ($type = 'decimal')">
					if (txt<xsl:value-of select="@objName"/>.Text.Length == 0) _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>IsNull = true; else _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDecimal(txt<xsl:value-of select="@objName"/>);</xsl:when>

						<xsl:when test="(@isNullable = '0') and ($type = 'float' or $type = 'double')">
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDouble(txt<xsl:value-of select="@objName"/>);</xsl:when>
						<xsl:when test="(@isNullable = '1') and ($type = 'float' or $type = 'double')">
					if (txt<xsl:value-of select="@objName"/>.Text.Length == 0) _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>IsNull = true; else _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDouble(txt<xsl:value-of select="@objName"/>);</xsl:when>

						<xsl:when test="(@isNullable = '0') and ($type = 'DateTime')">
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDateTime(txt<xsl:value-of select="@objName"/>);</xsl:when>
						<xsl:when test="(@isNullable = '1') and ($type = 'DateTime')">
					if (txt<xsl:value-of select="@objName"/>.Text.Length == 0) _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>IsNull = true; else _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = DesignedNet.Framework.Web.Common.GetDateTime(txt<xsl:value-of select="@objName"/>);</xsl:when>
						<xsl:otherwise>
					_<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/> = txt<xsl:value-of select="@objName"/>.Text;</xsl:otherwise>
					</xsl:choose></xsl:for-each>
				}
				else
					msg = "ERROR: Business object does not have state!&lt;br&gt;";
			}

			return msg;
		}

		/// --------------------------------------------------------
		public override void DataBind()
		{
			// populate user controls if entity has state
			if ((_<xsl:value-of select="@varName"/> != null) &amp;&amp; (_<xsl:value-of select="@varName"/>.HasState()))
			{<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']">
				<xsl:choose>
					<xsl:when test="@fk = '1'">
				DesignedNet.Framework.Web.Common.ClearSelection(sel<xsl:value-of select="@objName"/>);
				DesignedNet.Framework.Web.Common.SelectItemByValue(sel<xsl:value-of select="@objName"/>.Items, _<xsl:value-of select="../@varName"/>._<xsl:value-of select="@varName"/>);</xsl:when>
					<xsl:otherwise>
				txt<xsl:value-of select="@objName"/>.Text = _<xsl:value-of select="../@varName"/>.<xsl:value-of select="@objName"/>.ToString();</xsl:otherwise>
				</xsl:choose></xsl:for-each>
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