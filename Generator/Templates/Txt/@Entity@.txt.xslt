<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" omit-xml-declaration="yes"/>

<!-- Type Transformations -->
<xsl:include href="../CommonTransformations.xslt"/>
<!-- ======================================================= -->

<xsl:template match="Entity">Table: <xsl:value-of select="@name"/>

#. COLUMN&#09;&#09;PK&#09;FK&#09;NULLABLE&#09;DB TYPE
<xsl:for-each select="Property">
<xsl:variable name="type"><xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template></xsl:variable>
<xsl:value-of select="position()"/>. <xsl:value-of select="@name"/>&#09;&#09;<xsl:value-of select="@pk"/>&#09;<xsl:value-of select="@fk"/>&#09;<xsl:value-of select="@isNullable"/>&#09;<xsl:value-of select="$type"/><xsl:text> 
</xsl:text></xsl:for-each>

</xsl:template>
</xsl:stylesheet>
