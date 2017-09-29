/********************************************************************************/
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//============================
using DesignedNet.Framework.Biz;
using Harkins.Dal;


//----------------------------
namespace Harkins.Biz
{
	/// <summary>Business logic class for sql server database table: Comment</summary>
	/// ================================================================================
	/// Object:	    Harkins.Biz.BizComment
	/// Language:	C# ASP.NET 
	/// --------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	9/13/2005 12:00:00 AM
	/// Modified:	
	/// --------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003
	/// ================================================================================
	public class BizComment : BizEntity
	{
		//========================================================
		//Field index constants
		//========================================================
		#region Field index constants

		private static Type[] _columnTypes = new Type[15] {typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime)};
		private static string[] _columnNames = new string[15] {"CommentID", "CommentTypeID", "ProjectID", "CompanyID", "ContactID", "CreatedByID", "AssignedToID", "Priority", "Thread", "Subject", "Comment", "Created", "Updated", "Reminder", "Completed"};

		// data column(s) name and index
		private const int _commentIDIndex = 0;
		private const int _commentTypeIDIndex = 1;
		private const int _projectIDIndex = 2;
		private const int _companyIDIndex = 3;
		private const int _contactIDIndex = 4;
		private const int _createdByIDIndex = 5;
		private const int _assignedToIDIndex = 6;
		private const int _priorityIndex = 7;
		private const int _threadIndex = 8;
		private const int _subjectIndex = 9;
		private const int _commentIndex = 10;
		private const int _createdIndex = 11;
		private const int _updatedIndex = 12;
		private const int _reminderIndex = 13;
		private const int _completedIndex = 14;

		#endregion
		

		//========================================================
		//Object constructors
		//========================================================
		public BizComment() : base("Comment") {}
		public BizComment(DataSet state) : base("Comment", state) {}


		//========================================================
		//Action verbs
		//========================================================
		#region Action verbs

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByCommentType(int commentTypeID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalComment dal = (DalComment)_dal;
			dal.ListByCommentType(commentTypeID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByProject(int projectID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalComment dal = (DalComment)_dal;
			dal.ListByProject(projectID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByCompany(int companyID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalComment dal = (DalComment)_dal;
			dal.ListByCompany(companyID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}

		/// --------------------------------------------------------
		/// <summary>Loads the specified list of entites from the database</summary>
		/// <returns>True if DataTable was loaded</returns>
		public bool ListByContact(int contactID)
		{
			// verify (and create) data access layer
			CheckDal();

			// verify (and create) state
			CheckState();

			// type data access layer and execute data access request
			DalComment dal = (DalComment)_dal;
			dal.ListByContact(contactID, _dataTable);
			dal.Close();

			// return result
			return (_dataTable != null);
		}
	
		#endregion
	
	
		//========================================================
		//Entity get/set methods
		//========================================================
		#region Entity get/set methods

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizCommentType CommentType
		{
			get
			{
				BizCommentType biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizCommentType(_dataSet);
						if (!IsNull( _columnNames[_commentTypeIDIndex] )) biz.Find(_commentTypeID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizCommentType();
						if (!IsNull( _columnNames[_commentTypeIDIndex] )) biz.Load(_commentTypeID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._commentTypeID = value._commentTypeID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizProject Project
		{
			get
			{
				BizProject biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizProject(_dataSet);
						if (!IsNull( _columnNames[_projectIDIndex] )) biz.Find(_projectID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizProject();
						if (!IsNull( _columnNames[_projectIDIndex] )) biz.Load(_projectID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._projectID = value._projectID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizCompany Company
		{
			get
			{
				BizCompany biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizCompany(_dataSet);
						if (!IsNull( _columnNames[_companyIDIndex] )) biz.Find(_companyID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizCompany();
						if (!IsNull( _columnNames[_companyIDIndex] )) biz.Load(_companyID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._companyID = value._companyID; } // attempt to sync key values
				catch { }
			}
		}

		/// --------------------------------------------------------
		/// <summary>Gets the business object for the releated entity</summary>
		public BizContact Contact
		{
			get
			{
				BizContact biz = null; // child entity business object
				
				if (HasState()) // process data according to mode
				{
					if (_mode == Mode.Inspect) // create new entity with same state and find data
					{
						biz = new BizContact(_dataSet);
						if (!IsNull( _columnNames[_contactIDIndex] )) biz.Find(_contactID);
					}
					else // create new entity with new state and load data
					{
						biz = new BizContact();
						if (!IsNull( _columnNames[_contactIDIndex] )) biz.Load(_contactID);
					}
				}
				
				return biz; // return business object created
			}
			set
			{
				try { this._contactID = value._contactID; } // attempt to sync key values
				catch { }
			}
		}

		#endregion
		

		//========================================================
		//Attribute get/set methods
		//========================================================
		#region Attribute get/set methods

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CommentID</summary>
		public object CommentID
		{
			get { return this[ _columnNames[_commentIDIndex] ]; }
		}
		
		public int _commentID
		{
			get { return GetInt32( _columnNames[_commentIDIndex] ); }
			set { SetInt32( _columnNames[_commentIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CommentTypeID</summary>
		public object CommentTypeID
		{
			get { return this[ _columnNames[_commentTypeIDIndex] ]; }
		}
		
		public int _commentTypeID
		{
			get { return GetInt32( _columnNames[_commentTypeIDIndex] ); }
			set { SetInt32( _columnNames[_commentTypeIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for ProjectID</summary>
		public object ProjectID
		{
			get { return this[ _columnNames[_projectIDIndex] ]; }
		}
		public bool ProjectIDIsNull
		{
			get { return IsNull( _columnNames[_projectIDIndex] ); }
			set { this[ _columnNames[_projectIDIndex] ] = System.DBNull.Value; }
		}
		public int _projectID
		{
			get { return GetInt32( _columnNames[_projectIDIndex] ); }
			set { SetInt32( _columnNames[_projectIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CompanyID</summary>
		public object CompanyID
		{
			get { return this[ _columnNames[_companyIDIndex] ]; }
		}
		public bool CompanyIDIsNull
		{
			get { return IsNull( _columnNames[_companyIDIndex] ); }
			set { this[ _columnNames[_companyIDIndex] ] = System.DBNull.Value; }
		}
		public int _companyID
		{
			get { return GetInt32( _columnNames[_companyIDIndex] ); }
			set { SetInt32( _columnNames[_companyIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for ContactID</summary>
		public object ContactID
		{
			get { return this[ _columnNames[_contactIDIndex] ]; }
		}
		public bool ContactIDIsNull
		{
			get { return IsNull( _columnNames[_contactIDIndex] ); }
			set { this[ _columnNames[_contactIDIndex] ] = System.DBNull.Value; }
		}
		public int _contactID
		{
			get { return GetInt32( _columnNames[_contactIDIndex] ); }
			set { SetInt32( _columnNames[_contactIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for CreatedByID</summary>
		public object CreatedByID
		{
			get { return this[ _columnNames[_createdByIDIndex] ]; }
		}
		public bool CreatedByIDIsNull
		{
			get { return IsNull( _columnNames[_createdByIDIndex] ); }
			set { this[ _columnNames[_createdByIDIndex] ] = System.DBNull.Value; }
		}
		public int _createdByID
		{
			get { return GetInt32( _columnNames[_createdByIDIndex] ); }
			set { SetInt32( _columnNames[_createdByIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for AssignedToID</summary>
		public object AssignedToID
		{
			get { return this[ _columnNames[_assignedToIDIndex] ]; }
		}
		public bool AssignedToIDIsNull
		{
			get { return IsNull( _columnNames[_assignedToIDIndex] ); }
			set { this[ _columnNames[_assignedToIDIndex] ] = System.DBNull.Value; }
		}
		public int _assignedToID
		{
			get { return GetInt32( _columnNames[_assignedToIDIndex] ); }
			set { SetInt32( _columnNames[_assignedToIDIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the int typed value for Priority</summary>
		public object Priority
		{
			get { return this[ _columnNames[_priorityIndex] ]; }
		}
		public bool PriorityIsNull
		{
			get { return IsNull( _columnNames[_priorityIndex] ); }
			set { this[ _columnNames[_priorityIndex] ] = System.DBNull.Value; }
		}
		public int _priority
		{
			get { return GetInt32( _columnNames[_priorityIndex] ); }
			set { SetInt32( _columnNames[_priorityIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Thread</summary>
		public object Thread
		{
			get { return this[ _columnNames[_threadIndex] ]; }
		}
		public bool ThreadIsNull
		{
			get { return IsNull( _columnNames[_threadIndex] ); }
			set { this[ _columnNames[_threadIndex] ] = System.DBNull.Value; }
		}
		public string _thread
		{
			get { return GetString( _columnNames[_threadIndex] ); }
			set { SetString( _columnNames[_threadIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Subject</summary>
		public object Subject
		{
			get { return this[ _columnNames[_subjectIndex] ]; }
		}
		
		public string _subject
		{
			get { return GetString( _columnNames[_subjectIndex] ); }
			set { SetString( _columnNames[_subjectIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the string typed value for Comment</summary>
		public object Comment
		{
			get { return this[ _columnNames[_commentIndex] ]; }
		}
		
		public string _comment
		{
			get { return GetString( _columnNames[_commentIndex] ); }
			set { SetString( _columnNames[_commentIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Created</summary>
		public object Created
		{
			get { return this[ _columnNames[_createdIndex] ]; }
		}
		
		public DateTime _created
		{
			get { return GetDateTime( _columnNames[_createdIndex] ); }
			//set { SetDateTime( _columnNames[_createdIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Updated</summary>
		public object Updated
		{
			get { return this[ _columnNames[_updatedIndex] ]; }
		}
		public bool UpdatedIsNull
		{
			get { return IsNull( _columnNames[_updatedIndex] ); }
			//set { this[ _columnNames[_updatedIndex] ] = System.DBNull.Value; }
		}
		public DateTime _updated
		{
			get { return GetDateTime( _columnNames[_updatedIndex] ); }
			//set { SetDateTime( _columnNames[_updatedIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Reminder</summary>
		public object Reminder
		{
			get { return this[ _columnNames[_reminderIndex] ]; }
		}
		public bool ReminderIsNull
		{
			get { return IsNull( _columnNames[_reminderIndex] ); }
			set { this[ _columnNames[_reminderIndex] ] = System.DBNull.Value; }
		}
		public DateTime _reminder
		{
			get { return GetDateTime( _columnNames[_reminderIndex] ); }
			set { SetDateTime( _columnNames[_reminderIndex], value ); }
		}

		/// --------------------------------------------------------
		/// <summary>Gets or sets the DateTime typed value for Completed</summary>
		public object Completed
		{
			get { return this[ _columnNames[_completedIndex] ]; }
		}
		public bool CompletedIsNull
		{
			get { return IsNull( _columnNames[_completedIndex] ); }
			set { this[ _columnNames[_completedIndex] ] = System.DBNull.Value; }
		}
		public DateTime _completed
		{
			get { return GetDateTime( _columnNames[_completedIndex] ); }
			set { SetDateTime( _columnNames[_completedIndex], value ); }
		}

		#endregion

	
		//========================================================
		//IBizEntity implementation
		//========================================================
		#region Implementation of IBizEntity
		
		public override bool CreateDal()
		{
			_dal = new DalComment();
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
			for(int col=1; col<=_columnNames.GetUpperBound(0); col++) _dataTable.Columns.Add( _columnNames[ col ], _columnTypes[ col ] );

			// add DataTable to DataSet
			if (_dataSet == null) _dataSet = new DataSet();
			_dataSet.Tables.Add(_dataTable);

			// add relationships to DataSet
			if (_dataSet.Tables.Contains("CommentType"))
			{
				string relationshipName = GetRelationshipName("CommentType");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["CommentType"].Columns["CommentTypeID"];
					DataColumn fk = _dataSet.Tables["Comment"].Columns["CommentTypeID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("Project"))
			{
				string relationshipName = GetRelationshipName("Project");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["Project"].Columns["ProjectID"];
					DataColumn fk = _dataSet.Tables["Comment"].Columns["ProjectID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("Company"))
			{
				string relationshipName = GetRelationshipName("Company");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["Company"].Columns["CompanyID"];
					DataColumn fk = _dataSet.Tables["Comment"].Columns["CompanyID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
			if (_dataSet.Tables.Contains("Contact"))
			{
				string relationshipName = GetRelationshipName("Contact");
				if (!_dataSet.Relations.Contains(relationshipName))
				{
					DataColumn pk = _dataSet.Tables["Contact"].Columns["ContactID"];
					DataColumn fk = _dataSet.Tables["Comment"].Columns["ContactID"];
					_dataSet.Relations.Add(new DataRelation(relationshipName, pk, fk)); // add new relationship
				}
			}
			
					
			// return success
			return (_dataTable != null);
		}
		
		#endregion		
	}
}
