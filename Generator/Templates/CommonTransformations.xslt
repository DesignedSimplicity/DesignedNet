<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text"/>

<xsl:variable name="Quote">&#034;</xsl:variable>

<xsl:template name="ToSqlType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:param name="isLong"/>
	<xsl:param name="isFixed"/>SqlDbType.<xsl:choose>
		<xsl:when test="$type='2'">SmallInt</xsl:when>
		<xsl:when test="$type='3'">Int</xsl:when>
		<xsl:when test="$type='4'">Real</xsl:when>
		<xsl:when test="$type='5'">Float</xsl:when>
		<xsl:when test="$type='6'"><xsl:if test="$length='10'">Small</xsl:if>Money</xsl:when>
		<xsl:when test="$type='11'">Bit</xsl:when>
		<xsl:when test="$type='12'">Variant</xsl:when>
		<xsl:when test="$type='17'">TinyInt</xsl:when>
		<xsl:when test="$type='20'">BigInt</xsl:when>
		<xsl:when test="$type='72'">UniqueIdentifier</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="$isLong='1'">Image</xsl:when><xsl:when test="($isFixed='1') and ($length='8')">Timestamp</xsl:when><xsl:when test="($isFixed='1') and ($length!='8')">Binary, <xsl:value-of select="$length"/></xsl:when><xsl:otherwise>VarBinary, <xsl:value-of select="$length"/></xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'"><xsl:choose><xsl:when test="$isLong='1'">Text</xsl:when><xsl:when test="$isFixed='1'">Char, <xsl:value-of select="$length"/></xsl:when><xsl:otherwise>VarChar, <xsl:value-of select="$length"/></xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='130'"><xsl:choose><xsl:when test="$isLong='1'">NText</xsl:when><xsl:when test="$isFixed='1'">NChar, <xsl:value-of select="$length"/></xsl:when><xsl:otherwise>NVarChar, <xsl:value-of select="$length"/></xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='131'">Decimal</xsl:when>
		<xsl:when test="$type='135'">DateTime</xsl:when>
		<xsl:otherwise>Unknown SqlDbType: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="ToCSharpSqlType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>Sql<xsl:choose>
		<xsl:when test="$type='2'">Int16</xsl:when>
		<xsl:when test="$type='3'">Int32</xsl:when>
		<xsl:when test="$type='4'">Single</xsl:when>
		<xsl:when test="$type='5'">Double</xsl:when>
		<xsl:when test="$type='6'">Decimal</xsl:when>
		<xsl:when test="$type='11'">Boolean</xsl:when>
		<xsl:when test="$type='12'">Object</xsl:when>
		<xsl:when test="$type='17'">Byte</xsl:when>
		<xsl:when test="$type='20'">Int64</xsl:when>
		<xsl:when test="$type='72'">Guid</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="$length='8'">DateTime</xsl:when><xsl:otherwise>ByteStream</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'">String</xsl:when>
		<xsl:when test="$type='130'">String</xsl:when>
		<xsl:when test="$type='131'">Decimal</xsl:when>
		<xsl:when test="$type='135'">DateTime</xsl:when>
		<xsl:otherwise>Unknown Sql data type: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="SqlToCSharpType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:param name="isLong"/>
	<xsl:param name="isFixed"/>
	<xsl:choose>
		<xsl:when test="$type='2'">short</xsl:when>
		<xsl:when test="$type='3'">int</xsl:when>
		<xsl:when test="$type='4'">float</xsl:when>
		<xsl:when test="$type='5'">double</xsl:when>
		<xsl:when test="$type='6'">decimal</xsl:when>
		<xsl:when test="$type='11'">bool</xsl:when>
		<xsl:when test="$type='12'">object</xsl:when>
		<xsl:when test="$type='17'">byte</xsl:when>
		<xsl:when test="$type='20'">Int64</xsl:when>
		<xsl:when test="$type='72'">Guid</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="($isFixed='1') and ($length='8')">DateTime</xsl:when><xsl:otherwise>byte[]</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'">string</xsl:when>
		<xsl:when test="$type='130'">string</xsl:when>
		<xsl:when test="$type='131'">decimal</xsl:when>
		<xsl:when test="$type='135'">DateTime</xsl:when>
		<xsl:otherwise>Unknown SqlDbType: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="ConvertSqlType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:choose>
		<xsl:when test="$type='2'">Int16</xsl:when>
		<xsl:when test="$type='3'">Int32</xsl:when>
		<xsl:when test="$type='4'">Single</xsl:when>
		<xsl:when test="$type='5'">Double</xsl:when>
		<xsl:when test="$type='6'">Decimal</xsl:when>
		<xsl:when test="$type='11'">Boolean</xsl:when>
		<xsl:when test="$type='12'">Object</xsl:when>
		<xsl:when test="$type='17'">Byte</xsl:when>
		<xsl:when test="$type='20'">Int64</xsl:when>
		<xsl:when test="$type='72'">Guid</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="$length='8'">DateTime</xsl:when><xsl:otherwise>ByteStream</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'">String</xsl:when>
		<xsl:when test="$type='130'">String</xsl:when>
		<xsl:when test="$type='131'">Decimal</xsl:when>
		<xsl:when test="$type='135'">DateTime</xsl:when>
	</xsl:choose>
</xsl:template>

<xsl:template name="DefaultSqlTypeValue">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:choose>
		<xsl:when test="$type='2'">-1</xsl:when>
		<xsl:when test="$type='3'">-1</xsl:when>
		<xsl:when test="$type='4'">0</xsl:when>
		<xsl:when test="$type='5'">0</xsl:when>
		<xsl:when test="$type='6'">0</xsl:when>
		<xsl:when test="$type='11'">false</xsl:when>
		<xsl:when test="$type='12'">null</xsl:when>
		<xsl:when test="$type='17'">0</xsl:when>
		<xsl:when test="$type='20'">-1</xsl:when>
		<xsl:when test="$type='72'">Guid</xsl:when>
		<xsl:when test="$type='128'"><xsl:choose><xsl:when test="$length='8'">DateTime.MinValue</xsl:when><xsl:otherwise>ByteStream</xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='129'">""</xsl:when>
		<xsl:when test="$type='130'">""</xsl:when>
		<xsl:when test="$type='131'">0</xsl:when>
		<xsl:when test="$type='135'">DateTime.MinValue</xsl:when>
	</xsl:choose>
</xsl:template>

<xsl:template name="ToOleDbType">
	<xsl:param name="type"/>
	<xsl:param name="length"/>
	<xsl:param name="isLong"/>
	<xsl:param name="isFixed"/>OleDbType.<xsl:choose>
		<xsl:when test="$type='2'">SmallInt</xsl:when>
		<xsl:when test="$type='3'">Single</xsl:when>
		<xsl:when test="$type='4'">Integer</xsl:when>
		<xsl:when test="$type='5'">Double</xsl:when>
		<xsl:when test="$type='6'">Currency</xsl:when>
		<xsl:when test="$type='7'">DBTimeStamp</xsl:when>
		<xsl:when test="$type='11'">Boolean</xsl:when>
		<xsl:when test="$type='17'">UnsignedTinyInt</xsl:when>
		<xsl:when test="$type='72'">Guid</xsl:when>
		<xsl:when test="$type='128'">VarBinary, <xsl:choose><xsl:when test="($length='') or ($length='0')">1073741823</xsl:when><xsl:otherwise><xsl:value-of select="$length"/></xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='130'">VarWChar, <xsl:choose><xsl:when test="($length='') or ($length='0')">536870910</xsl:when><xsl:otherwise><xsl:value-of select="$length"/></xsl:otherwise></xsl:choose></xsl:when>
		<xsl:when test="$type='131'">Decimal</xsl:when>
		<xsl:otherwise>Unknown OleDbType: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="OleDbToCSharpType">
	<xsl:param name="type"/>
	<xsl:choose>
		<xsl:when test="$type='2'">short</xsl:when>
		<xsl:when test="$type='3'">float</xsl:when>
		<xsl:when test="$type='4'">int</xsl:when>
		<xsl:when test="$type='5'">double</xsl:when>
		<xsl:when test="$type='6'">decimal</xsl:when>
		<xsl:when test="$type='7'">DateTime</xsl:when>
		<xsl:when test="$type='11'">bool</xsl:when>
		<xsl:when test="$type='17'">byte</xsl:when>
		<xsl:when test="$type='72'">*Guid*</xsl:when>
		<xsl:when test="$type='128'">byte[]</xsl:when>
		<xsl:when test="$type='130'">string</xsl:when>
		<xsl:when test="$type='131'">decimal</xsl:when>
		<xsl:otherwise>Unknown OleDbType: <xsl:value-of select="$type"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="ListSelectColumns">
	<xsl:for-each select="Property"><xsl:value-of select="@name"/><xsl:if test="following-sibling::Property">, </xsl:if></xsl:for-each>
</xsl:template>

<xsl:template name="ListSetColumns">
	<xsl:for-each select="Property[not(@pk)]"><xsl:value-of select="@name"/> = @<xsl:value-of select="@param"/><xsl:if test="following-sibling::Property">, </xsl:if></xsl:for-each>
</xsl:template>

</xsl:stylesheet>
