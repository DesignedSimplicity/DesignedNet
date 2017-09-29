<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://asp.net" version="1.0">
<xsl:output omit-xml-declaration="yes"/>

<xsl:param name="RootNamespace">DesignedNet.Framework</xsl:param>
<xsl:param name="Today">01/01/04</xsl:param>

<!-- Type Transformations -->
<xsl:include href="../../CommonTransformations.xslt"/>

<xsl:template match="Entity">&#060;&#037;&#064; Control Language="c#" AutoEventWireup="false" Codebehind="<xsl:value-of select="@objName"/>Edit.ascx.cs" Inherits="<xsl:value-of select="$RootNamespace"/>.Web.Controls.<xsl:value-of select="@objName"/>Edit" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" &#037;&gt;

<table class="form" border="0" cellpadding="1" cellspacing="0">
	<tr>
		<td colspan="2" class="header"><asp:Label ID="lblTitle" Runat="server"><xsl:value-of select="@objName"/> Form</asp:Label></td>
	</tr>
	<xsl:for-each select="Property[@pk='0' and @name!='Created' and @name!='Updated']">
	<tr>
		<td class="field"><xsl:value-of select="@name"/>:</td>
		<td><!-- Type specific controls -->
			<xsl:choose>
				<xsl:when test="@fk = '1'">
					<asp:DropDownList>
						<xsl:attribute name="ID">sel<xsl:value-of select="@objName"/></xsl:attribute>
						<xsl:attribute name="Runat">server</xsl:attribute>
						<xsl:attribute name="CssClass">select</xsl:attribute>
						<asp:ListItem Value="">SELECT ONE...</asp:ListItem>
					</asp:DropDownList>
				</xsl:when>
				<xsl:otherwise>
					<asp:TextBox>
						<xsl:attribute name="ID">txt<xsl:value-of select="@objName"/></xsl:attribute>
						<xsl:attribute name="Runat">server</xsl:attribute>
						<xsl:attribute name="CssClass">input</xsl:attribute>
						<xsl:attribute name="MaxLength">
							<xsl:choose>
								<xsl:when test="@length!=''"><xsl:value-of select="@length"/></xsl:when>
								<xsl:otherwise>25</xsl:otherwise>
							</xsl:choose>
						</xsl:attribute>
					</asp:TextBox>
				</xsl:otherwise>
			</xsl:choose>
		</td>
	</tr>
	</xsl:for-each>
</table>

</xsl:template>
</xsl:stylesheet>
