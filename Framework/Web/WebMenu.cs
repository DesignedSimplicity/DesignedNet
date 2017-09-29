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
	/// <summary>MenuMain HTML User Control</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Web.Controls.WebMenu
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
	ToolboxData("<{0}:WebMenu runat=server></{0}:WebMenu>")]
	public class WebMenu : System.Web.UI.WebControls.WebControl
	{
		//========================================================
		//Module level enumerations
		//========================================================
		public enum DisplayMode { MainMenu, SubMenu }

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
			get { return _indexRelativeUrl; }
			set { _indexRelativeUrl = value; }
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

		//========================================================
		//Private methods
		//========================================================

		//--------------------------------------------------------
		protected override void Render(HtmlTextWriter output)
		{
			// dont process null list
			if (_nodes != null)
			{
				// get list of main items
				DataView menuItems = new DataView(_nodes);
				if (_orderByClause.Length > 0) menuItems.Sort = _orderByClause;
				
				// create header
				if (_mode == DisplayMode.MainMenu)
				{
					// create table structure
					output.AddAttribute("border", "0");
					output.AddAttribute("cellpadding", "0");
					output.AddAttribute("cellspacing", "0");
					output.AddAttribute("bgcolor", "#333399");
					output.RenderBeginTag("table");
					output.AddAttribute("height", "24");
					output.RenderBeginTag("tr");				
					output.RenderBeginTag("td");
					output.AddAttribute("width", "1");
					output.AddAttribute("height", "24");
					output.AddAttribute("src", "images/nbsp.gif");
					output.RenderBeginTag("img");
					output.RenderEndTag();
					output.RenderEndTag();
				} 
				else if (_mode == DisplayMode.SubMenu)
				{
					// create div
					output.AddAttribute("class", "submenu");
					output.RenderBeginTag("div");
				}

				// parse navigation file and build menu
				DataView nodes = _nodes.DefaultView;
				nodes.RowFilter = _indexParentID + " = " + _rootID.ToString();
				nodes.Sort = _orderByClause;
				int count = 0;
				foreach(DataRowView node in nodes)
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
					if (_mode == DisplayMode.MainMenu)
					{
						output.AddAttribute("class", "mainmenu");
						output.AddAttribute("nowrap", "");
						output.RenderBeginTag("td");
						output.AddAttribute("class", "mainmenuitem");
						output.AddAttribute("href", url);
						output.RenderBeginTag("a");
						output.Write("&nbsp;" + text + "&nbsp;");
						output.RenderEndTag(); // a
						output.RenderEndTag(); // td
						output.RenderBeginTag("td");
						output.Write("&nbsp;");
						output.RenderEndTag(); // td
					}
					else if (_mode == DisplayMode.SubMenu)
					{
						if (count > 1) output.Write("|&nbsp;"); // append spacer if not first item
						output.AddAttribute("class", "submenuitem");
						output.AddAttribute("href", url);
						output.RenderBeginTag("a");
						output.Write(text + "&nbsp;");
						output.RenderEndTag(); // a
					}
				}

				// create footer
				if (_mode == DisplayMode.MainMenu)
				{
					// close table structure
					output.RenderEndTag(); // tr
					output.RenderEndTag(); // table
				} 
				else if (_mode == DisplayMode.SubMenu)
				{
					output.RenderEndTag(); // div
				}
			}
		}
	}
}
