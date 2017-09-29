<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- ======================================================= -->
<xsl:template name="AddHeader"><xsl:param name="procedureName"/>
--------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE TYPE = 'P' AND NAME = '<xsl:value-of select="$procedureName"/>')
	BEGIN
		PRINT 'Dropping Procedure <xsl:value-of select="$procedureName"/>'
		DROP PROCEDURE <xsl:value-of select="$procedureName"/> 
	END

GO

PRINT 'Creating Procedure <xsl:value-of select="$procedureName"/>'
GO

CREATE PROCEDURE <xsl:value-of select="$procedureName"/>
</xsl:template>

<!-- ======================================================= -->
<xsl:template name="AddFooter">
<xsl:param name="procedureName"/>

GO

GRANT EXEC ON <xsl:value-of select="$procedureName"/> TO PUBLIC
</xsl:template>

<!-- ======================================================= -->
<xsl:template name="ToSqlType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:param name="isLong"/>
	<xsl:param name="isFixed"/>
	<xsl:choose>
		<xsl:when test="$type='2'">smallint</xsl:when>
		<xsl:when test="$type='3'">int</xsl:when>
		<xsl:when test="$type='4'">real</xsl:when>
		<xsl:when test="$type='5'">float</xsl:when>
		<xsl:when test="$type='6'"><xsl:if test="$length='10'">small</xsl:if>money</xsl:when>
		<xsl:when test="$type='11'">bit</xsl:when>
		<xsl:when test="$type='12'">variant</xsl:when>
		<xsl:when test="$type='17'">tinyint</xsl:when>
		<xsl:when test="$type='20'">bigint</xsl:when>
		<xsl:when test="$type='72'">uniqueidentifier</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="$isLong='1'">image</xsl:when><xsl:when test="($isFixed='1') and ($length='8')">timestamp</xsl:when><xsl:when test="($isFixed='1') and ($length!='8')">binary (<xsl:value-of select="$length"/>)</xsl:when><xsl:otherwise>varbinary (<xsl:value-of select="$length"/>)</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'"><xsl:choose><xsl:when test="$isLong='1'">text</xsl:when><xsl:when test="$isFixed='1'">char (<xsl:value-of select="$length"/>)</xsl:when><xsl:otherwise>varchar (<xsl:value-of select="$length"/>)</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='130'"><xsl:choose><xsl:when test="$isLong='1'">ntext</xsl:when><xsl:when test="$isFixed='1'">nchar (<xsl:value-of select="$length"/>)</xsl:when><xsl:otherwise>nvarchar (<xsl:value-of select="$length"/>)</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='131'">decimal</xsl:when>
		<xsl:when test="$type='135'">datetime</xsl:when>
		<xsl:otherwise>Unknown SqlDbType: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>