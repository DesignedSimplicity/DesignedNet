<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- Stored procedure header -->
<xsl:include href="HeaderFooter.sql.xslt"/>

<!-- ======================================================= -->
<xsl:template match="Entity">
<xsl:variable name="procedureName"><xsl:value-of select="@name"/>_Update</xsl:variable>

<!-- Header -->
<xsl:call-template name="AddHeader"><xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param></xsl:call-template>
<!-- Parameters -->
(
	<xsl:for-each select="Property[@name!='Created' and @name!='Updated']">@<xsl:value-of select="@name"/>&#09;<xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template><xsl:if test="following-sibling::Property[@name!='Created' and @name!='Updated']">, </xsl:if><xsl:text> 
	</xsl:text>
	</xsl:for-each> 
)
AS

<!-- Set Field1 = @field1, Field2 = @field2 -->
UPDATE [<xsl:value-of select="@name"/>]
	SET
		<xsl:for-each select="Property[@pk='0' and @name!='Created']"><xsl:choose><xsl:when test="@name='Updated'">Updated = getdate()</xsl:when><xsl:otherwise><xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/></xsl:otherwise></xsl:choose><xsl:if test="following-sibling::Property[@pk='0' and @name!='Created']">, </xsl:if><xsl:text> 
		</xsl:text></xsl:for-each>
<!-- where FieldPK = @fieldPK -->
	WHERE <xsl:value-of select="Property[@pk='1']/@name"/> = @<xsl:value-of select="Property[@pk='1']/@name"/>

<!-- Footer -->
<xsl:call-template name="AddFooter">
	<xsl:with-param name="procedureName"><xsl:value-of select="$procedureName"/></xsl:with-param>
</xsl:call-template>

</xsl:template>
</xsl:stylesheet>
