<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://asp.net" version="1.0">
<xsl:output omit-xml-declaration="yes" method="html"/>

<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">11/12/2002</xsl:param>

<!-- Type Transformations -->
<xsl:include href="../../CommonTransformations.xslt"/>

<xsl:template match="Entity">&#060;&#037;&#064; Control Language="c#" AutoEventWireup="false" Codebehind="<xsl:value-of select="@objName"/>View.ascx.cs" Inherits="<xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>View" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" &#037;&gt;
<table class="form" border="0" cellpadding="1" cellspacing="0">
	<tr>
		<td class="header"><asp:Label ID="lblTitle" Runat="server"><xsl:value-of select="@objName"/> View</asp:Label></td>
	</tr>
	<tr>
		<td><p class="text"><asp:Label ID="lblView" Runat="server" EnableViewState="false"></asp:Label></p>
		</td>
	</tr>
</table>
</xsl:template>
</xsl:stylesheet>