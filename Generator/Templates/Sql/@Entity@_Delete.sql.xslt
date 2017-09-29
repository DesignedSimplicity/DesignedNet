<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- Stored procedure header -->
<xsl:include href="HeaderFooter.sql.xslt"/>

<!-- ======================================================= -->
<xsl:template match="Entity">
<xsl:variable name="procedureName"><xsl:value-of select="@name"/>_Delete</xsl:variable>
<xsl:variable name="pkName" select="Property[@pk=1]/@name"/>

<!-- Header -->
<xsl:call-template name="AddHeader"><xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param></xsl:call-template>
<!-- Parameters -->
(
	@<xsl:value-of select="$pkName"/>&#09;<xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="Property[@pk=1]/@type"/><xsl:with-param name="length" select="Property[@pk=1]/@length"/><xsl:with-param name="isLong" select="Property[@pk=1]/@isLong"/><xsl:with-param name="isFixed" select="Property[@pk=1]/@isFixed"/></xsl:call-template>
)
AS

<!-- Delete @entity@ where pkField = @pkField -->
DELETE [<xsl:value-of select="@objName"/>]
	WHERE <xsl:value-of select="$pkName"/> = @<xsl:value-of select="$pkName"/>

<!-- Footer -->
<xsl:call-template name="AddFooter">
	<xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param>
</xsl:call-template>

</xsl:template>
</xsl:stylesheet>