<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://asp.net" xmlns:Controls="http://designed.com" xmlns:Web="http://designed.com" version="1.0">
<xsl:output omit-xml-declaration="yes" method="html"/>

<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">11/12/2002</xsl:param>

<!-- Type Transformations -->
<xsl:include href="../CommonTransformations.xslt"/>

<xsl:template match="Entity">&#060;&#037;&#064; Page language="c#" Codebehind="Manage<xsl:value-of select="@objName"/>.aspx.cs" AutoEventWireup="false" Inherits="<xsl:value-of select="$RootNamespace"/>.Web.Manage<xsl:value-of select="@objName"/>" &#037;&gt;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="View" Src="Controls/<xsl:value-of select="@objName"/>View.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="Edit" Src="Controls/<xsl:value-of select="@objName"/>Edit.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="List" Src="Controls/<xsl:value-of select="@objName"/>List.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="PageFooter" Src="Controls/PageFooter.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="PageHeader" Src="Controls/PageHeader.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Controls" TagName="PageNavigation" Src="Controls/PageNavigation.ascx" &#037;&#062;
&#060;&#037;&#064; Register TagPrefix="Web" Namespace="DesignedNet.Framework.Web" Assembly="DesignedNet.Framework" &#037;&#062;

<html>
  <head>
    <title><xsl:value-of select="@objName"></xsl:value-of> Managment Page</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
    <meta name="CODE_LANGUAGE" Content="C#"/>
    <meta name="vs_defaultClientScript" content="JavaScript"/>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
	<link href="designednet.css" type="text/css" rel="stylesheet"/>
  </head>
  <body>
    <form>
		<xsl:attribute name="id">HtmlForm</xsl:attribute>
		<xsl:attribute name="method">post</xsl:attribute>
		<xsl:attribute name="runat">server</xsl:attribute>	
		<Controls:PageHeader id="header" runat="server"></Controls:PageHeader>
			<!-- START: Page Content -->
			<table border="0" cellpadding="2">
				<tr valign="bottom">
					<td valign="top" rowspan="2">
						<Controls:PageNavigation id="navigation" runat="server"></Controls:PageNavigation>						
					</td>					
					<td valign="top">
						<p class="title"><a class="title"><xsl:attribute name="href">Manage<xsl:value-of select="@objName"/>.aspx</xsl:attribute>Manage <xsl:value-of select="@objName"></xsl:value-of></a> | <asp:Label ID="lblMode" Runat="server" CssClass="title"></asp:Label></p>
						<asp:TextBox ID="txtSearch" Runat="server" CssClass="text" MaxLength="100" Width="200"></asp:TextBox>
						<asp:LinkButton ID="cmdSearch" Runat="server" CssClass="command">
							<img border="0" src="images/cmdFind.gif"/>Find</asp:LinkButton>
						<asp:HyperLink ID="urlAddNew" Runat="server" CssClass="command">
							<xsl:attribute name="NavigateUrl">Manage<xsl:value-of select="@objName"/>.aspx</xsl:attribute>
						 <img border="0" src="images/cmdNew.gif"/>New</asp:HyperLink>
					</td>
					<td></td>
					<td><p><asp:Label ID="lblMsg" Runat="server" CssClass="error" EnableViewState="False"></asp:Label></p></td>
				</tr>
				<tr valign="top">
					<td width="50%">
						<Controls:List id="list" runat="server"></Controls:List>
					</td>
					<td></td>
					<td width="50%">
						<Controls:View id="view" runat="server"></Controls:View>
						<Controls:Edit id="edit" runat="server"></Controls:Edit>
						<asp:LinkButton ID="cmdEdit" Runat="server" CssClass="command"><img border="0" src="images/cmdEdit.gif"/>Edit</asp:LinkButton>
						<asp:LinkButton ID="cmdCreate" Runat="server" CssClass="command"><img border="0" src="images/cmdSave.gif"/>Create</asp:LinkButton>
						<asp:LinkButton ID="cmdUpdate" Runat="server" CssClass="command"><img border="0" src="images/cmdSave.gif"/>Update</asp:LinkButton>
						<asp:LinkButton ID="cmdAccept" Runat="server" CssClass="command"><img border="0" src="images/cmdAccept.gif"/>Accept</asp:LinkButton>
						<asp:LinkButton ID="cmdDelete" Runat="server" CssClass="command"><img border="0" src="images/cmdDelete.gif"/>Delete</asp:LinkButton>
						<asp:HyperLink ID="urlCancel" Runat="server" CssClass="command"><img border="0" src="images/cmdCancel.gif"/>Cancel</asp:HyperLink>
					</td>
				</tr>
			</table>
			<!-- END: Page Content -->
			<Controls:PageFooter id="footer" runat="server"></Controls:PageFooter>
		</form>
	</body>
</html>
</xsl:template></xsl:stylesheet>