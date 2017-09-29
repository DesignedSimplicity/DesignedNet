using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DesignedNet.Framework.Web
{
	/// <summary>Tree HTML Custom Control</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Web.Controls.WebTree
	/// Language:	C# ASP.NET
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	12.29.02
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	[DefaultProperty("RootID"), 
	ToolboxData("<{0}:WebTree runat=server></{0}:WebTree>")]
	public class WebTree : System.Web.UI.WebControls.WebControl
	{
		//========================================================
		//Module level enumerations
		//========================================================
		public enum DisplayMode { Static, Dynamic }

		//========================================================
		//Module level variables
		//========================================================
		protected string _indexNavID = "NavID";			// data column for node ID
		protected string _indexRootID = "RootID";		// data column for root node ID
		protected string _indexParentID = "ParentID";	// data column for parent node ID
		protected string _indexSequence = "Sequence";	// data column for sequence order
		protected string _indexText = "Text";			// data columm for display name attribute
		protected string _indexData = "Data";			// data column for url data value
		protected string _indexRelativeUrl = "Url";		// data column for url format string
		protected string _indexImageUrl = "Image";		// data column for image file
		protected string _orderByClause = "Sequence";	// default sort order clause
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
		public string DataIDField
		{
			get { return _indexNavID; }
			set { _indexNavID = value; }
		}

		//--------------------------------------------------------
		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string DataOrderByField
		{
			get { return _orderByClause; }
			set { _orderByClause = value; }
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
			pk.Unique = true; pk.AutoIncrement = true; pk.AutoIncrementSeed = 1; pk.AutoIncrementStep = 1;
				
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

			c = _nodes.Columns.Add( _indexRelativeUrl, typeof(string) );
			c.AllowDBNull = true;

			c = _nodes.Columns.Add( _indexImageUrl, typeof(string) );
			c.AllowDBNull = true;
		}

		//--------------------------------------------------------
		/// <summary>Adds a tree node to the nav tree</summary>
		//public int AddNode(int parentID, string text, string data, string imageUrl, string relativeUrl) { return AddNode(0, _rootID, parentID, text, data, imageUrl, relativeUrl); }
		public int AddNode(int navID, int rootID, int parentID, string text, string data, string imageUrl, string relativeUrl)
		{
			// create table if missing
			if (_nodes == null) CreateRoot();

			// create and populate new row
			DataRow row = _nodes.NewRow();
			if (navID > 0) row[_indexNavID] = navID; // let autogenerate
			row[_indexRootID] = rootID;
			row[_indexParentID] = parentID;
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
		/// <summary>Adds specified path to expanded path list</summary>
		/// <param name="fullPath">List of key values starting with and seperated by '\'</param>
		public void ShowPath(string fullPath)
		{
			// create path list if missing
			if (_paths == null) _paths = new ArrayList();

			// add new path to list
			_paths.Add(fullPath);
		}

		//--------------------------------------------------------
		/// <summary>Adds specified path to expanded path list</summary>
		/// <param name="fullPath">List of name values starting with and seperated by '\'</param>
		public int FindPath(string namePath)
		{
			int navID = 0;

			// check nodes list
			if (_nodes != null)
			{
				string fullPath = "\\";

				// create path list if missing
				if (_paths == null) _paths = new ArrayList();

				// find key for each string part
				foreach(string nameKey in namePath.Split('\\'))
				{
					DataView matchNodes = new DataView(_nodes); // set filter to find name key
					matchNodes.RowFilter = _indexText + " = '" + nameKey.Replace("'", "''") + "'";
					if (matchNodes.Count >= 1)
					{
						navID = Convert.ToInt32(matchNodes[0][_indexNavID]);
						fullPath += navID.ToString() + "\\";
					}					
				}

				// add built path to list
				if (fullPath.Length > 1) _paths.Add(fullPath.TrimEnd('\\'));
			}

			// return ID of found node
			return navID;
		}

		//--------------------------------------------------------
		/// <summary>Adds specified node to expanded path list</summary>
		/// <param name="fullPath">List of name values starting with and seperated by '\'</param>
		public string FindNode(int nodeID)
		{
			string fullPath = "\\" + nodeID.ToString();
			
			// check nodes list
			if (_nodes != null)
			{
				// create path list if missing
				if (_paths == null) _paths = new ArrayList();

				// find node
				DataView nodes = new DataView(_nodes); // set filter to find name key
				nodes.RowFilter = _indexNavID + " = " + nodeID.ToString();
				if (nodes.Count >= 1)
				{
					DataRowView node = nodes[0];
					int parentID = Convert.ToInt32(node[_indexParentID]);
					while (node != null)
					{
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
				}

				// add built path to list
				if (fullPath.Length > 1) _paths.Add(fullPath.TrimEnd('\\'));
			}

			// return full path
			return fullPath;
		}

		//--------------------------------------------------------
		/// <summary>Determines if the specified path is opened or closed</summary>
		/// <param name="fullPath">List of key values starting with and seperated by '\'</param>
		public bool IsPathOpen(string fullPath)
		{
			// loop through all paths
			if (_paths != null)
			{
				foreach(string openPath in _paths)
				{
					string thisPath = openPath + "\\";
					if (thisPath.StartsWith(fullPath + "\\")) return true; // return true if found
				}
			}

			// return false if none
			return false;
		}


		//========================================================
		//Private methods
		//========================================================

		//--------------------------------------------------------
		/// <summary>Returns a DataView for all the child nodes of the key</summary>
		private DataView GetChildren(string parentID)
		{
			DataView children = new DataView(_nodes);
			children.RowFilter = _indexParentID + " = " + parentID;
			children.Sort = _orderByClause;
			return children;
		}

		//--------------------------------------------------------
		private void RenderNodes(HtmlTextWriter output, DataView nodes, int depth, string relativePath)
		{
			// iterate throught child nodes
			foreach(DataRowView node in nodes)
			{
				// extract values
				int id = DesignedNet.Framework.Web.Common.GetID(node, _indexNavID);
				if (id > 0)
				{
					string text = node[_indexText].ToString(); //.Replace("&", "&amp;");
					if (_textFormat.Length > 0) text = _textFormat.Replace("{0}", text); // format text if requested

					// create url
					string url;
					try { url = node[_indexRelativeUrl].ToString(); }
					catch { url = ""; }
					if (_urlFormat.Length > 0) url = _urlFormat; // override url format
					if (url.Length > 0)
					{
						string data;
						try { data = node[_indexData].ToString(); }
						catch { data = ""; }
						data = data.Replace(" ", "%20");
						data = data.Replace("#", "%23");
						data = data.Replace("&", "%26");						
						url = url.Replace("{0}", data); // format url if data provided
					}

					// get child nodes
					string icon = "none.gif";
					string fullPath = relativePath + "\\" + id.ToString();
					bool isOpen = IsPathOpen(fullPath);
					DataView children = GetChildren(id.ToString());
					if (children.Count > 0) // set icon mode
						if (isOpen) icon = "minus.gif"; else icon = "plus.gif";

					// decide on node type to render
					if (depth == 0) // render root nodes
					{
						// render root node
						RenderRootNode(output, isOpen, fullPath, id.ToString(), "images/nav" + icon, text, url);
					}
					else if (depth == 1) // render root child nodes
					{
						// render child 1 node
						RenderRootChild(output, isOpen, fullPath, id.ToString(), "images/2" + icon, text, url);
					} 
					else
					{
						// render child 2+ node
						RenderChildNode(output, isOpen, depth, fullPath, id.ToString(), "images/1" + icon, text, url);
					}
				}
			}
		}

		//--------------------------------------------------------
		private void RenderChildNode(HtmlTextWriter output, bool showChildren, int depth, string fullPath, string id, string icon, string text, string navigateUrl)
		{
			string cssClass = "navchild2";
			if (depth > 2) cssClass = "navchild3";

			// create div section
			output.AddAttribute("class", cssClass);
			output.RenderBeginTag("div");
			for(int i=0;i<((depth-1)*2);i++) output.Write("&nbsp;");

			// create icon image
			output.AddAttribute("width", "9");
			output.AddAttribute("height", "9");
			output.AddAttribute("border", "0");
			output.AddAttribute("src", icon);

			// close icon image
			output.RenderBeginTag("img");
			output.RenderEndTag(); // img

			// create text link
			output.AddAttribute("href", navigateUrl);
			output.AddAttribute("class", cssClass);
			output.RenderBeginTag("a");

			// set indent and write text
			output.Write(text);

			// close link
			output.RenderEndTag(); // a

			// close div section
			output.RenderEndTag(); // div

			// render child nodes
			if (showChildren) RenderNodes(output, GetChildren(id), depth+1, fullPath);
		}
		
		//--------------------------------------------------------
		private void RenderRootChild(HtmlTextWriter output, bool showChildren, string fullPath, string id, string icon, string text, string navigateUrl)
		{
			// create table row
			output.RenderBeginTag("tr");

			// create spacer cell
			output.AddAttribute("bgcolor", "#9999ff");
			output.AddAttribute("width", "2");
			output.RenderBeginTag("td");
			output.RenderEndTag(); // td
			
			// create spacer image
			output.AddAttribute("width", "4");
			output.RenderBeginTag("td");
			output.RenderEndTag(); // td
			
			// create empty cell
			output.AddAttribute("nowrap", "");
			output.RenderBeginTag("td");

			// create and close spacer
			output.AddAttribute("width", "10");
			output.AddAttribute("height", "11");
			output.AddAttribute("border", "0");
			output.AddAttribute("src", icon);
			output.RenderBeginTag("img");
			output.RenderEndTag(); // img

			// create text link
			output.AddAttribute("href", navigateUrl);
			output.AddAttribute("class", "navchild1");
			output.RenderBeginTag("a");
			output.Write(text);
			output.RenderEndTag(); // a

			// render child nodes
			if (showChildren) RenderNodes(output, GetChildren(id), 2, fullPath);

			// close table cell
			output.RenderEndTag(); // td

			// close table row
			output.RenderEndTag(); // tr
		}

		//--------------------------------------------------------
		private void RenderRootNode(HtmlTextWriter output, bool showChildren, string fullPath, string id, string icon, string text, string navigateUrl)
		{
			// create table row
			output.RenderBeginTag("tr");

			// create icon cell
			output.AddAttribute("colspan", "2");
			output.RenderBeginTag("td");

			// create icon image
			output.AddAttribute("width", "6");
			output.AddAttribute("height", "20");
			output.AddAttribute("border", "0");
			output.AddAttribute("src", icon);
			// add dynamic html scripting if (_mode == DisplayMode.Dynamic) output.AddAttribute("onclick", "Toggle(0, this, " + this.ClientID + ".rows(" + _targetRow.ToString() + "));");

			// close icon image
			output.RenderBeginTag("img");
			output.RenderEndTag(); // img

			// close icon cell
			output.RenderEndTag(); // td

			// create text cell
			output.AddAttribute("nowrap", "");
			output.RenderBeginTag("td");

			// create and close spacer
			output.AddAttribute("width", "2");
			output.AddAttribute("height", "2");
			output.AddAttribute("border", "0");
			output.AddAttribute("src", "images/nbsp.gif");
			output.RenderBeginTag("img");
			output.RenderEndTag(); // img

			// create text link
			output.AddAttribute("href", navigateUrl);
			output.AddAttribute("class", "navitem");
			output.RenderBeginTag("a");
			output.Write(text);
			output.RenderEndTag(); // a

			// render child nodes
			if (showChildren) RenderNodes(output, GetChildren(id), 1, fullPath);

			// close table cell
			output.RenderEndTag(); // td

			// close table row
			output.RenderEndTag(); // tr
		}
		
		
		//========================================================
		//WebControl implementation
		//========================================================

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
			// dont process null list
			if (_nodes != null)
			{
				// open table
				output.AddAttribute("border", "0");
				//output.AddAttribute("class", "nav");
				output.AddAttribute("cellpadding", "0");
				output.AddAttribute("cellspacing", "0");
				output.RenderBeginTag("table");

				// render header
				/*
				output.RenderBeginTag("tr");
				output.AddAttribute("width", "2");
				output.AddAttribute("bgcolor", "#9999ff");
				output.RenderBeginTag("td");
				output.AddAttribute("src", "images/nbsp.gif");
				output.AddAttribute("height", "2");
				output.AddAttribute("width", "2");
				output.RenderBeginTag("img");
				output.RenderEndTag(); // img
				output.RenderEndTag(); // td		
				output.AddAttribute("width", "4");
				output.RenderBeginTag("td");
				output.AddAttribute("src", "images/nbsp.gif");
				output.AddAttribute("height", "2");
				output.AddAttribute("width", "4");
				output.RenderBeginTag("img");
				output.RenderEndTag(); // img
				output.RenderEndTag(); // td
				output.RenderBeginTag("td");
				output.RenderEndTag(); // td	
				output.AddAttribute("src", "images/nbsp.gif");
				output.AddAttribute("width", "2");
				output.RenderBeginTag("img");
				output.RenderEndTag(); // img
				output.RenderEndTag(); // tr
				*/

				// render root node list
				RenderNodes(output, GetChildren(_rootID.ToString()), 0, "");

				// close table
				output.RenderEndTag(); // table
			}
		}
	}
}
