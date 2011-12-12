#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using Agile.Entities;
using Agile.Data;
using Agile.Data.Bases;

#endregion

namespace Agile.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("Agile.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region ActionTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ActionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ActionTypeProviderBase ActionTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ActionTypeProvider;
			}
		}
		
		#endregion
		
		#region PriorityDieRequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PriorityDieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PriorityDieRequestProviderBase PriorityDieRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PriorityDieRequestProvider;
			}
		}
		
		#endregion
		
		#region ProjectProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Project"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProjectProviderBase ProjectProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProjectProvider;
			}
		}
		
		#endregion
		
		#region ReleaseProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Release"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ReleaseProviderBase ReleaseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ReleaseProvider;
			}
		}
		
		#endregion
		
		#region ResolutionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Resolutions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ResolutionsProviderBase ResolutionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ResolutionsProvider;
			}
		}
		
		#endregion
		
		#region MileStoleProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MileStole"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MileStoleProviderBase MileStoleProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MileStoleProvider;
			}
		}
		
		#endregion
		
		#region DieTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieTypeProviderBase DieTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieTypeProvider;
			}
		}
		
		#endregion
		
		#region DieStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieStatusProviderBase DieStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieStatusProvider;
			}
		}
		
		#endregion
		
		#region DieCategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieCategoryProviderBase DieCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieCategoryProvider;
			}
		}
		
		#endregion
		
		#region DieAttachFileProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieAttachFile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieAttachFileProviderBase DieAttachFileProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieAttachFileProvider;
			}
		}
		
		#endregion
		
		#region DieHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieHistoryProviderBase DieHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieHistoryProvider;
			}
		}
		
		#endregion
		
		#region UserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserProviderBase UserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserProvider;
			}
		}
		
		#endregion
		
		#region DieRequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DieRequestProviderBase DieRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DieRequestProvider;
			}
		}
		
		#endregion
		
		
		#region HomeDieRequestProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="HomeDieRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static HomeDieRequestProviderBase HomeDieRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.HomeDieRequestProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region ActionTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeFilters : ActionTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		public ActionTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeFilters
	
	#region ActionTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ActionTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeQuery : ActionTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		public ActionTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeQuery
		
	#region PriorityDieRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestFilters : PriorityDieRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilters class.
		/// </summary>
		public PriorityDieRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PriorityDieRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PriorityDieRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PriorityDieRequestFilters
	
	#region PriorityDieRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PriorityDieRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestQuery : PriorityDieRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestQuery class.
		/// </summary>
		public PriorityDieRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PriorityDieRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PriorityDieRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PriorityDieRequestQuery
		
	#region ProjectFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectFilters : ProjectFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectFilters class.
		/// </summary>
		public ProjectFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectFilters
	
	#region ProjectQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProjectParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectQuery : ProjectParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectQuery class.
		/// </summary>
		public ProjectQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectQuery
		
	#region ReleaseFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseFilters : ReleaseFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseFilters class.
		/// </summary>
		public ReleaseFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReleaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReleaseFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReleaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReleaseFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReleaseFilters
	
	#region ReleaseQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ReleaseParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseQuery : ReleaseParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseQuery class.
		/// </summary>
		public ReleaseQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReleaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReleaseQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReleaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReleaseQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReleaseQuery
		
	#region ResolutionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Resolutions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResolutionsFilters : ResolutionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResolutionsFilters class.
		/// </summary>
		public ResolutionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResolutionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResolutionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResolutionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResolutionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResolutionsFilters
	
	#region ResolutionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ResolutionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Resolutions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResolutionsQuery : ResolutionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResolutionsQuery class.
		/// </summary>
		public ResolutionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResolutionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResolutionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResolutionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResolutionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResolutionsQuery
		
	#region MileStoleFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MileStole"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MileStoleFilters : MileStoleFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MileStoleFilters class.
		/// </summary>
		public MileStoleFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MileStoleFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MileStoleFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MileStoleFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MileStoleFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MileStoleFilters
	
	#region MileStoleQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MileStoleParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MileStole"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MileStoleQuery : MileStoleParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MileStoleQuery class.
		/// </summary>
		public MileStoleQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MileStoleQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MileStoleQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MileStoleQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MileStoleQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MileStoleQuery
		
	#region DieTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeFilters : DieTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeFilters class.
		/// </summary>
		public DieTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieTypeFilters
	
	#region DieTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeQuery : DieTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeQuery class.
		/// </summary>
		public DieTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieTypeQuery
		
	#region DieStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusFilters : DieStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusFilters class.
		/// </summary>
		public DieStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieStatusFilters
	
	#region DieStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusQuery : DieStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusQuery class.
		/// </summary>
		public DieStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieStatusQuery
		
	#region DieCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryFilters : DieCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilters class.
		/// </summary>
		public DieCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieCategoryFilters
	
	#region DieCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryQuery : DieCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryQuery class.
		/// </summary>
		public DieCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieCategoryQuery
		
	#region DieAttachFileFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileFilters : DieAttachFileFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilters class.
		/// </summary>
		public DieAttachFileFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieAttachFileFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieAttachFileFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieAttachFileFilters
	
	#region DieAttachFileQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieAttachFileParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileQuery : DieAttachFileParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileQuery class.
		/// </summary>
		public DieAttachFileQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieAttachFileQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieAttachFileQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieAttachFileQuery
		
	#region DieHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieHistoryFilters : DieHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilters class.
		/// </summary>
		public DieHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieHistoryFilters
	
	#region DieHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieHistoryQuery : DieHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieHistoryQuery class.
		/// </summary>
		public DieHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieHistoryQuery
		
	#region UserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilters : UserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		public UserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilters
	
	#region UserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserQuery : UserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		public UserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserQuery
		
	#region DieRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestFilters : DieRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestFilters class.
		/// </summary>
		public DieRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieRequestFilters
	
	#region DieRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DieRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestQuery : DieRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestQuery class.
		/// </summary>
		public DieRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieRequestQuery
		
	#region HomeDieRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestFilters : HomeDieRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilters class.
		/// </summary>
		public HomeDieRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HomeDieRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HomeDieRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HomeDieRequestFilters
	
	#region HomeDieRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="HomeDieRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestQuery : HomeDieRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestQuery class.
		/// </summary>
		public HomeDieRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HomeDieRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HomeDieRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HomeDieRequestQuery
	#endregion

	
}
