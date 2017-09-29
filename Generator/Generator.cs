using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.CodeDom;

using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DesignedNet.Generator.Win
{
	/// <summary>
	/// Summary description for Generator.
	/// </summary>
	public class Generator : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private bool _isSql = true;	// set to determin of database is SQL or Access
		private bool _doDal = false;
		private bool _doBiz = false;
		private bool _doSql = false;
		private bool _doTxt = false;
		private bool _doWeb = false;
		private bool _doWin = false;
		private bool _doXml = false;

		//========================================================
		#region Form Controls
		private System.Windows.Forms.TextBox txtConnection;
		private System.Windows.Forms.Label lblConnection;
		private System.Windows.Forms.Button btnRefreshDatabaseObjects;
		private System.Windows.Forms.ListView listTables;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ListBox listStatus;
		private System.Windows.Forms.Button btnSelectNone;
		private System.Windows.Forms.Button btnSelectAll;
		private System.Windows.Forms.Label lblDBObjects;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox txtTemplatePath;
		private System.Windows.Forms.OpenFileDialog findDirectory;
		private System.Windows.Forms.Button btnFindTemplatesPath;
		private System.Windows.Forms.Button btnFindOutputPath;
		private System.Windows.Forms.TextBox txtOutputPath;
		private System.Windows.Forms.OpenFileDialog findAccessDB;
		private System.Windows.Forms.Button btnSelectAccessDB;
		private System.Windows.Forms.DataGrid dgTableSchema;
		private System.Windows.Forms.LinkLabel linkTemplatesPath;
		private System.Windows.Forms.LinkLabel linkOutputPath;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.CheckedListBox selFramework;
		private System.Windows.Forms.Button cmdClear;
		private System.Windows.Forms.Label lblProjectName;
		private System.Windows.Forms.Label lblRootNamespace;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.TextBox txtRootNamespace;
		private System.Windows.Forms.OpenFileDialog findProjectFile;
		private System.Windows.Forms.SaveFileDialog saveProjectFile;
		private System.Windows.Forms.Button cmdLoad;
		#endregion
		//========================================================

		public Generator()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		//========================================================
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Generator));
			this.txtConnection = new System.Windows.Forms.TextBox();
			this.lblConnection = new System.Windows.Forms.Label();
			this.btnRefreshDatabaseObjects = new System.Windows.Forms.Button();
			this.listTables = new System.Windows.Forms.ListView();
			this.lblDBObjects = new System.Windows.Forms.Label();
			this.txtOutputPath = new System.Windows.Forms.TextBox();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.btnSelectNone = new System.Windows.Forms.Button();
			this.listStatus = new System.Windows.Forms.ListBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.txtTemplatePath = new System.Windows.Forms.TextBox();
			this.findDirectory = new System.Windows.Forms.OpenFileDialog();
			this.btnFindTemplatesPath = new System.Windows.Forms.Button();
			this.btnFindOutputPath = new System.Windows.Forms.Button();
			this.btnSelectAccessDB = new System.Windows.Forms.Button();
			this.findAccessDB = new System.Windows.Forms.OpenFileDialog();
			this.dgTableSchema = new System.Windows.Forms.DataGrid();
			this.linkTemplatesPath = new System.Windows.Forms.LinkLabel();
			this.linkOutputPath = new System.Windows.Forms.LinkLabel();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.lblProjectName = new System.Windows.Forms.Label();
			this.selFramework = new System.Windows.Forms.CheckedListBox();
			this.cmdClear = new System.Windows.Forms.Button();
			this.txtRootNamespace = new System.Windows.Forms.TextBox();
			this.lblRootNamespace = new System.Windows.Forms.Label();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.findProjectFile = new System.Windows.Forms.OpenFileDialog();
			this.saveProjectFile = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dgTableSchema)).BeginInit();
			this.SuspendLayout();
			// 
			// txtConnection
			// 
			this.txtConnection.Location = new System.Drawing.Point(24, 120);
			this.txtConnection.Name = "txtConnection";
			this.txtConnection.Size = new System.Drawing.Size(640, 20);
			this.txtConnection.TabIndex = 8;
			this.txtConnection.Text = "Provider=SQLOLEDB.1;Persist Security Info=False;Data Source= (local); User ID= db" +
				"DS ; Password= sdBD ;Initial Catalog= master ;";
			// 
			// lblConnection
			// 
			this.lblConnection.Location = new System.Drawing.Point(16, 104);
			this.lblConnection.Name = "lblConnection";
			this.lblConnection.Size = new System.Drawing.Size(152, 23);
			this.lblConnection.TabIndex = 5;
			this.lblConnection.Text = "Connection String:";
			// 
			// btnRefreshDatabaseObjects
			// 
			this.btnRefreshDatabaseObjects.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRefreshDatabaseObjects.Location = new System.Drawing.Point(288, 152);
			this.btnRefreshDatabaseObjects.Name = "btnRefreshDatabaseObjects";
			this.btnRefreshDatabaseObjects.Size = new System.Drawing.Size(56, 20);
			this.btnRefreshDatabaseObjects.TabIndex = 10;
			this.btnRefreshDatabaseObjects.Text = "Refresh";
			this.btnRefreshDatabaseObjects.Click += new System.EventHandler(this.btnRefreshDatabaseObjects_Click);
			// 
			// listTables
			// 
			this.listTables.CheckBoxes = true;
			this.listTables.Location = new System.Drawing.Point(24, 176);
			this.listTables.Name = "listTables";
			this.listTables.Size = new System.Drawing.Size(448, 184);
			this.listTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listTables.TabIndex = 13;
			this.listTables.View = System.Windows.Forms.View.List;
			this.listTables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listTables_ItemCheck);
			// 
			// lblDBObjects
			// 
			this.lblDBObjects.AutoSize = true;
			this.lblDBObjects.Location = new System.Drawing.Point(16, 160);
			this.lblDBObjects.Name = "lblDBObjects";
			this.lblDBObjects.Size = new System.Drawing.Size(97, 16);
			this.lblDBObjects.TabIndex = 24;
			this.lblDBObjects.Text = "Database Objects:";
			// 
			// txtOutputPath
			// 
			this.txtOutputPath.Location = new System.Drawing.Point(288, 24);
			this.txtOutputPath.Name = "txtOutputPath";
			this.txtOutputPath.Size = new System.Drawing.Size(376, 20);
			this.txtOutputPath.TabIndex = 2;
			this.txtOutputPath.Text = "D:\\Framework\\Output\\";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(680, 296);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(80, 24);
			this.btnGenerate.TabIndex = 15;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(680, 328);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(80, 24);
			this.btnExit.TabIndex = 16;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectAll.Location = new System.Drawing.Point(352, 152);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(56, 20);
			this.btnSelectAll.TabIndex = 11;
			this.btnSelectAll.Text = "All";
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// btnSelectNone
			// 
			this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectNone.Location = new System.Drawing.Point(416, 152);
			this.btnSelectNone.Name = "btnSelectNone";
			this.btnSelectNone.Size = new System.Drawing.Size(56, 20);
			this.btnSelectNone.TabIndex = 12;
			this.btnSelectNone.Text = "None";
			this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
			// 
			// listStatus
			// 
			this.listStatus.Location = new System.Drawing.Point(488, 176);
			this.listStatus.Name = "listStatus";
			this.listStatus.Size = new System.Drawing.Size(176, 186);
			this.listStatus.TabIndex = 14;
			this.listStatus.TabStop = false;
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(480, 160);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.TabIndex = 44;
			this.lblStatus.Text = "Console Status:";
			// 
			// txtTemplatePath
			// 
			this.txtTemplatePath.Location = new System.Drawing.Point(288, 72);
			this.txtTemplatePath.Name = "txtTemplatePath";
			this.txtTemplatePath.Size = new System.Drawing.Size(376, 20);
			this.txtTemplatePath.TabIndex = 5;
			this.txtTemplatePath.Text = "D:\\Framework\\Generator\\Templates\\";
			// 
			// findDirectory
			// 
			this.findDirectory.CheckFileExists = false;
			this.findDirectory.Title = "Select Folder";
			this.findDirectory.ValidateNames = false;
			// 
			// btnFindTemplatesPath
			// 
			this.btnFindTemplatesPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnFindTemplatesPath.Location = new System.Drawing.Point(672, 72);
			this.btnFindTemplatesPath.Name = "btnFindTemplatesPath";
			this.btnFindTemplatesPath.Size = new System.Drawing.Size(96, 20);
			this.btnFindTemplatesPath.TabIndex = 7;
			this.btnFindTemplatesPath.Text = "Select Folder ...";
			this.btnFindTemplatesPath.Click += new System.EventHandler(this.btnFindTemplatesPath_Click);
			// 
			// btnFindOutputPath
			// 
			this.btnFindOutputPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnFindOutputPath.Location = new System.Drawing.Point(672, 24);
			this.btnFindOutputPath.Name = "btnFindOutputPath";
			this.btnFindOutputPath.Size = new System.Drawing.Size(96, 20);
			this.btnFindOutputPath.TabIndex = 4;
			this.btnFindOutputPath.Text = "Select Folder ...";
			this.btnFindOutputPath.Click += new System.EventHandler(this.btnFindOutputPath_Click);
			// 
			// btnSelectAccessDB
			// 
			this.btnSelectAccessDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectAccessDB.Location = new System.Drawing.Point(672, 120);
			this.btnSelectAccessDB.Name = "btnSelectAccessDB";
			this.btnSelectAccessDB.Size = new System.Drawing.Size(96, 20);
			this.btnSelectAccessDB.TabIndex = 9;
			this.btnSelectAccessDB.Text = "Select MDB...";
			this.btnSelectAccessDB.Click += new System.EventHandler(this.btnSelectAccessDB_Click);
			// 
			// findAccessDB
			// 
			this.findAccessDB.DefaultExt = "mbd";
			this.findAccessDB.Filter = "Access DB|*.mdb";
			this.findAccessDB.InitialDirectory = "D:\\";
			this.findAccessDB.Title = "Select Access Database File";
			// 
			// dgTableSchema
			// 
			this.dgTableSchema.DataMember = "";
			this.dgTableSchema.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTableSchema.Location = new System.Drawing.Point(24, 368);
			this.dgTableSchema.Name = "dgTableSchema";
			this.dgTableSchema.ReadOnly = true;
			this.dgTableSchema.Size = new System.Drawing.Size(744, 160);
			this.dgTableSchema.TabIndex = 26;
			this.dgTableSchema.TabStop = false;
			// 
			// linkTemplatesPath
			// 
			this.linkTemplatesPath.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkTemplatesPath.Location = new System.Drawing.Point(280, 56);
			this.linkTemplatesPath.Name = "linkTemplatesPath";
			this.linkTemplatesPath.Size = new System.Drawing.Size(120, 16);
			this.linkTemplatesPath.TabIndex = 6;
			this.linkTemplatesPath.TabStop = true;
			this.linkTemplatesPath.Text = "Templates Path ...";
			this.linkTemplatesPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTemplatesPath_LinkClicked);
			// 
			// linkOutputPath
			// 
			this.linkOutputPath.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkOutputPath.Location = new System.Drawing.Point(280, 8);
			this.linkOutputPath.Name = "linkOutputPath";
			this.linkOutputPath.Size = new System.Drawing.Size(120, 16);
			this.linkOutputPath.TabIndex = 3;
			this.linkOutputPath.TabStop = true;
			this.linkOutputPath.Text = "Output Path ...";
			this.linkOutputPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOutputPath_LinkClicked);
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(24, 24);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(120, 20);
			this.txtProjectName.TabIndex = 1;
			this.txtProjectName.Text = "DesignedNet";
			// 
			// lblProjectName
			// 
			this.lblProjectName.Location = new System.Drawing.Point(16, 8);
			this.lblProjectName.Name = "lblProjectName";
			this.lblProjectName.Size = new System.Drawing.Size(100, 16);
			this.lblProjectName.TabIndex = 62;
			this.lblProjectName.Text = "Project Name:";
			// 
			// selFramework
			// 
			this.selFramework.Items.AddRange(new object[] {
															  "Biz",
															  "Dal",
															  "Sql",
															  "Txt",
															  "Web",
															  "Win",
															  "Xml"});
			this.selFramework.Location = new System.Drawing.Point(680, 176);
			this.selFramework.Name = "selFramework";
			this.selFramework.Size = new System.Drawing.Size(80, 109);
			this.selFramework.TabIndex = 14;
			// 
			// cmdClear
			// 
			this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdClear.Location = new System.Drawing.Point(608, 152);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(56, 20);
			this.cmdClear.TabIndex = 13;
			this.cmdClear.Text = "Clear";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// txtRootNamespace
			// 
			this.txtRootNamespace.Location = new System.Drawing.Point(24, 72);
			this.txtRootNamespace.Name = "txtRootNamespace";
			this.txtRootNamespace.Size = new System.Drawing.Size(248, 20);
			this.txtRootNamespace.TabIndex = 63;
			this.txtRootNamespace.Text = "DesignedNet.Output";
			// 
			// lblRootNamespace
			// 
			this.lblRootNamespace.Location = new System.Drawing.Point(16, 56);
			this.lblRootNamespace.Name = "lblRootNamespace";
			this.lblRootNamespace.Size = new System.Drawing.Size(100, 16);
			this.lblRootNamespace.TabIndex = 64;
			this.lblRootNamespace.Text = "Root Namespace:";
			// 
			// cmdSave
			// 
			this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdSave.Location = new System.Drawing.Point(152, 24);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(56, 20);
			this.cmdSave.TabIndex = 65;
			this.cmdSave.Text = "Save";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// cmdLoad
			// 
			this.cmdLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdLoad.Location = new System.Drawing.Point(216, 24);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.Size = new System.Drawing.Size(56, 20);
			this.cmdLoad.TabIndex = 66;
			this.cmdLoad.Text = "Load";
			// 
			// findProjectFile
			// 
			this.findProjectFile.CheckFileExists = false;
			this.findProjectFile.DefaultExt = "meta";
			this.findProjectFile.Filter = "MetaStudio|* .met";
			this.findProjectFile.InitialDirectory = "D:\\";
			this.findProjectFile.Title = "Select MetaStudio Project File";
			// 
			// saveProjectFile
			// 
			this.saveProjectFile.DefaultExt = "meta";
			this.saveProjectFile.Filter = "MetaStudio|* .meta";
			this.saveProjectFile.InitialDirectory = "D:\\";
			this.saveProjectFile.Title = "Select MetaStudio Project File";
			// 
			// MainForm
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(786, 547);
			this.Controls.Add(this.cmdLoad);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.lblRootNamespace);
			this.Controls.Add(this.txtRootNamespace);
			this.Controls.Add(this.cmdClear);
			this.Controls.Add(this.selFramework);
			this.Controls.Add(this.lblProjectName);
			this.Controls.Add(this.txtProjectName);
			this.Controls.Add(this.linkOutputPath);
			this.Controls.Add(this.linkTemplatesPath);
			this.Controls.Add(this.dgTableSchema);
			this.Controls.Add(this.btnSelectAccessDB);
			this.Controls.Add(this.btnFindOutputPath);
			this.Controls.Add(this.btnFindTemplatesPath);
			this.Controls.Add(this.txtTemplatePath);
			this.Controls.Add(this.listStatus);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSelectNone);
			this.Controls.Add(this.btnSelectAll);
			this.Controls.Add(this.lblDBObjects);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.txtOutputPath);
			this.Controls.Add(this.listTables);
			this.Controls.Add(this.btnRefreshDatabaseObjects);
			this.Controls.Add(this.txtConnection);
			this.Controls.Add(this.lblConnection);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(792, 576);
			this.MinimumSize = new System.Drawing.Size(792, 576);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DesignedNet.Generation.MetaStudio.Code";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgTableSchema)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		//========================================================

		[STAThread]
		static void Main() 
		{
			Application.Run(new DesignedNet.Generator.Win.Generator());
		}


		//========================================================
		#region SQL data type codes
		/*
			xtype name             
			----- ---------------- 
			34    image
			35    text
			36    uniqueidentifier
			48    tinyint
			52    smallint
			56    int
			58    smalldatetime
			59    real
			60    money
			61    datetime
			62    float
			98    sql_variant
			99    ntext
			104   bit
			106   decimal
			108   numeric
			122   smallmoney
			127   bigint
			165   varbinary
			167   varchar
			167   tid
			167   id
			173   binary
			175   char
			175   empid
			189   timestamp
			231   sysname
			231   nvarchar
			239   nchar
			*/
		#endregion
		//========================================================

		//========================================================
		private void RefreshDatabaseObjects()
		{
			OleDbConnection cn = new OleDbConnection(txtConnection.Text);
			cn.Open();

			DataTable dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
			dgTableSchema.CaptionText = "OleDb Table List";
			dgTableSchema.DataSource = dt;

			listTables.Items.Clear();

			foreach (DataRow row in dt.Rows)
			{
				string label = "";

				label += row["TABLE_NAME"].ToString();

				listTables.Items.Add( label );
			}
			listStatus.Items.Add("- Database Objects Updated");

			dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Provider_Types, new object[] {null});
			dgTableSchema.CaptionText = "OleDb Supported Data Types";
			dgTableSchema.DataSource = dt;
		}

		//========================================================
		private string GetDirectoryPath(string startPath)
		{
			int lastSlash;
			findDirectory.InitialDirectory = startPath;
			findDirectory.FileName = "{Ignored}";
			findDirectory.ShowDialog();
			lastSlash = findDirectory.FileName.LastIndexOf("\\");
			if (lastSlash > 0)
				return findDirectory.FileName.Substring(0, lastSlash);
			else
				return "";
		}

		//========================================================
		private XmlDocument GetEntitySchema(DataSet ds, string tableName)
		{
			Stream memStream = new MemoryStream();
			XmlTextWriter xmlWriter = new XmlTextWriter(memStream, System.Text.Encoding.UTF8);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Entity");

			xmlWriter.WriteAttributeString("name", tableName);
			xmlWriter.WriteAttributeString("table", tableName);
			xmlWriter.WriteAttributeString("varName", LName(tableName));
			xmlWriter.WriteAttributeString("objName", UName(tableName));
			
			DataView dv = new DataView(ds.Tables[tableName], "", "ORDINAL_POSITION", DataViewRowState.OriginalRows);
			foreach (DataRowView row in dv)
			{
				string columnName = row["COLUMN_NAME"].ToString();
				
				xmlWriter.WriteStartElement("Property");

				xmlWriter.WriteAttributeString("name", columnName);
				xmlWriter.WriteAttributeString("varName", LName(columnName));
				xmlWriter.WriteAttributeString("objName", UName(columnName ));
				xmlWriter.WriteAttributeString("type", row["DATA_TYPE"].ToString());
				xmlWriter.WriteAttributeString("length", row["CHARACTER_MAXIMUM_LENGTH"].ToString());
				xmlWriter.WriteAttributeString("isFixed", BitMask(Convert.ToUInt32(row["COLUMN_FLAGS"]), 0x10)); // DBCOLUMNFLAGS_ISFIXEDLENGTH = 0x10
				xmlWriter.WriteAttributeString("isNullable", BitMask(Convert.ToUInt32(row["COLUMN_FLAGS"]), 0x20)); // DBCOLUMNFLAGS_ISNULLABLE = 0x20
				xmlWriter.WriteAttributeString("isLong", BitMask(Convert.ToUInt32(row["COLUMN_FLAGS"]), 0x80)); //DBCOLUMNFLAGS_ISLONG = 0x80
				
				if (row["ORDINAL_POSITION"].ToString() == "1")
					xmlWriter.WriteAttributeString("pk", "1");
				else
					xmlWriter.WriteAttributeString("pk", "0");

				// determin FK information for all known relationships
				bool isFk = false;
				foreach(DataRow relationship in ds.Tables["ForeignKeys"].Rows)
				{
					// if this table and this column has a relationship
					if ((relationship["FK_TABLE_NAME"].ToString() == tableName) & (relationship["FK_COLUMN_NAME"].ToString() == columnName))
					{
						isFk = true;
						
						xmlWriter.WriteAttributeString("fk", "1");
						xmlWriter.WriteAttributeString("fkName", relationship["PK_TABLE_NAME"].ToString());
						xmlWriter.WriteAttributeString("fkPkName", relationship["PK_COLUMN_NAME"].ToString());
						xmlWriter.WriteAttributeString("fkVarName", LName(relationship["PK_TABLE_NAME"].ToString()));
						xmlWriter.WriteAttributeString("fkObjName", UName(relationship["PK_TABLE_NAME"].ToString()));
					}
				}
				
				// if not a FK then mark as such
				if (!(isFk)) xmlWriter.WriteAttributeString("fk", "0");

				xmlWriter.WriteEndElement(); // Property
			}

			xmlWriter.WriteEndElement(); // Entity
			xmlWriter.WriteEndDocument();			
			xmlWriter.Flush();

			XmlDocument xmlEntitySchema = new XmlDocument();

			memStream.Position = 0;
			xmlEntitySchema.Load(memStream);
			memStream.Close();

			//MessageBox.Show(xmlEntitySchema.OuterXml);

			return xmlEntitySchema;
		}

		//========================================================
		private string LName(string val)
		{
			return (val.Substring(0, 1).ToLower() + val.Substring(1));
		}

		//========================================================
		private string UName(string val)
		{
			return (val.Substring(0, 1).ToUpper() + val.Substring(1));
		}

		//========================================================
		private string BitMask(uint val, uint mask)
		{
			//if (mask == 0x20) MessageBox.Show(Convert.ToString(val) + " = " + Convert.ToString(val & mask) + " is " + Convert.ToString((val & mask) == mask));
			if ((val & mask) == mask)
				return "1";
			else
				return "0";
		}
		
		//========================================================
		private void GenerateCode()
		{
			// Verify that output folders exist
			CheckDirectories();

			// Build full outpath
			string outputPath = txtOutputPath.Text + txtProjectName.Text + "\\";

			// Create dataset to hold all data
			DataSet ds = new DataSet("DatabaseSchema");

			// Get primary/foreign key relationships
			ds.Tables.Add(GetRelationshipSchema());

			foreach (ListViewItem item in listTables.Items)
			{
				if (item.Checked)
				{
					string tableName = item.Text.Replace( "Table - ", "" );

					// Add schema for each table selected
					ds.Tables.Add(GetTableSchema(tableName));

					if (true)
					{
						XmlDocument xmlSchema = GetEntitySchema(ds, tableName);

						// Xml Entity Schema
						WriteFile(xmlSchema.OuterXml, outputPath + "Xml\\" + tableName + ".xml", false);

						// Txt Entity Schema
						TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Txt\@Entity@.txt.xslt", outputPath + "Txt\\" + tableName + ".txt", false );

						if (_isSql)
						{
							// Business Logic Layer
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Biz\Biz@Entity@.cs.xslt", outputPath + "Biz\\Biz" + tableName + ".cs", false );

							// Sql Data Access Layer
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Dal\Dal@Entity@.cs.xslt", outputPath + "Dal\\Dal" + tableName + ".cs", false );

							// List Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_List.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", false);

							// Report Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Report.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// Select Single Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Select.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// Insert Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Insert.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// Update Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Update.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// Delete Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Delete.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// Exists Stored Procedure
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_Exists.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true );

							// List By FK Stored Procedure(s)
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Sql\@Entity@_ListByFk.sql.xslt", outputPath + "Sql\\" + tableName + "_Verbs.sql", true);

							// List Xml Stored Procedure
							//TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"StoredProcs\@Entity@_XmlVerbs.sql.xslt", outputPath + "Objects\\" + tableName + "_ListXml.sql", false );

							// Select Single Xml Stored Procedure
							//TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"StoredProcs\@Entity@_XmlVerbs.sql.xslt", outputPath + "Objects\\" + tableName + "_SelectXml.sql", true );
						}
						else
						{
							// Business Logic Layer
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Biz@Entity@.cs.xslt", outputPath + "Biz\\Biz" + tableName + ".cs", false );

							// OleDb Data Access Layer
							TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Dal\Ole@Entity@.cs.xslt", outputPath + "Dal\\Ole" + tableName + ".cs", false );
						}

						// Entity List Control Class
						TransformIntoHtml(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@List.ascx.xslt", outputPath + "Web\\Controls\\" + tableName + "List.ascx", false );
						TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@List.ascx.cs.xslt", outputPath + "Web\\Controls\\" + tableName + "List.ascx.cs", false );

						// Entity View Control Class
						TransformIntoHtml(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@View.ascx.xslt", outputPath + "Web\\Controls\\" + tableName + "View.ascx", false );
						TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@View.ascx.cs.xslt", outputPath + "Web\\Controls\\" + tableName + "View.ascx.cs", false );

						// Entity Edit Control Class
						TransformIntoHtml(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@Edit.ascx.xslt", outputPath + "Web\\Controls\\" + tableName + "Edit.ascx", false );
						TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Web\Controls\@Entity@Edit.ascx.cs.xslt", outputPath + "Web\\Controls\\" + tableName + "Edit.ascx.cs", false );

						// Entity Managment Page Interface Class
						TransformIntoHtml(xmlSchema, txtTemplatePath.Text + @"Web\Manage@Entity@.aspx.xslt", outputPath + "Web\\Manage" + tableName + ".aspx", false );
						TransformIntoFile(xmlSchema, txtTemplatePath.Text + @"Web\Manage@Entity@.aspx.cs.xslt", outputPath + "Web\\Manage" + tableName + ".aspx.cs", false );
					}

					listStatus.Items.Add("- Generated table: " + tableName );
					listStatus.Refresh();
				}
			}
		}

		//========================================================
		private void TransformIntoFile(XmlDocument xml, string xsltFile, string outputFile, bool append )
		{
			StreamWriter fs = new StreamWriter(outputFile, append);

			try 
			{
				XslTransform xslt = new XslTransform();
				xslt.Load(xsltFile);

				XsltArgumentList args = new XsltArgumentList();
				args.Clear();
				args.AddParam("RootNamespace", "", txtRootNamespace.Text);
				args.AddParam("WithForXml", "", 0);
				args.AddParam("Today", "", DateTime.Today);
				
				xslt.Transform(xml.DocumentElement, args, fs, null);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + " : " + exc.Source);
			}

			fs.Flush();
			fs.Close();
		}

		//========================================================
		private void TransformIntoHtml(XmlDocument xml, string xsltFile, string outputFile, bool append )
		{
			//StreamWriter fs = new StreamWriter(outputFile, append);

			try 
			{
				XslTransform xslt = new XslTransform();
				//XmlTextWriter writer = new XmlTextWriter(fs);	
				StringBuilder sb = new StringBuilder();
				StringWriter sw = new StringWriter(sb);
				XmlTextWriter tw = new XmlTextWriter(sw);
				
				xslt.Load(xsltFile);

				XsltArgumentList args = new XsltArgumentList();
				args.Clear();
				args.AddParam("RootNamespace", "", txtRootNamespace.Text);
				args.AddParam("WithForXml", "", 0);
				args.AddParam("Today", "", DateTime.Today);	
			
				//xslt.Transform(xml.DocumentElement, args, writer);
				//xslt.Transform(xml.DocumentElement, args, sw, null);
				xslt.Transform(xml.DocumentElement, args, tw, null);

				//WriteFile(sw.ToString(), outputFile, append);
				char qoute = (char)34;
				string output = sw.ToString();
				output = output.Replace("&lt;", "<");
				output = output.Replace("&gt;", ">");
				output = output.Replace(" xmlns:asp=" + qoute.ToString() + "http://asp.net" + qoute.ToString(), "");
				WriteFile(output, outputFile, append);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + " : " + exc.Source);
			}

			//fs.Flush();
			//fs.Close();
		}

		//========================================================
		private void WriteFile(string fileContent, string outputFile, bool append )
		{
			StreamWriter fs = new StreamWriter(outputFile, append);

			try 
			{
				fs.Write(fileContent);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

			fs.Flush();
			fs.Close();
		}

		//========================================================
		private DataTable GetRelationshipSchema()
		{
			DataTable dt;			
			OleDbConnection cn = new OleDbConnection(txtConnection.Text);
			cn.Open();

			dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new object[] {null} );
			dt.TableName = "ForeignKeys";
			dgTableSchema.CaptionText = "OleDb Relationship Schema";
			dgTableSchema.DataSource = dt;
			cn.Close();

			return dt;
		}

		//========================================================
		private DataTable GetTableSchema(string tableName)
		{
			DataTable dt;
			OleDbConnection cn = new OleDbConnection(txtConnection.Text);
			cn.Open();

			dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] {null, null, tableName, null});
			dt.TableName = tableName;
			dgTableSchema.CaptionText = "OleDb Table Schema [" + tableName + "]";
			dgTableSchema.DataSource = dt;
			cn.Close();

			return dt;
		}

		//========================================================
		private void CheckDirectories()
		{
			// Check user input for last backslash
			const string backslash = "\\";
			if (!txtOutputPath.Text.EndsWith(backslash)) txtOutputPath.Text += backslash;
			if (!txtTemplatePath.Text.EndsWith(backslash)) txtTemplatePath.Text += backslash;

			// Build full outpath
			string outputPath = txtOutputPath.Text + txtProjectName.Text + "\\";

			if ( !Directory.Exists( outputPath ) )
				Directory.CreateDirectory( outputPath );

			if ( !Directory.Exists( outputPath + "Dal" ) )
				Directory.CreateDirectory( outputPath + "Dal" );
			
			if ( !Directory.Exists( outputPath + "Biz" ) )
				Directory.CreateDirectory( outputPath + "Biz" );
			
			if ( !Directory.Exists( outputPath + "Sql" ) )
				Directory.CreateDirectory( outputPath + "Sql" );

			if ( !Directory.Exists( outputPath + "Txt" ) )
				Directory.CreateDirectory( outputPath + "Txt" );

			if ( !Directory.Exists( outputPath + "Web" ) )
				Directory.CreateDirectory( outputPath + "Web" );
			
			if ( !Directory.Exists( outputPath + "Web\\Controls" ) )
				Directory.CreateDirectory( outputPath + "Web\\Controls" );

			if ( !Directory.Exists( outputPath + "Win" ) )
				Directory.CreateDirectory( outputPath + "Win" );

			if ( !Directory.Exists( outputPath + "Xml" ) )
				Directory.CreateDirectory( outputPath + "Xml" );

			/*
			if ( !Directory.Exists( txtOutputPath.Text + "DataAccess" ) )
				Directory.CreateDirectory( txtOutputPath.Text + "DataAccess" );

			if ( !Directory.Exists( txtOutputPath.Text + "BizLogic" ) )
				Directory.CreateDirectory( txtOutputPath.Text + "BizLogic" );
			*/
		}


		//========================================================
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//RefreshDatabaseObjects();
		}
		
		//========================================================
		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			GenerateCode();
		}
		
		//========================================================
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//========================================================
		private void btnSelectAll_Click(object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in listTables.Items)
			{
				item.Checked = true;
			}
		}

		//========================================================
		private void btnSelectNone_Click(object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in listTables.Items)
			{
				item.Checked = false;
			}
		}

		//========================================================
		private void btnRefreshDatabaseObjects_Click(object sender, System.EventArgs e)
		{
			RefreshDatabaseObjects();
		}

		//========================================================
		private void btnFindTemplatesPath_Click(object sender, System.EventArgs e)
		{
			txtTemplatePath.Text = GetDirectoryPath("D:\\");
		}

		private void btnFindOutputPath_Click(object sender, System.EventArgs e)
		{
			txtOutputPath.Text = GetDirectoryPath("D:\\");
		}

		private void btnSelectAccessDB_Click(object sender, System.EventArgs e)
		{
			_isSql = false;
			findAccessDB.ShowDialog();
			txtConnection.Text = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Mode=ReadWrite|Share Deny None;Data Source=" + findAccessDB.FileName + ";";
		}

		private void linkTemplatesPath_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start( txtTemplatePath.Text );
		}

		private void linkOutputPath_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start( txtOutputPath.Text );
		}

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			
			listStatus.Items.Clear();
		}

		private void listTables_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked) GetTableSchema(listTables.Items[e.Index].Text);
		}

		private void GetLayers()
		{
			_doDal = false;
			_doBiz = false;
			_doSql = false;
			_doTxt = false;
			_doWeb = false;
			_doWin = false;
			_doXml = false;
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			// depopulate settings into private vars
			GetLayers();

			// build project XML
			Stream memStream = new MemoryStream();
			XmlTextWriter xmlWriter = new XmlTextWriter(memStream, System.Text.Encoding.UTF8);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Project");

			xmlWriter.WriteAttributeString("Name", txtProjectName.Text);
			xmlWriter.WriteAttributeString("Namespace", txtRootNamespace.Text);
			xmlWriter.WriteAttributeString("OutputPath", txtOutputPath.Text);
			xmlWriter.WriteAttributeString("TemplatePath", txtTemplatePath.Text);
			xmlWriter.WriteAttributeString("ConnectionString", txtConnection.Text);

			xmlWriter.WriteStartElement("Layer");			
			xmlWriter.WriteAttributeString("Dal", _doDal.ToString());
			xmlWriter.WriteAttributeString("Biz", _doBiz.ToString());
			xmlWriter.WriteAttributeString("Sql", _doSql.ToString());
			xmlWriter.WriteAttributeString("Txt", _doTxt.ToString());
			xmlWriter.WriteAttributeString("Web", _doWeb.ToString());
			xmlWriter.WriteAttributeString("Win", _doWin.ToString());
			xmlWriter.WriteAttributeString("Xml", _doXml.ToString());
			xmlWriter.WriteEndElement(); // Layers

			xmlWriter.WriteStartElement("Entity");
			foreach(ListViewItem item in listTables.Items)
			{
				xmlWriter.WriteStartElement(item.Text);
				xmlWriter.WriteAttributeString("Enabled", item.Checked.ToString());
				xmlWriter.WriteEndElement(); // Item
			}
			xmlWriter.WriteEndElement(); // Entity

			xmlWriter.WriteEndElement(); // Project
			xmlWriter.WriteEndDocument();			
			xmlWriter.Flush();

			// show save dialog
			if (saveProjectFile.ShowDialog() == DialogResult.OK)
			{
				XmlDocument xmlProjectSchema = new XmlDocument();
				memStream.Position = 0;
				xmlProjectSchema.Load(memStream);
				memStream.Close();
				WriteFile(xmlProjectSchema.OuterXml, saveProjectFile.FileName, false);
			}
			else
				MessageBox.Show("The project was not saved!", "DesignedNet.Generation.MetaStudio.SaveProject");

		}

	}
}
