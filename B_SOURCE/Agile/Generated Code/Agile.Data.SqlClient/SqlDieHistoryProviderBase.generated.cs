﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file SqlDieHistoryProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using Agile.Entities;
using Agile.Data;
using Agile.Data.Bases;

#endregion

namespace Agile.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="DieHistory"/> entity.
	///</summary>
	public abstract partial class SqlDieHistoryProviderBase : DieHistoryProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlDieHistoryProviderBase"/> instance.
		/// </summary>
		public SqlDieHistoryProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlDieHistoryProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlDieHistoryProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieHistoryId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 _dieHistoryId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@DieHistoryId", DbType.Int32, _dieHistoryId);
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Delete")); 

			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(DieHistory)
					,_dieHistoryId);
				EntityManager.StopTracking(entityKey);
			}
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Delete")); 

			commandWrapper = null;
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND).</remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieHistory objects.</returns>
		public override TList<DieHistory> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<DieHistory>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@DieHistoryId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DieRequestId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DieDateSubmit", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DieStatus", DbType.Int16, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DieHistoryNote", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DieHistoryNoteJp", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ReleaseId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Owner", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@LastUserUpdate", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@LastTimeUpdate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ActionTypeId", DbType.Int32, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("diehistoryid ") || clause.Trim().StartsWith("diehistoryid="))
				{
					database.SetParameterValue(commandWrapper, "@DieHistoryId", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("dierequestid ") || clause.Trim().StartsWith("dierequestid="))
				{
					database.SetParameterValue(commandWrapper, "@DieRequestId", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("diedatesubmit ") || clause.Trim().StartsWith("diedatesubmit="))
				{
					database.SetParameterValue(commandWrapper, "@DieDateSubmit", 
						clause.Trim().Remove(0,13).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("diestatus ") || clause.Trim().StartsWith("diestatus="))
				{
					database.SetParameterValue(commandWrapper, "@DieStatus", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("diehistorynote ") || clause.Trim().StartsWith("diehistorynote="))
				{
					database.SetParameterValue(commandWrapper, "@DieHistoryNote", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("diehistorynotejp ") || clause.Trim().StartsWith("diehistorynotejp="))
				{
					database.SetParameterValue(commandWrapper, "@DieHistoryNoteJp", 
						clause.Trim().Remove(0,16).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("releaseid ") || clause.Trim().StartsWith("releaseid="))
				{
					database.SetParameterValue(commandWrapper, "@ReleaseId", 
						clause.Trim().Remove(0,9).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("userid ") || clause.Trim().StartsWith("userid="))
				{
					database.SetParameterValue(commandWrapper, "@UserId", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("owner ") || clause.Trim().StartsWith("owner="))
				{
					database.SetParameterValue(commandWrapper, "@Owner", 
						clause.Trim().Remove(0,5).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("lastuserupdate ") || clause.Trim().StartsWith("lastuserupdate="))
				{
					database.SetParameterValue(commandWrapper, "@LastUserUpdate", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("lasttimeupdate ") || clause.Trim().StartsWith("lasttimeupdate="))
				{
					database.SetParameterValue(commandWrapper, "@LastTimeUpdate", 
						clause.Trim().Remove(0,14).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("actiontypeid ") || clause.Trim().StartsWith("actiontypeid="))
				{
					database.SetParameterValue(commandWrapper, "@ActionTypeId", 
						clause.Trim().Remove(0,12).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<DieHistory> rows = new TList<DieHistory>();
	
				
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if (reader != null) 
					reader.Close();	
					
				commandWrapper = null;
			}
			return rows;
		}

		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieHistory objects.</returns>
		public override TList<DieHistory> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Find_Dynamic", typeof(DieHistoryColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<DieHistory> rows = new TList<DieHistory>();
			IDataReader reader = null;
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;
				
				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if ( reader != null )
					reader.Close();
					
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion Parameterized Find Methods
		
		#endregion Find Functions
	
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieHistory objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<DieHistory> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<DieHistory> rows = new TList<DieHistory>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
					
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;	
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region GetPaged Methods
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieHistory objects.</returns>
		public override TList<DieHistory> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_GetPaged", _useStoredProcedure);
		
			
            if (commandWrapper.CommandType == CommandType.Text
                && commandWrapper.CommandText != null)
            {
                commandWrapper.CommandText = commandWrapper.CommandText.Replace(SqlUtil.PAGE_INDEX, string.Concat(SqlUtil.PAGE_INDEX, Guid.NewGuid().ToString("N").Substring(0, 8)));
            }
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			TList<DieHistory> rows = new TList<DieHistory>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
				
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions
	#endregion
	
		#region Get By Index Functions

		#region GetByDieHistoryId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieHistoryId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override Agile.Entities.DieHistory GetByDieHistoryId(TransactionManager transactionManager, System.Int32 _dieHistoryId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_GetByDieHistoryId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@DieHistoryId", DbType.Int32, _dieHistoryId);
			
			IDataReader reader = null;
			TList<DieHistory> tmp = new TList<DieHistory>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByDieHistoryId", tmp)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByDieHistoryId", tmp));
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk insert many entities to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the Agile.Entities.DieHistory object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<Agile.Entities.DieHistory> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "tblDIEHistory";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("DIEHistoryID", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("DIERequestID", typeof(System.Int32));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("DIEDateSubmit", typeof(System.DateTime));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("DIEStatus", typeof(System.Int16));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("DIEHistoryNote", typeof(System.String));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("DIEHistoryNoteJP", typeof(System.String));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("ReleaseID", typeof(System.Int32));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("UserID", typeof(System.Int32));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("Owner", typeof(System.Int32));
			col8.AllowDBNull = true;		
			DataColumn col9 = dataTable.Columns.Add("LastUserUpdate", typeof(System.Int32));
			col9.AllowDBNull = true;		
			DataColumn col10 = dataTable.Columns.Add("LastTimeUpdate", typeof(System.DateTime));
			col10.AllowDBNull = true;		
			DataColumn col11 = dataTable.Columns.Add("ActionTypeID", typeof(System.Int32));
			col11.AllowDBNull = true;		
			
			bulkCopy.ColumnMappings.Add("DIEHistoryID", "DIEHistoryID");
			bulkCopy.ColumnMappings.Add("DIERequestID", "DIERequestID");
			bulkCopy.ColumnMappings.Add("DIEDateSubmit", "DIEDateSubmit");
			bulkCopy.ColumnMappings.Add("DIEStatus", "DIEStatus");
			bulkCopy.ColumnMappings.Add("DIEHistoryNote", "DIEHistoryNote");
			bulkCopy.ColumnMappings.Add("DIEHistoryNoteJP", "DIEHistoryNoteJP");
			bulkCopy.ColumnMappings.Add("ReleaseID", "ReleaseID");
			bulkCopy.ColumnMappings.Add("UserID", "UserID");
			bulkCopy.ColumnMappings.Add("Owner", "Owner");
			bulkCopy.ColumnMappings.Add("LastUserUpdate", "LastUserUpdate");
			bulkCopy.ColumnMappings.Add("LastTimeUpdate", "LastTimeUpdate");
			bulkCopy.ColumnMappings.Add("ActionTypeID", "ActionTypeID");
			
			foreach(Agile.Entities.DieHistory entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["DIEHistoryID"] = entity.DieHistoryId;
							
				
					row["DIERequestID"] = entity.DieRequestId;
							
				
					row["DIEDateSubmit"] = entity.DieDateSubmit;
							
				
					row["DIEStatus"] = entity.DieStatus;
							
				
					row["DIEHistoryNote"] = entity.DieHistoryNote;
							
				
					row["DIEHistoryNoteJP"] = entity.DieHistoryNoteJp;
							
				
					row["ReleaseID"] = entity.ReleaseId.HasValue ? (object) entity.ReleaseId  : System.DBNull.Value;
							
				
					row["UserID"] = entity.UserId.HasValue ? (object) entity.UserId  : System.DBNull.Value;
							
				
					row["Owner"] = entity.Owner.HasValue ? (object) entity.Owner  : System.DBNull.Value;
							
				
					row["LastUserUpdate"] = entity.LastUserUpdate.HasValue ? (object) entity.LastUserUpdate  : System.DBNull.Value;
							
				
					row["LastTimeUpdate"] = entity.LastTimeUpdate.HasValue ? (object) entity.LastTimeUpdate  : System.DBNull.Value;
							
				
					row["ActionTypeID"] = entity.ActionTypeId.HasValue ? (object) entity.ActionTypeId  : System.DBNull.Value;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(Agile.Entities.DieHistory entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a Agile.Entities.DieHistory object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Agile.Entities.DieHistory object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the Agile.Entities.DieHistory object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, Agile.Entities.DieHistory entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@DieHistoryId", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@DieRequestId", DbType.Int32, entity.DieRequestId );
			database.AddInParameter(commandWrapper, "@DieDateSubmit", DbType.DateTime, entity.DieDateSubmit );
			database.AddInParameter(commandWrapper, "@DieStatus", DbType.Int16, entity.DieStatus );
			database.AddInParameter(commandWrapper, "@DieHistoryNote", DbType.String, entity.DieHistoryNote );
			database.AddInParameter(commandWrapper, "@DieHistoryNoteJp", DbType.String, entity.DieHistoryNoteJp );
			database.AddInParameter(commandWrapper, "@ReleaseId", DbType.Int32, (entity.ReleaseId.HasValue ? (object) entity.ReleaseId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, (entity.UserId.HasValue ? (object) entity.UserId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@Owner", DbType.Int32, (entity.Owner.HasValue ? (object) entity.Owner  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@LastUserUpdate", DbType.Int32, (entity.LastUserUpdate.HasValue ? (object) entity.LastUserUpdate  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@LastTimeUpdate", DbType.DateTime, (entity.LastTimeUpdate.HasValue ? (object) entity.LastTimeUpdate  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@ActionTypeId", DbType.Int32, (entity.ActionTypeId.HasValue ? (object) entity.ActionTypeId  : System.DBNull.Value));
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Insert", entity));
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					
			object _dieHistoryId = database.GetParameterValue(commandWrapper, "@DieHistoryId");
			entity.DieHistoryId = (System.Int32)_dieHistoryId;
			
			
			entity.AcceptChanges();
	
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Insert", entity));

			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Agile.Entities.DieHistory object to update.</param>
		/// <remarks>
		///		After updating the datasource, the Agile.Entities.DieHistory object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, Agile.Entities.DieHistory entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.tblDIEHistory_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@DieHistoryId", DbType.Int32, entity.DieHistoryId );
			database.AddInParameter(commandWrapper, "@DieRequestId", DbType.Int32, entity.DieRequestId );
			database.AddInParameter(commandWrapper, "@DieDateSubmit", DbType.DateTime, entity.DieDateSubmit );
			database.AddInParameter(commandWrapper, "@DieStatus", DbType.Int16, entity.DieStatus );
			database.AddInParameter(commandWrapper, "@DieHistoryNote", DbType.String, entity.DieHistoryNote );
			database.AddInParameter(commandWrapper, "@DieHistoryNoteJp", DbType.String, entity.DieHistoryNoteJp );
			database.AddInParameter(commandWrapper, "@ReleaseId", DbType.Int32, (entity.ReleaseId.HasValue ? (object) entity.ReleaseId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@UserId", DbType.Int32, (entity.UserId.HasValue ? (object) entity.UserId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@Owner", DbType.Int32, (entity.Owner.HasValue ? (object) entity.Owner : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@LastUserUpdate", DbType.Int32, (entity.LastUserUpdate.HasValue ? (object) entity.LastUserUpdate : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@LastTimeUpdate", DbType.DateTime, (entity.LastTimeUpdate.HasValue ? (object) entity.LastTimeUpdate : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@ActionTypeId", DbType.Int32, (entity.ActionTypeId.HasValue ? (object) entity.ActionTypeId : System.DBNull.Value) );
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Update", entity));

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);
			
			
			entity.AcceptChanges();
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Update", entity));

			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#endregion
	}//end class
} // end namespace
