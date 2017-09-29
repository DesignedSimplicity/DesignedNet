using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DesignedNet.Framework.Web
{
	/// <summary>Nav HTML User Control</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Web.Controls.WebPath
	/// Language:	C# ASP.NET
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	01.24.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	[DefaultProperty("RootID"), 
	ToolboxData("<{0}:WebPath runat=server></{0}:WebPath>")]
	public class WebPath : System.Web.UI.WebControls.WebControl
	{
		//========================================================
		//Module level enumerations
		//========================================================
		public enum DisplayMode { Active, Passive }

		//========================================================
		//Module level variables
		//========================================================
		protected string _indexNavID = "NavID";					// data column for node ID
		protected string _indexRootID = "RootID";				// data column for root node ID
		protected string _indexParentID = "ParentID";			// data column for parent node ID
		protected string _indexSequence = "Sequence";			// data column for sequence order
		protected string _indexText = "Text";					// data columm for display name attribute
		protected string _indexData = "Data";					// data column for url data value
		protected string _indexRelativeUrl = "Url";				// data column for url format string
		protected string _indexImageUrl = "Image";				// data column for url to thumbnail
		protected string _orderByClause = "Sequence";			// default sort order clause
		protected string _textFormat = "";	// data text format string
		protected string _urlFormat = "";	// data navigation format string
		protected DisplayMode _mode;		// display mode for nav tree
		protected DataTable _nodes;			// DataTable to hold collection of tree nodes
		protected ArrayList _paths;			// collection of expanded node path strings
		protected int _rootID = 0;			// default value of non-visible root node
		protected int _navID = 0;


		//========================================================
		//Property get/set methods
		//========================================================
		#region Property get/set methods

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public DataTable DataSource
		{
			get { return _nodes; }
			set { _nodes = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public DisplayMode Mode
		{
			get { return _mode; }
			set { _mode = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public int RootID
		{
			get { return _rootID; }
			set { _rootID = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string DataTextField
		{
			get { return _indexText; }
			set { _indexText = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string DataTextFormatString
		{
			get { return _textFormat; }
			set { _textFormat = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string DataNavigateUrlField
		{
			get { return _indexData; }
			set { _indexData = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string DataNavigateUrlFormatString
		{
			get { return _urlFormat; }
			set { _urlFormat = value; }
		}
		#endregion

		
		//========================================================
		//Public methods
		//========================================================

		//--------------------------------------------------------
		/// <summary>Creates a DataTable to hold the dynamically created tree nodes</summary>
		public void CreateRoot()
		{
			// create table with default schema
			_rootID = 0;
			_nodes = new DataTable("Nav");

			// create and add primary key column
			DataColumn pk = _nodes.Columns.Add( _indexNavID, typeof(int) );
			pk.Unique = true; pk.AutoIncrement = true; pk.AutoIncrementSeed = 100; pk.AutoIncrementStep = 1;
				
			// create and add foreign key column
			DataColumn root = _nodes.Columns.Add( _indexRootID, typeof(int) );
			root.AllowDBNull = false;

			// create and add foreign key column
			DataColumn parent = _nodes.Columns.Add( _indexParentID, typeof(int) );
			parent.AllowDBNull = false;

			// create and add other columns
			DataColumn c;
			c = _nodes.Columns.Add( _indexSequence, typeof(int) );
			c.AllowDBNull = true;

			c = _nodes.Columns.Add( _indexText, typeof(string) );
			c.AllowDBNull = false;

			c = _nodes.Columns.Add( _indexData, typeof(string) );
			c.AllowDBNull = true;

			c = _nodes.Columns.Add( _indexImageUrl, typeof(string) );
			c.AllowDBNull = true;

			c = _nodes.Columns.Add( _indexRelativeUrl, typeof(string) );
			c.AllowDBNull = true;
		}

		//--------------------------------------------------------
		public int AddItem(int navID, string text, string data, string imageUrl, string relativeUrl)
		{
			// create table if missing
			if (_nodes == null) CreateRoot();

			// create and populate new row
			DataRow row = _nodes.NewRow();
			if (navID > 0) row[_indexNavID] = navID;
			row[_indexRootID] = _rootID;
			row[_indexParentID] = _rootID;
			row[_indexSequence] = 1;
			row[_indexText] = text;
			row[_indexData] = data;
			row[_indexImageUrl] = imageUrl;
			row[_indexRelativeUrl] = relativeUrl;
			
			// add new row to table and return id
			_nodes.Rows.Add(row);			
			return Convert.ToInt32(row[_indexNavID]);
		}

		//--------------------------------------------------------
		public void FindNode(int id)
		{
			_navID = id;
		}

		//========================================================
		//Private methods
		//========================================================

		//--------------------------------------------------------
		protected override void Render(HtmlTextWriter output)
		{
			// dont process null list
			if (_nodes != null)
			{
				string textOutput = "";

				// get list of main items
				DataView menuItems = new DataView(_nodes);
				if (_orderByClause.Length > 0) menuItems.Sort = _orderByClause;
				
				// create span
				output.AddAttribute("class", "title");
				output.RenderBeginTag("span");

				string fullPath = "\\" + _navID.ToString();

				// create path list if missing
				if (_paths == null) _paths = new ArrayList();

				// find node
				DataView nodes = new DataView(_nodes); // set filter to find name key
				nodes.RowFilter = _indexNavID + " = " + _navID.ToString();
				if (nodes.Count >= 1)
				{
					int count = 0;
					DataRowView node = nodes[0];
					int parentID = Convert.ToInt32(node[_indexParentID]);
					while (node != null)
					{
						// extract values
						int id = DesignedNet.Framework.Web.Common.GetID(node, _indexNavID);
						string text = node[_indexText].ToString();
						if (_textFormat.Length > 0) text = _textFormat.Replace("{0}", text); // format text if requested

						// create url
						string url = node[_indexRelativeUrl].ToString();
						string data = node[_indexData].ToString();
						if (_urlFormat.Length > 0) url = _urlFormat; // override url format
						if (url.Length > 0) url = url.Replace("{0}", data); // format url if data provided				

						count++; // keep track of count						
						if (_mode == DisplayMode.Active)
						{
							textOutput = " \\ <a class='title' href='" + url + "'>" + text + "</a>" + textOutput;
						}
						else if (_mode == DisplayMode.Passive)
						{
							textOutput = text + " \\ " + textOutput;
						}

						// add new id, transverse parent
						parentID = DesignedNet.Framework.Web.Common.GetID(node, _indexParentID);
						if (parentID == _rootID)
							node = null;
						else
						{
							fullPath = "\\" + parentID.ToString() + fullPath;
							nodes.RowFilter = _indexNavID + " = " + parentID.ToString();
							node = nodes[0];
						}
					}

					output.Write(textOutput.Substring(2));
					output.RenderEndTag(); // span					
				}

				// add built path to list
				if (fullPath.Length > 1) _paths.Add(fullPath.TrimEnd('\\'));
			}
		}
	}
}
