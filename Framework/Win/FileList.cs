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
	/// Summary description for FileList.
	/// </summary>
	public class FileList : System.Windows.Forms.ListView
	{
		// ========================================
		public enum Mode { File, Photo, Video, Audio, Other }
			
		// ========================================
		private string _selectedPath;
		private string[] _subdirs;
		private string[] _files;
		private Mode _mode;

		// ========================================
		private System.Windows.Forms.ImageList icoFiles;
		private System.ComponentModel.IContainer components;

		// ========================================
		public FileList()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			this.View = View.List;
			this.FullRowSelect = true;
			this.HideSelection = false;
			this.SmallImageList = icoFiles;
			this.HeaderStyle = ColumnHeaderStyle.Nonclickable;

			// file details
			_selectedPath = "";
			ChangeMode(Mode.File);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileList));
			this.icoFiles = new System.Windows.Forms.ImageList(this.components);
			// 
			// icoFiles
			// 
			this.icoFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.icoFiles.ImageSize = new System.Drawing.Size(16, 16);
			this.icoFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icoFiles.ImageStream")));
			this.icoFiles.TransparentColor = System.Drawing.Color.Transparent;

		}
		#endregion

		// ========================================
		public string SelectedPath
		{
			get
			{
				// return selected node tag
				if (this.FocusedItem != null)
					return this.FocusedItem.Tag.ToString();
				else
					return "";
			}
			set
			{
				// try to select directory
				if (Directory.Exists(value)) Explore(value);
			}
		}
		
		// ========================================
		private void ResizeColumns()
		{
			if (this.View == View.Details)
			{
				// calculate remaining width
				int width = 0;
				width = -this.Columns[0].Width;
				foreach(ColumnHeader col in this.Columns)
				{
					width += col.Width;
				}
				width = this.Width - width - 22;
				if (width < 75) width = 75;
				this.Columns[0].Width = width;
			}
			else
				this.Columns[0].Width = -1;
		}

		// ========================================
		private void Reset()
		{
			// clear item list
			this.Items.Clear();

			// configure filters
			if ((_files != null) && (_subdirs != null))
			{
				this.BeginUpdate();
				
				// add directories to list
				foreach(string dir in _subdirs)
				{
					DirectoryInfo info = new DirectoryInfo(dir);
					ListViewItem subDir = this.Items.Add(info.Name, 0);
					subDir.Tag = dir + "\\";
				}

				// add file to list
				foreach(string file in _files)
				{
					// create item record
					ListViewItem item = new ListViewItem();
					item.Tag = file;
					item.ImageIndex = FileSystem.FileType(file);
					item.Text = Path.GetFileNameWithoutExtension(file);
					this.Items.Add(item);
				}
				this.EndUpdate();

				// load detail records
				if (this.View == View.Details) ShowDetails();
			}
		}

		// ========================================
		public void ChangeMode(Mode mode)
		{			
			// save mode
			_mode = mode;

			// handle mode specific items
			switch (_mode)
			{
				case Mode.File:
					// create columns
					this.Columns.Clear();
					this.Columns.Add("File Name", 75, HorizontalAlignment.Left);
					this.Columns.Add("Size", 75, HorizontalAlignment.Right);
					this.Columns.Add("File Type", 75, HorizontalAlignment.Left);
					this.Columns.Add("Created", 75, HorizontalAlignment.Left);
					break;
				case Mode.Photo:
					// create columns
					this.Columns.Clear();
					this.Columns.Add("File Name", 75, HorizontalAlignment.Left);
					this.Columns.Add("Size", 75, HorizontalAlignment.Right);
					this.Columns.Add("Photo Type", 75, HorizontalAlignment.Left);
					this.Columns.Add("Date Taken", 75, HorizontalAlignment.Left);
					break;
				case Mode.Video:
					// create columns
					this.Columns.Clear();
					this.Columns.Add("File Name", 75, HorizontalAlignment.Left);
					this.Columns.Add("Size", 75, HorizontalAlignment.Right);
					this.Columns.Add("Video Type", 75, HorizontalAlignment.Left);
					this.Columns.Add("Created", 75, HorizontalAlignment.Left);
					break;
				case Mode.Audio:
					// create columns
					this.Columns.Clear();
					this.Columns.Add("File Name", 75, HorizontalAlignment.Left);
					this.Columns.Add("Size", 75, HorizontalAlignment.Right);
					this.Columns.Add("Audio Type", 75, HorizontalAlignment.Left);
					this.Columns.Add("Created", 75, HorizontalAlignment.Left);
					break;
			}

			// resize columns
			ResizeColumns();

			// reset display
			Reset();
		}

		// ========================================
		public void ShowDetails()
		{
			// resize columns
			ResizeColumns();

			// add detailed information
			this.BeginUpdate();
			foreach(ListViewItem item in this.Items)
			{
				// check details (if not folder)
				if ((item.ImageIndex > 0) && (item.SubItems.Count == 1))
				{
					// get file info
					string file = item.Tag.ToString();
					FileInfo info = new FileInfo(file);
				
					// add size
					decimal size = info.Length;
					if (size < 1048576)
						item.SubItems.Add(String.Format("{0:####,##0.0 KB}", size / 1024));
					else if (size < 1073741824)
						item.SubItems.Add(String.Format("{0:####,###0.0 MB}", size / 1048576));
					else
						item.SubItems.Add(String.Format("{0:####,###0.0 GB}", size / 1073741824));
				
					// add item specific column
					item.SubItems.Add(Path.GetExtension(file).TrimStart('.').ToLower());

					// add created timestamp
					item.SubItems.Add(info.CreationTime.ToShortDateString() + " " + info.CreationTime.ToShortTimeString());
				}
			}
			this.EndUpdate();
		}

		// ========================================
		public void Explore(string path)
		{
			// check root path
			if (Directory.Exists(path))
			{
				// clear files list
				_selectedPath = path;
				_files = Directory.GetFiles(_selectedPath);
				_subdirs = Directory.GetDirectories(_selectedPath);
			}
			else
			{
				_selectedPath = "";
				_files = _subdirs = null;
			}

			// add items
			Reset();
		}

		// ========================================
		protected override void OnDoubleClick(EventArgs e)
		{
			// check selected item type			
			if (this.SelectedItems.Count == 1)
			{
				ListViewItem selected = this.SelectedItems[0];
				if (selected.ImageIndex == 0) // Directory
				{
					Explore(selected.Tag.ToString()); // Browse directory
				}
				else
				{
					MessageBox.Show(selected.Tag.ToString(), "File Properties"); // Display properties
				}
			}

			// execute base object call
			base.OnDoubleClick (e);
		}

		// ========================================
		protected override void OnResize(EventArgs e)
		{
			// resize columns
			ResizeColumns();

			// execute base object call
			base.OnResize (e);
		}
	}
}
