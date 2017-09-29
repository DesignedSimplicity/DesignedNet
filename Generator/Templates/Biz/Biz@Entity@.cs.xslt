<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="RootNamespace">DesignedNet</xsl:param>
<xsl:param name="Today">01.15.02</xsl:param>
<xsl:output method="text"/>

<!-- Type Transformations -->
<xsl:include href="../CommonTransformations.xslt"/>

<xsl:template match="Entity">/********************************************************************************/
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//============================
using DesignedNet.Framework.Biz;
using <xsl:value-of select="$RootNamespace"/>.Dal;


//----------------------------
namespace <xsl:value-of select="$RootNamespace"/>.Biz
{
	/// &lt;summary&gt;Business logic class for sql server database table: <xsl:value-of select="@objName"/>&lt;/summary&gt;
	/// ================================================================================
	/// Object:	    <xsl:value-of select="$RootNamespace"/>.Biz.Biz<xsl:value-of select="@objName"/>
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	<xsl:value-of select="$Today"/>
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class Biz<xsl:value-of select="@objName"/> : BizEntity
	{
		//========================================================
		//Field index constants
		//========================================================
		#region Field index constants

		private static Type[] _columnTypes = new Type[<xsl:value-of select="count(Property)"/>] {<xsl:for-each select="Property">typeof(<xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template>)<xsl:if test="following-sibling::Property">, </xsl:if></xsl:for-each>};
		private static string[] _columnNames = new string[<xsl:value-of select="count(Property)"/>] {<xsl:for-each select="Property">"<xsl:value-of select="@name"/>"<xsl:if test="following-sibling::Property">, </xsl:if></xsl:for-each>};

		// data column(s) name and index<xsl:for-each select="Property">
		private const int _<xsl:value-of select="@varName"/>Index = <xsl:value-of select="position()-1"/>;</xsl:for-each>

		#endregion
		

		//========================================================
		//Object constructors
		//========================================================
		public Biz<xsl:value-of select="@objName"/>() : base("<xsl:value-of select="@name"/>") {}
		public Biz<xsl:value-of select="@objName"/>(DataSet state) : base("<xsl:value-of select="@name"/>", state) {}


		//========================================================
		//Action verbs
		//========================================================
		#region Action verbs

		/// --------------------------------------------------------
		/// &lt;summary&gt;Loads the specified report of entites from the database&lt;/summary&gt;
		/// &lt;returns&gt;True if DataTable was loaded&lt;/returns&gt;
		public bool Report(<xsl:for-each select="Property[@pk=0 and @name!='Created' and @name!='Updated']">object <xsl:value-of select="@varName"/><xsl:if test="following-sibling::Property[@pk=0 and @name!='Created' and @name!='Updated']">, </xsl:if></xsl:for-each>)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			Dal<xsl:value-of select="@objName"/> dal = (Dal<xsl:value-of select="@objName"/>)_dal;
			dal.Report(<xsl:for-each select="Property[@pk=0 and @name!='Created' and @name!='Updated']"><xsl:value-of select="@varName"/>, </xsl:for-each>_dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}
<xsl:for-each select="Property[@fk='1']">
		/// --------------------------------------------------------
		/// &lt;summary&gt;Loads the specified list of entites from the database&lt;/summary&gt;
		/// &lt;returns&gt;True if DataTable was loaded&lt;/returns&gt;
		public bool ListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>(int <xsl:value-of select="@varName"/>)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			Dal<xsl:value-of select="../@objName"/> dal = (Dal<xsl:value-of select="../@objName"/>)_dal;
			dal.ListBy<xsl:value-of select="substring-before(@objName, 'ID')"/>(<xsl:value-of select="@varName"/>, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}
</xsl:for-each>	
		#endregion
	
	
		//========================================================
		//Entity get/set methods
		//========================================================
		#region Entity get/set methods
<xsl:for-each select="Property[@fk='1']">
		/// --------------------------------------------------------
		/// &lt;summary&gt;Gets the business object for the releated entity&lt;/summary&gt;
		public Biz<xsl:value-of select="substring-before(@objName, 'ID')"/><xsl:text> </xsl:text><xsl:value-of select="substring-before(@objName, 'ID')"/>
		{
			get
			{
				Biz<xsl:value-of select="substring-before(@objName, 'ID')"/> biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new Biz<xsl:value-of select="substring-before(@objName, 'ID')"/>(_dataSet);
						if (!IsNull( _columnNames[_<xsl:value-of select="@varName"/>Index] )) biz.Find(_<xsl:value-of select="@varName"/>);
					}
					else // create new entity with new state and load data
					{
						biz = new Biz<xsl:value-of select="substring-before(@objName, 'ID')"/>();
						if (!IsNull( _columnNames[_<xsl:value-of select="@varName"/>Index] )) biz.Load(_<xsl:value-of select="@varName"/>);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._<xsl:value-of select="@varName"/> = value._<xsl:value-of select="@varName"/>; } // attempt to sync key values
				catch { }
			}
		}
</xsl:for-each>
		#endregion
		

		//========================================================
		//Attribute get/set methods
		//========================================================
		#region Attribute get/set methods
<xsl:for-each select="Property">
		/// --------------------------------------------------------
		/// &lt;summary&gt;Gets or sets the <xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template> typed value for <xsl:value-of select="@name"/>&lt;/summary&gt;
		public object<xsl:text> </xsl:text><xsl:value-of select="@objName"/>
		{
			get { return this[ _columnNames[_<xsl:value-of select="@varName"/>Index] ]; }
		}
		<xsl:if test="@isNullable='1'">public bool<xsl:text> </xsl:text><xsl:choose><xsl:when test="@pk='1' or @fk='1'"><xsl:value-of select="@objName"/></xsl:when><xsl:otherwise><xsl:value-of select="@objName"/></xsl:otherwise></xsl:choose>IsNull
		{
			get { return IsNull( _columnNames[_<xsl:value-of select="@varName"/>Index] ); }
			<xsl:if test="@name='Created' or @name='Updated'">//</xsl:if>set { this[ _columnNames[_<xsl:value-of select="@varName"/>Index] ] = System.DBNull.Value; }
		}</xsl:if>
		public <xsl:call-template name="SqlToCSharpType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/><xsl:with-param name="isLong" select="@isLong"/><xsl:with-param name="isFixed" select="@isFixed"/></xsl:call-template><xsl:text> </xsl:text>_<xsl:value-of select="@varName"/>
		{
			get { return Get<xsl:call-template name="ConvertSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/></xsl:call-template>( _columnNames[_<xsl:value-of select="@varName"/>Index] ); }
			<xsl:if test="@name='Created' or @name='Updated'">//</xsl:if>set { Set<xsl:call-template name="ConvertSqlType"><xsl:with-param name="type" select="@type"/><xsl:with-param name="length" select="@length"/></xsl:call-template>( _columnNames[_<xsl:value-of select="@varName"/>Index], value ); }
		}
</xsl:for-each>
		#endregion

	
		//========================================================
		//IBizEntity implementation
		//========================================================
		#region Implementation of IBizEntity
		
		public override bool CreateDal()
		{
			_dal = new Dal<xsl:value-of select="@objName"/>();
			return (_dal != null);
		}
		
		#endregion


		//========================================================
		//IBizState implementation
		//========================================================
		#region Implementation of IBizState
		
		public override bool CreateState()
		{
			// create DataTable and add columns
			_dataTable = new DataTable(_entityName);
				
			// create and add primary key column
			DataColumn[] keys = new DataColumn[1];
			keys[0] = _dataTable.Columns.Add( _columnNames[ 0 ], _columnTypes[ 0 ] );
			keys[0].Unique = true;
			keys[0].AutoIncrement = true;
			keys[0].AutoIncrementSeed = -1;
			keys[0].AutoIncrementStep = -1;
			_dataTable.PrimaryKey = keys;

			// create and add all other columns
			for(int col=1; col&lt;=_columnNames.GetUpperBound(0); col++) _dataTable.Columns.Add( _columnNames[ col ], _columnTypes[ col ] );

			// add DataTable to DataSet
			if (_dataSet == null) _dataSet = new DataSet();
			_dataSet.Tables.Add(_dataTable);

			// add relationships to DataSet<xsl:for-each select="Property[@fk='1']">
			if (_dataSet.Tables.Contains("<xsl:value-of select="substring-before(@objName, 'ID')"/>"))
			{
				string relationshipName = GetRelationshipName("<xsl:value-of select="substring-before(@objName, 'ID')"/>");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["<xsl:value-of select="substring-before(@objName, 'ID')"/>"].Columns["<xsl:value-of select="@objName"/>"];
					DataColumn fk = _dataSet.Tables["<xsl:value-of select="../@objName"/>"].Columns["<xsl:value-of select="@objName"/>"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			</xsl:for-each>
					
			// return success
			return (_dataTable != null);
		}
		
		#endregion		
	}
}
</xsl:template>
</xsl:stylesheet>
