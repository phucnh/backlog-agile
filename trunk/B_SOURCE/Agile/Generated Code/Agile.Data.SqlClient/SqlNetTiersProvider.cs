
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Agile.Entities;
using Agile.Data;
using Agile.Data.Bases;

#endregion

namespace Agile.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : Agile.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
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
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "ActionTypeProvider"
			
		private SqlActionTypeProvider innerSqlActionTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ActionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ActionTypeProviderBase ActionTypeProvider
		{
			get
			{
				if (innerSqlActionTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlActionTypeProvider == null)
						{
							this.innerSqlActionTypeProvider = new SqlActionTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlActionTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlActionTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlActionTypeProvider SqlActionTypeProvider
		{
			get {return ActionTypeProvider as SqlActionTypeProvider;}
		}
		
		#endregion
		
		
		#region "PriorityDieRequestProvider"
			
		private SqlPriorityDieRequestProvider innerSqlPriorityDieRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PriorityDieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PriorityDieRequestProviderBase PriorityDieRequestProvider
		{
			get
			{
				if (innerSqlPriorityDieRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPriorityDieRequestProvider == null)
						{
							this.innerSqlPriorityDieRequestProvider = new SqlPriorityDieRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPriorityDieRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPriorityDieRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPriorityDieRequestProvider SqlPriorityDieRequestProvider
		{
			get {return PriorityDieRequestProvider as SqlPriorityDieRequestProvider;}
		}
		
		#endregion
		
		
		#region "ProjectProvider"
			
		private SqlProjectProvider innerSqlProjectProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Project"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProjectProviderBase ProjectProvider
		{
			get
			{
				if (innerSqlProjectProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProjectProvider == null)
						{
							this.innerSqlProjectProvider = new SqlProjectProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProjectProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProjectProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProjectProvider SqlProjectProvider
		{
			get {return ProjectProvider as SqlProjectProvider;}
		}
		
		#endregion
		
		
		#region "ReleaseProvider"
			
		private SqlReleaseProvider innerSqlReleaseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Release"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ReleaseProviderBase ReleaseProvider
		{
			get
			{
				if (innerSqlReleaseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlReleaseProvider == null)
						{
							this.innerSqlReleaseProvider = new SqlReleaseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlReleaseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlReleaseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlReleaseProvider SqlReleaseProvider
		{
			get {return ReleaseProvider as SqlReleaseProvider;}
		}
		
		#endregion
		
		
		#region "ResolutionsProvider"
			
		private SqlResolutionsProvider innerSqlResolutionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Resolutions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ResolutionsProviderBase ResolutionsProvider
		{
			get
			{
				if (innerSqlResolutionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlResolutionsProvider == null)
						{
							this.innerSqlResolutionsProvider = new SqlResolutionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlResolutionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlResolutionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlResolutionsProvider SqlResolutionsProvider
		{
			get {return ResolutionsProvider as SqlResolutionsProvider;}
		}
		
		#endregion
		
		
		#region "MileStoleProvider"
			
		private SqlMileStoleProvider innerSqlMileStoleProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MileStole"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MileStoleProviderBase MileStoleProvider
		{
			get
			{
				if (innerSqlMileStoleProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMileStoleProvider == null)
						{
							this.innerSqlMileStoleProvider = new SqlMileStoleProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMileStoleProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMileStoleProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMileStoleProvider SqlMileStoleProvider
		{
			get {return MileStoleProvider as SqlMileStoleProvider;}
		}
		
		#endregion
		
		
		#region "DieTypeProvider"
			
		private SqlDieTypeProvider innerSqlDieTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieTypeProviderBase DieTypeProvider
		{
			get
			{
				if (innerSqlDieTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieTypeProvider == null)
						{
							this.innerSqlDieTypeProvider = new SqlDieTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieTypeProvider SqlDieTypeProvider
		{
			get {return DieTypeProvider as SqlDieTypeProvider;}
		}
		
		#endregion
		
		
		#region "DieStatusProvider"
			
		private SqlDieStatusProvider innerSqlDieStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieStatusProviderBase DieStatusProvider
		{
			get
			{
				if (innerSqlDieStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieStatusProvider == null)
						{
							this.innerSqlDieStatusProvider = new SqlDieStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieStatusProvider SqlDieStatusProvider
		{
			get {return DieStatusProvider as SqlDieStatusProvider;}
		}
		
		#endregion
		
		
		#region "DieCategoryProvider"
			
		private SqlDieCategoryProvider innerSqlDieCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieCategoryProviderBase DieCategoryProvider
		{
			get
			{
				if (innerSqlDieCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieCategoryProvider == null)
						{
							this.innerSqlDieCategoryProvider = new SqlDieCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieCategoryProvider SqlDieCategoryProvider
		{
			get {return DieCategoryProvider as SqlDieCategoryProvider;}
		}
		
		#endregion
		
		
		#region "DieAttachFileProvider"
			
		private SqlDieAttachFileProvider innerSqlDieAttachFileProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieAttachFile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieAttachFileProviderBase DieAttachFileProvider
		{
			get
			{
				if (innerSqlDieAttachFileProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieAttachFileProvider == null)
						{
							this.innerSqlDieAttachFileProvider = new SqlDieAttachFileProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieAttachFileProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieAttachFileProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieAttachFileProvider SqlDieAttachFileProvider
		{
			get {return DieAttachFileProvider as SqlDieAttachFileProvider;}
		}
		
		#endregion
		
		
		#region "DieHistoryProvider"
			
		private SqlDieHistoryProvider innerSqlDieHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieHistoryProviderBase DieHistoryProvider
		{
			get
			{
				if (innerSqlDieHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieHistoryProvider == null)
						{
							this.innerSqlDieHistoryProvider = new SqlDieHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieHistoryProvider SqlDieHistoryProvider
		{
			get {return DieHistoryProvider as SqlDieHistoryProvider;}
		}
		
		#endregion
		
		
		#region "UserProvider"
			
		private SqlUserProvider innerSqlUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerSqlUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserProvider == null)
						{
							this.innerSqlUserProvider = new SqlUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserProvider SqlUserProvider
		{
			get {return UserProvider as SqlUserProvider;}
		}
		
		#endregion
		
		
		#region "DieRequestProvider"
			
		private SqlDieRequestProvider innerSqlDieRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DieRequestProviderBase DieRequestProvider
		{
			get
			{
				if (innerSqlDieRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDieRequestProvider == null)
						{
							this.innerSqlDieRequestProvider = new SqlDieRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDieRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDieRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDieRequestProvider SqlDieRequestProvider
		{
			get {return DieRequestProvider as SqlDieRequestProvider;}
		}
		
		#endregion
		
		
		
		#region "HomeDieRequestProvider"
		
		private SqlHomeDieRequestProvider innerSqlHomeDieRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="HomeDieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override HomeDieRequestProviderBase HomeDieRequestProvider
		{
			get
			{
				if (innerSqlHomeDieRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlHomeDieRequestProvider == null)
						{
							this.innerSqlHomeDieRequestProvider = new SqlHomeDieRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlHomeDieRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlHomeDieRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlHomeDieRequestProvider SqlHomeDieRequestProvider
		{
			get {return HomeDieRequestProvider as SqlHomeDieRequestProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
