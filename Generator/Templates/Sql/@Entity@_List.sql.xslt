<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- Stored procedure header -->
<xsl:include href="HeaderFooter.sql.xslt"/>

<!-- ======================================================= -->
<xsl:template match="Entity">
<xsl:variable name="procedureName"><xsl:value-of select="@name"/>_List</xsl:variable>

<!-- Header -->
<xsl:call-template name="AddHeader"><xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param></xsl:call-template>
AS

SELECT
	<xsl:for-each select="Property"><xsl:value-of select="@name"/><xsl:if test="following-sibling::Property">,<xsl:text> 
	</xsl:text></xsl:if></xsl:for-each> 
	FROM [<xsl:value-of select="@name"/>]

<!-- Footer --> 
<xsl:call-template name="AddFooter">
	<xsl:with-param name="procedureName"><xsl:value-of select="$procedureName" /></xsl:with-param>
</xsl:call-template>
</xsl:template>

</xsl:stylesheet>
