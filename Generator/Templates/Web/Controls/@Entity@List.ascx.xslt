<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://asp.net" version="1.0">
<xsl:output omit-xml-declaration="yes" method="html"/>

<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">11/12/2002</xsl:param>

<!-- Type Transformations -->
<xsl:include href="../../CommonTransformations.xslt"/>

<xsl:template match="Entity">&#060;&#037;&#064; Control Language="c#" AutoEventWireup="false" Codebehind="<xsl:value-of select="@objName"/>List.ascx.cs" Inherits="<xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>List" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" &#037;&gt;

<asp:DataList ID="list" Runat="server" CssClass="list" HeaderStyle-CssClass="header" ItemStyle-CssClass="listitem"
	AlternatingItemStyle-CssClass="listitem2" Width="100%">
	<HeaderTemplate><xsl:value-of select="@objName"/> List</HeaderTemplate>
	<ItemTemplate>
		<xsl:variable name="href">&lt;&#037;#_navigateUrl+DataBinder.Eval(Container.DataItem, &#034;<xsl:value-of select="Property[@pk='1']/@objName"/>&#034;)&#037;&gt;</xsl:variable>
		<a class='keyword'>
			<xsl:attribute name="href"><xsl:value-of select="$href" disable-output-escaping="yes"></xsl:value-of></xsl:attribute>
			<b>#&lt;&#037;#DataBinder.Eval(Container.DataItem, "<xsl:value-of select="Property[@pk='1']/@objName"/>")&#037;&gt;:</b>
		</a>
		<xsl:text> </xsl:text>
		<xsl:for-each select="Property[@pk!='1']">
		<b><xsl:value-of select="@objName"/>:</b><xsl:text> </xsl:text>&lt;&#037;#DataBinder.Eval(Container.DataItem, "<xsl:value-of select="@objName"/>")&#037;&gt;<xsl:text> </xsl:text></xsl:for-each>
	</ItemTemplate>
</asp:DataList>
</xsl:template>
</xsl:stylesheet>