<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- Stored procedure header -->
<xsl:include href="HeaderFooter.sql.xslt"/>

<!-- ======================================================= -->
<xsl:template match="Entity">

<xsl:for-each select="Property[@fk='1']">
<xsl:variable name="procedureName"><xsl:value-of select="../@name"/>_ListBy<xsl:value-of select="@objName"/></xsl:variable>

<!-- Header -->
<xsl:call-template name="AddHeader"><xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param></xsl:call-template>
<!-- Parameters -->
(
	@<xsl:value-of select="@objName"/>&#09;<xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>
)
AS

SELECT
	<xsl:for-each select="../Property"><xsl:value-of select="@name"/><xsl:if test="following-sibling::Property">,<xsl:text> 
	</xsl:text></xsl:if></xsl:for-each> 
	FROM [<xsl:value-of select="../@name"/>]
	WHERE <xsl:value-of select="@objName"/> = @<xsl:value-of select="@objName"/>

<!-- Footer --> 
<xsl:call-template name="AddFooter">
	<xsl:with-param name="procedureName"><xsl:value-of select="$procedureName" /></xsl:with-param>
</xsl:call-template>

</xsl:for-each>

</xsl:template>

</xsl:stylesheet>
