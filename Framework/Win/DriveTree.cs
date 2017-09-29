using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;

using DesignedNet.Framework.Svc;

namespace DesignedNet.Framework.Win
{
	/// <summary>
	/// Summary description for DriveTree.
	/// </summary>
	public class DriveTree : System.Windows.Forms.TreeView
	{
		// ========================================
		private ContextMenu _contextMenu;
		private TreeNode _previousNode;
		private TreeNode _currentNode;
		private TreeNode _contextNode;
		//private bool _hideSystem = true;
		//private bool _hideHidden = true;
		private bool _contextEnabled = false;
		private System.Windows.Forms.ImageList icoTreeView;
		private System.ComponentModel.IContainer components;

		// ========================================
		public DriveTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			this.Sorted = true;
			this.ShowLines = true;
			this.LabelEdit = false;
			this.AllowDrop = false;
			this.CheckBoxes = false;
			this.HotTracking = true;
			this.ShowPlusMinus = true;
			this.FullRowSelect = true;
			this.HideSelection = false;
			this.ShowRootLines = false;
			this.ImageList = icoTreeView;

			// create context menu
			_contextMenu = new ContextMenu();
			_contextMenu.MenuItems.Add("Properties", new EventHandler(ContextProperties));
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DriveTree));
			this.icoTreeView = new System.Windows.Forms.ImageList(this.components);
			// 
			// icoTreeView
			// 
			this.icoTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.icoTreeView.ImageSize = new System.Drawing.Size(16, 16);
			this.icoTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icoTreeView.ImageStream")));
			this.icoTreeView.TransparentColor = System.Drawing.Color.Transparent;

		}
		#endregion

		// ========================================
		public string SelectedPath
		{
			get
			{
				// return selected node tag
				if (this.SelectedNode != null)
					return this.SelectedNode.Tag.ToString();
				else
					return "";
			}
			set { Explore(value); }
		}

		// ========================================
		public void Explore()
		{
			// clear node list
			this.BeginUpdate();
			this.Nodes.Clear();
			_previousNode = _currentNode = _contextNode = null;
			foreach(string drive in Environment.GetLogicalDrives())
			{
				// cache drive properties
				PathCache cache = FileSystem.CacheRoot(drive);
				TreeNode node = new TreeNode(cache.Name, cache.Type, cache.Type);
				node.Tag = cache;
				this.Nodes.Add(node); 
			}
			this.EndUpdate();
		}

		// ========================================
		public void Explore(string path)
		{
			// find root
			TreeNode node = null;
			TreeNode root = FindRoot(path);
			if (root != null)
			{
				// attempt find
				node = FindNode(path, root);
				if (node == null)
				{
					// load root path
					ExploreNode(root, 1);
					node = root; // start

					// load selected child paths
					string[] dirs = path.Split('\\'); // skip first
					for(int index=1;index<dirs.Length;index++)
					{
						// hacked enumerator
						foreach(TreeNode child in node.Nodes)
						{
							if (child.Text == dirs[index])
							{
								// explore children
								ExploreNode(child, 1);

								// tranverse path
								node = child;

								// quit child
								break;
							}
						}
					}
				}

				// display node
				if (node != null) node.EnsureVisible();
			}
			
			// check success
			this.SelectedNode = node;
		}

		// ========================================
		protected void ExploreNode(TreeNode node, int depth)
		{
			// check node cache
			PathCache cache = FileSystem.CachePath(node.Tag);

			// check path cache
			int count = node.Nodes.Count;
			long length = cache.GetSubdirs().Length;
			if (length > 0)
			{
				// check tree state
				if (count == 0)
				{						
					this.BeginUpdate();
					foreach(PathCache path in cache.Subdirs)
					{
						// check path type
						if (!path.IsSystem && !path.IsHidden)
						{
							// add missing nodes
							node.Nodes.Add(CreateNode(path));
						}
					}
					this.EndUpdate();
				}
				else if (count != length)
				{
					// add missing children
					int index = 0;
					TreeNode current;
					foreach(PathCache path in cache.Subdirs)
					{
						// check path type
						if (!path.IsSystem && !path.IsHidden)
						{
							// check node index
							current = node.Nodes[index];
							if (current != null)
							{
								int compare = current.Text.CompareTo(path.Name);
								if (compare > 0) // node greater
								{
									// do insert
									this.BeginUpdate();
									node.Nodes.Insert(index, CreateNode(path));
									index++; // insert space
									this.EndUpdate();
								}
								// increment index
								index++; 
							}
							else
							{
								// add extra
								this.BeginUpdate();
								node.Nodes.Add(CreateNode(path));
								index = node.Nodes.Count + 1;
								this.EndUpdate();
							}
						}
					}
				}
			}

			// check depth
			if (depth > 0)
			{
				// check childrent
				foreach(TreeNode child in node.Nodes)
				{
					ExploreNode(child, depth-1);
				}
			}
		}

		// ========================================
		protected TreeNode CreateNode(PathCache cache)
		{
			TreeNode node = new TreeNode();
			node.SelectedImageIndex = cache.Type + 1;
			node.ImageIndex = cache.Type;
			node.Text = cache.Name;
			node.Tag = cache;
			return node;
		}

		// ========================================
		protected TreeNode FindRoot(string path)
		{
			if (Directory.Exists(path))
			{
				string rootPath = Path.GetPathRoot(path);
				foreach(TreeNode root in this.Nodes)
				{
					PathCache cache = FileSystem.CachePath(root.Tag);
					if (rootPath == Path.GetPathRoot(cache.Path)) return root;
				}
			}
			return null;
		}

		// ========================================
		protected TreeNode FindNode(string path)
		{
			TreeNode root = FindRoot(path);
			if (root != null)
				return FindNode(path, root);
			else
				return null;
		}

		// ========================================
		protected TreeNode FindNode(string path, TreeNode parent)
		{			
			PathCache cache = FileSystem.CachePath(parent.Tag);
			if (path == cache.Path)
				return parent; // self
			else // child
			{
				foreach(TreeNode child in parent.Nodes)
				{
					cache = FileSystem.CachePath(child.Tag);
					if (path == cache.Path)
						return child;
					else if (path.StartsWith(cache.Path + "\\"))
						return FindNode(path, child);
				}
			}
			// not found
			return null;
		}

		// ========================================
		protected override void OnCreateControl()
		{
			// detafult to drive list
			this.Explore();

			// execute base object call
			base.OnCreateControl ();
		}

		// ========================================
		protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
		{
			// cancel attempt to edit
			e.CancelEdit = true;

			// execute base object call
			base.OnBeforeLabelEdit (e);
		}


		// ========================================
		protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
		{
			// check root node
			if ((e.Node.Parent == null) && (e.Node.Nodes.Count == 0))
			{
				// force load root cache
				try { ExploreNode(e.Node, 0); }
				catch (Exception ex) { MessageBox.Show(ex.Message); }
			}

			// execute base object call
			base.OnBeforeSelect (e);
		}

		// ========================================
		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			// auto expand selected node
			if (e.Action == TreeViewAction.ByMouse)
			{
				this.BeginUpdate();
				// auto collapse previous node
				if ((_currentNode != null) && (_currentNode.Parent == e.Node.Parent)) _currentNode.Collapse();

				// update current node
				_currentNode = e.Node;
				_previousNode = _currentNode;

				// auto expand current node
				if ((!_currentNode.IsExpanded) && (_currentNode.Nodes.Count > 0)) _currentNode.Expand();
				this.EndUpdate();
			}

			// execute base object call
			base.OnAfterSelect (e);
		}

		// ========================================
		protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
		{
			// expand parent and children
			ExploreNode(e.Node, 1);

			// execute base object call
			base.OnBeforeExpand (e);
		}

		// ========================================
		protected override void OnMouseDown(MouseEventArgs e)
		{
			// update contex menu node
			if ((e.Button == MouseButtons.Right) && (_contextEnabled == true))
			{
				_contextNode = this.GetNodeAt(e.X, e.Y);
				if (_contextNode != null)
					this.ContextMenu = _contextMenu;
			}
			else // disable context menu
				this.ContextMenu = null;

			// execute base object call
			base.OnMouseDown (e);
		}
		
		// ========================================
		protected override void OnMouseUp(MouseEventArgs e)
		{
			// update contex menu node
			if ((e.Button == MouseButtons.Right) && (_contextEnabled == true))
			{
				_contextNode = this.GetNodeAt(e.X, e.Y);
				if (_contextNode != null)
					this.ContextMenu = _contextMenu;
			}
			else // disable context menu
				this.ContextMenu = null;

			// execute base object call
			base.OnMouseUp (e);
		}

		// ========================================
		protected void ContextProperties(object sender, EventArgs e)
		{
			MessageBox.Show(_contextNode.Tag.ToString());
		}
	}
}
