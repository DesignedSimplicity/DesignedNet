<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="WithForXml">0</xsl:param>
<xsl:param name="Today">01.15.02</xsl:param>
<xsl:output method="text"/>

<!-- Type Transformations -->
<xsl:include href="../CommonTransformations.xslt"/>

<xsl:template match="Entity">/********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Xml.XPath;

//============================
using DesignedNet.Framework.Dal;


//----------------------------
namespace <xsl:value-of select="$RootNamespace"/>.Dal
{
	/// &lt;summary&gt;Data access layer for <xsl:value-of select="@name"/> table in a sql server 2000 database&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Dal.Data<xsl:value-of select="@objName"/>
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	<xsl:value-of select="$Today"/>
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class Dal<xsl:value-of select="@objName"/> : DalSqlDb
	{
		//========================================================
		//Stored procedure constants
		//========================================================
		#region Stored procedure constants
<xsl:for-each select="Property[@fk='1']">
		private const string _listBy<xsl:value-of select="substring-before(@objName, 'ID')"/>Command = "_ListBy<xsl:value-of select="@objName"/>";</xsl:for-each>
		#endregion
		
		
		//========================================================
		//Object constructors
		//========================================================
		public Dal<xsl:value-of select="@objName"/>() : base("<xsl:value-of select="@objName"/>") {}
		
		
		//========================================================
		//IDalCmd implementation
		//========================================================
		#region IDalCmd implementation
		
		/// --------------------------------------------------------
		/// &lt;summary&gt;Creates a SqlCommand object for the insert stored procedure&lt;/summary&gt;
		/// &lt;returns&gt;Initalized SqlCommand object&lt;/returns&gt;
		public override SqlCommand GetInsertCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _insertCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p;
			<xsl:for-each select="Property[@name!='Created' and @name!='Updated']">
			p = cmd.Parameters.Add("@<xsl:value-of select="@name"/>", <xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>);
			p.SourceColumn = "<xsl:value-of select="@name"/>";
			p.SourceVersion = DataRowVersion.Current;
			<xsl:if test="@pk='1'">p.Direction = ParameterDirection.Output;<xsl:text>
			</xsl:text></xsl:if></xsl:for-each>
			return cmd;
		}

		/// --------------------------------------------------------
		/// &lt;summary&gt;Creates a SqlCommand object for the update stored procedure&lt;/summary&gt;
		/// &lt;returns&gt;Initalized SqlCommand object&lt;/returns&gt;
		public override SqlCommand GetUpdateCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _updateCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p;
			<xsl:for-each select="Property[@name!='Created' and @name!='Updated']">
			p = cmd.Parameters.Add("@<xsl:value-of select="@name"/>", <xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>);
			p.SourceColumn = "<xsl:value-of select="@name"/>";
			p.SourceVersion = DataRowVersion.Current;
			</xsl:for-each>
			return cmd;
		}

		/// --------------------------------------------------------
		/// &lt;summary&gt;Creates a SqlCommand object for the report stored procedure&lt;/summary&gt;
		/// &lt;returns&gt;Initalized SqlCommand object&lt;/returns&gt;
		public override SqlCommand GetReportCmd()
		{
			SqlCommand cmd = new SqlCommand(_tableName + _reportCommand);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p;
			<xsl:for-each select="Property[@pk=0 and @name!='Created' and @name!='Updated']">
			p = cmd.Parameters.Add("@<xsl:value-of select="@name"/>", <xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>);
			p.SourceColumn = "<xsl:value-of select="@name"/>";
			p.SourceVersion = DataRowVersion.Current;
			</xsl:for-each>
			return cmd;
		}
<xsl:for-each select="Property[@fk='1']">
		/// --------------------------------------------------------
		/// &lt;summary&gt;Creates a SqlCommand object for the list by <xsl:value-of select="substring-before(@objName, 'ID')"/> stored procedure&lt;/summary&gt;
		/// &lt;returns&gt;Initalized SqlCommand object&lt;/returns&gt;
		public SqlCommand GetListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>Cmd( <xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template><xsl:text> </xsl:text><xsl:value-of select="@varName"/> )
		{
			SqlCommand cmd = new SqlCommand(_tableName + _listBy<xsl:value-of select="substring-before(@objName, 'ID')"/>Command);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = GetConnection();

			SqlParameter p = cmd.Parameters.Add("@<xsl:value-of select="@objName"/>", <xsl:call-template name="ToSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>);
			p.SourceColumn = "<xsl:value-of select="@objName"/>";
			p.SourceVersion = DataRowVersion.Original;
			p.Value = <xsl:value-of select="@varName"/>;

			return cmd;
		}

</xsl:for-each>		
		#endregion
		

		//========================================================
		//IDalData implementation
		//========================================================
		#region IDalData implementation

		/// --------------------------------------------------------
		/// &lt;summary&gt;Reports the entity&lt;/summary&gt;
		public int Report( <xsl:for-each select="Property[@pk=0 and @name!='Created' and @name!='Updated']">object <xsl:value-of select="@varName"/>, </xsl:for-each>DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			SqlCommand cmd = GetReportCmd();
			<xsl:for-each select="Property[@pk=0 and @name!='Created' and @name!='Updated']">SetParameter(cmd, "<xsl:value-of select="@objName"/>", <xsl:value-of select="@varName"/>);
			</xsl:for-each>
			da.SelectCommand = cmd;

			// create and fill typed table
			return da.Fill(table);
		}
<xsl:for-each select="Property[@fk='1']">
		/// --------------------------------------------------------
		/// &lt;summary&gt;Lists the entity by <xsl:value-of select="substring-before(@objName, 'ID')"/>&lt;/summary&gt;
		public int ListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>( <xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template><xsl:text> </xsl:text><xsl:value-of select="@varName"/>, DataTable table )
		{
			// create new data adapter
			SqlDataAdapter da = new SqlDataAdapter();

			// get data access command
			da.SelectCommand = GetListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>Cmd( <xsl:value-of select="@varName"/> );

			// create and fill typed table
			return da.Fill(table);
		}

		/// --------------------------------------------------------
		/// &lt;summary&gt;Lists the entity by <xsl:value-of select="substring-before(@objName, 'ID')"/>&lt;/summary&gt;
		public int ListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>( <xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template><xsl:text> </xsl:text><xsl:value-of select="@varName"/>, out SqlDataReader sql )
		{
			// create new data adapter
			SqlCommand cmd = GetListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>Cmd( <xsl:value-of select="@varName"/> );

			// get data access command
			sql = cmd.ExecuteReader();

			// return invalid for reader
			return -1;
		}

</xsl:for-each>
		#endregion

	}
}
</xsl:template>

</xsl:stylesheet>
